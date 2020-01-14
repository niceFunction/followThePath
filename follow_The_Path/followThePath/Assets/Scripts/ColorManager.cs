using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// https://www.youtube.com/watch?v=pvo0RCiqtLQ&feature=youtu.be&t=254
// https://www.youtube.com/watch?v=usAaH5Mi0ZQ

/// <summary>
/// Manager class used to affect colors on materials, change fonts or improve user experience
/// </summary>
//TODO will change class name to "UxManager" instead in the future
public class ColorManager : MonoBehaviour
{
    public delegate void UxEventHandler();
    public static event UxEventHandler onActiveUX;

    public delegate void ChangeFontHandler(TMP_FontAsset newFont);
    public event ChangeFontHandler onChangeFont;

    #region COLORS AND MATERIALS
    /// <summary>
    /// The Materials are added to the references in the Inspector
    /// </summary>
    [Tooltip("Used to change color on the Tiles")]
    [SerializeField]
    // TODO personal note: keep in mind if tile/floor material needs to be public again if other objects needs to access them
    private Material tileMaterial;
    [Tooltip("Used to change the color of the Floor")]
    [SerializeField]
    private Material floorMaterial;
    
    [Space(5)]
    /// <summary>
    /// The Color arrays size are specified in the Inspector.
    /// In this case, colors of the Rainbow and the colors for the floor
    /// is in a darker hue.
    /// </summary>
    [SerializeField]
    [Tooltip("Creates an Array of Colors for Tiles")]
    private Color[] tileColorList;
    [SerializeField]
    [Tooltip("Create an Array of Colors for Floors")]
    private Color[] floorColorList;

    // Used to get/set the current Color
    private Color currentTileColor;
    private Color currentFloorColor;

    [Space(5)]
    // Variables used to Randomize colors
    public float colorChangeTimerReset;
    private float colorChangeTimer;
    private bool currentlyChangingColor;
    #endregion

    #region SET SPECIFIC COLORS
    [Space(5)]
    /// <summary>
    /// colorDropDown and randomizeColorsToggle are used for specifying colors
    /// </summary>
    [Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    // TODO 1a. do not expose GUI elements like this, as this object should manage them. 
    // TODO 1b. Create a property that returns the value instead.
    [SerializeField]
    private TMP_Dropdown colorDropdown;
    public TMP_Dropdown ColorDropdown { get { return colorDropdown; } }
    // Variables used to set specific colors
    List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };
    #endregion

    #region RANDOM COLORS
    [Space(5)]
    [Tooltip("Randomly changes colors on the level when active")]
    [SerializeField]
    private Toggle randomColorsToggle;
    //public Toggle RandomColorsToggle { get { return randomColorsToggle; } }
    public bool RandomColorsToggleOn { get { return randomColorsToggle.isOn; } }
    [Tooltip("Visual element that the user can see if randomizing colors are active or not")]
    [SerializeField]
    private TextMeshProUGUI randomColorsStatus;
    #endregion

    #region GRAYSCALE
    [Space(5)]
    [Tooltip("Toggle grayscale 'overlay' on an off")]
    [SerializeField]
    private Toggle grayscaleToggle;
    public Toggle GrayscaleToggle { get { return grayscaleToggle; } }

    [Tooltip("Visual element that the user can see if grayscale 'overlay' is active or not")]
    [SerializeField]
    private TextMeshProUGUI grayscaleStatus;
    #endregion

    #region FONT
    [Space(5)]
    /* 
    TODO do not expose things like toggles, as they belong to this object,
    TODO create a property boolean that returns whether the toggle is on/off instead.
    */
    [SerializeField]
    private Toggle dyslexicFontToggle;
    //public Toggle DyslexicFontToggle { get { return dyslexicFontToggle.isOn; } }
    public bool DyslexicFontToggleOn { get { return dyslexicFontToggle.isOn; } }

    [SerializeField]
    private TextMeshProUGUI dyslexicFontStatus;

    [SerializeField, Space(5)]
    // TODO keep set things like fonts private to the class that manages them
    private TMP_FontAsset regularFont; 
    public TMP_FontAsset RegularFont { get { return regularFont; } }

    [SerializeField, Space(5)]
    // TODO expose things through properties, which will prevent accidentally changing them and decrease coupling.
    private TMP_FontAsset dyslexicFont;
    public TMP_FontAsset DyslexicFont { get { return dyslexicFont; } }

    public TMP_FontAsset currentFont { get; private set; }
    #endregion

    // Currently used to affect font size but can have other areas to be used
    private TextMeshPro TMP;

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    // https://flaredust.com/game-dev/unity/having-fun-with-shaders-in-unity/
    // Single instances are normally referenced with class.Instance
    public static ColorManager Instance { get; private set; } 

    public static void newUxActive()
    {
        if (onActiveUX != null)
        {
            onActiveUX();
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // DontDestroyOnLoad(gameObject);
        currentFont = RegularFont;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTileColor = tileMaterial.color;
        currentFloorColor = floorMaterial.color;
        colorChangeTimer = colorChangeTimerReset;

        //currentFont = RegularFont;
    }

    // Update is called once per frame
    void Update()
    {
        SetColorMode();
    }

    #region Setting specific color and Getting Random colors
    /// <summary>
    /// If randomizationToggle.isOn is set to true, colors are randomized
    /// if false, user can set specific color on materials
    /// </summary>
    public void SetColorMode()
    {
        if (RandomColorsToggleOn)
        {
            ///<summary>
            /// Color Randomization is active and set specific color dropdown is non-interactable
            /// </summary>
            ColorDropdown.interactable = false;
            randomColorsStatus.text = "ON";
            NewRandomColor();
        }
        else
        {
            ///<summary>
            /// Color randomization is inactive and set specific color dropdown is interactable
            /// </summary>
            ColorDropdown.interactable = true;
            randomColorsStatus.text = "OFF";
            colorChangeTimer = colorChangeTimerReset;
        }

        // if the grayscale toggle is active, make color dropdown not interactable
        if (GrayscaleToggle.isOn == true)
        {
            ColorDropdown.interactable = false;
        }
    }

    /// <summary>
    /// Changes color on materials every time the timer reaches 0
    /// </summary>
    public void NewRandomColor()
    {
        colorChangeTimer -= Time.deltaTime;

        if (colorChangeTimer < 0 && !currentlyChangingColor)
        {
            currentlyChangingColor = true;
            colorChangeTimer = colorChangeTimerReset;
            StartCoroutine(SetRandomColor());
        }
    }

    /// <summary>
    /// This Coroutine is used to randomize the "Tile" colors using Random.Range
    /// </summary>
    /// <returns></returns>
    IEnumerator SetRandomColor()
    {
        currentlyChangingColor = true;
        //TODO 2a Look more into getting random element from array
        //TODO 2b Look into an for loop that creates a "list" of elements (7 of them),
        //TODO 2c that everytime it changes, removes that element from the "list",
        //TODO 2d when the "list" is empty, it randomizes the list of colors again.

        ///<summary>
        /// Using tileColorList as the 2nd argument in Random.Range as both
        /// of the tile- and floor mateial color arrays are of the same length.
        /// </summary>
        int colorIndex = Random.Range(0, tileColorList.Length);

        float elapsedTime = 0.0f;
        float totalTime = 6.0f;

        // Set the materials into a random color
        while (elapsedTime < totalTime && colorIndex >= 0 && colorIndex <= 6)
        {
            elapsedTime += Time.deltaTime;
            float fraction = Mathf.Sin(elapsedTime / totalTime);

            tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[colorIndex], fraction);
            floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[colorIndex], fraction);

            yield return null;
        }
        currentlyChangingColor = false;
    }

    /// <summary>
    /// Populates the dropdown UI menu with a list of strings
    /// </summary>
    void PopulateColorList()
    {
        ColorDropdown.AddOptions(colorNames);
    }

    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void SetSpecificColor(int index)
    {
        #region Set materials to a specific color
        if (index == 0)
        {
            // Set colors to RED
            tileMaterial.color = tileColorList[0];
            floorMaterial.color = floorColorList[0];
        }
        else if (index == 1)
        {
            // Set colors to ORANGE
            tileMaterial.color = tileColorList[1];
            floorMaterial.color = floorColorList[1];
        }
        else if (index == 2)
        {
            // Set colors to YELLOW
            tileMaterial.color = tileColorList[2];
            floorMaterial.color = floorColorList[2];
        }
        else if (index == 3)
        {
            // Set colors to GREEN
            tileMaterial.color = tileColorList[3];
            floorMaterial.color = floorColorList[3];
        }
        else if (index == 4)
        {
            // Set colors to BLUE
            tileMaterial.color = tileColorList[4];
            floorMaterial.color = floorColorList[4];
        }
        else if (index == 5)
        {
            // Set colors to INDIGO
            tileMaterial.color = tileColorList[5];
            floorMaterial.color = floorColorList[5];
        }
        else if (index == 6)
        {
            // Set colors to VIOLET
            tileMaterial.color = tileColorList[6];
            floorMaterial.color = floorColorList[6];
        }
        #endregion
    }
    #endregion

    ///<summary>
    /// Used to turn "Grayscale Mode" on and off, user can still set specific color.
    /// Disables color randomization when GrayscaleToggle.isOn is true, renables it when set to false
    /// </summary>
    public void SetGrayscaleMode()
    {
        // TODO 3a Take a look at if change to accessing Player Camera (which is a prefab in "final" version"),
        // TODO 3b how is the camera accessed? if it's a prefab, does that need to be changed?

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (GrayscaleToggle.isOn == true)
        {
            ///<summary>
            /// if grayscale toggle object is on,
            ///  activate grayscale camera overlay.
            /// </summary>
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;

            RandomColorsToggle.isOn = false;
            RandomColorsToggle.interactable = false;

            grayscaleStatus.text = "ON";
            colorChangeTimer = colorChangeTimerReset;
        }
        else if (GrayscaleToggle.isOn == false)
        {
            ///<summary>
            /// if grayscale toggle object is NOT on,
            /// deactivate grayscale camera overlay.
            /// </summary>
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;

            RandomColorsToggle.interactable = true;

            grayscaleStatus.text = "OFF";
        }
    }

    public void SetDyslexicFont()
    {
        if (DyslexicFontToggleOn)
        {
            ///<summary>
            /// if dyslexic toggle object IS on,
            /// set the current font to the dyslexic font
            /// </summary>
            currentFont = DyslexicFont;
            dyslexicFontStatus.text = "ON";
            //PlayerPrefs.Save();
        }

        else
        {
            ///<summary>
            /// if dyslexic toggle object is not on,
            /// set current font to the regular font
            /// </summary>
            currentFont = RegularFont;
            dyslexicFontStatus.text = "OFF";
            //PlayerPrefs.Save();
        }

        // Inform text objects with ChangeFont class attached to update to the new font
        if (onChangeFont != null) // This null check is important, because if no listeners are registered, it will result in an NPE.
        {
            onChangeFont.Invoke(currentFont);
        }
        //Debug.Log("Current font is: " + currentFont); // Uncomment to debug what font is active
    }
}