using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manager class used to affect colors on materials, change fonts or improve user experience
/// </summary>
//TODO will change class name to "UxManager" instead in the future
public class ColorManager : MonoBehaviour
{
    public delegate void UxEventHandler();
    public static event UxEventHandler onActiveUX;

    public delegate void ChangeFontHandler(TMP_FontAsset newFont, float scaleFont);
    public event ChangeFontHandler onChangeFont;

    #region COLORS AND MATERIALS VARIABLES
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
    #endregion

    #region SET SPECIFIC COLORS VARIABLES
    [Space(5)]
    /// <summary>
    /// colorDropDown and randomizeColorsToggle are used for specifying colors
    /// </summary>
    [Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    [SerializeField]
    private TMP_Dropdown colorDropdown;
    public TMP_Dropdown ColorDropdown { get { return colorDropdown; } }

    // Variables used to set specific colors
    List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };
    #endregion

    #region RANDOM COLORS VARIABLES
    [Space(5)]
    // NEW RANDOM COLOR VARIABLES
    private ColorIndex tileIndex = new ColorIndex();

    [Tooltip("How fast will the change of color happen? The lower the value, the faster the change happens")]
    [SerializeField, Range(0.1f, 10f)]
    private float changeColorTime = 1f;

    [Tooltip("Duration of time left until the color on materials will change")]
    [SerializeField, Range(10f, 300f)]
    private float changeColorDuration = 30f;
    // How much much of the current time is left until the color changes again?
    private float currentColorDuration;

    // OLD RANDOM COLOR VARIABLES
    // Variables used to Randomize colors
    public float colorChangeTimerReset;
    private float colorChangeTimer;
    private bool currentlyChangingColor;

    [Tooltip("Randomly changes colors on the level when active")]
    [SerializeField]
    private Toggle randomColorsToggle;
    public Toggle RandomColorsToggle { get { return randomColorsToggle; } }
    public bool RandomColorsToggleOn { get { return randomColorsToggle.isOn; } }
    [Tooltip("Visual element that the user can see if randomizing colors are active or not")]
    [SerializeField]
    private TextMeshProUGUI randomColorsStatus;
    #endregion

    #region GRAYSCALE VARIABLES
    [Space(5)]
    [Tooltip("Toggle grayscale 'overlay' on an off")]
    [SerializeField]
    private Toggle grayscaleToggle;
    public Toggle GrayscaleToggle { get { return grayscaleToggle; } }
    public bool GrayscaleToggleOn { get { return grayscaleToggle.isOn; } }

    [Tooltip("Visual element that the user can see if grayscale 'overlay' is active or not")]
    [SerializeField]
    private TextMeshProUGUI grayscaleStatus;
    #endregion

    #region FONT VARIABLES
    [Space(5)]
    [SerializeField]
    // Toggle UI object
    private Toggle dyslexicFontToggle;
    public bool DyslexicFontToggleOn { get { return dyslexicFontToggle.isOn; } }

    [SerializeField]
    ///<summary>
    /// Visual text element to show the player if the dyslexic font is active or not
    ///</summary>
    private TextMeshProUGUI dyslexicFontStatus;

    // Regular font variables
    [SerializeField, Space(5)]
    private TMP_FontAsset regularFont; 
    public TMP_FontAsset RegularFont { get { return regularFont; } }
    [SerializeField]
    [Range(0.01f, 1)]
    [Tooltip("Sets the scale on the regular font")]
    private float regularFontScale;
    public float RegularFontScale { get { return regularFontScale; } }

    // Dyslexic font variables
    [SerializeField]
    [Range(0.01f, 1)]
    [Tooltip("Sets the scale on the dyslexic font")]
    private float dyslexicFontScale;
    public float DyslexicFontScale { get { return dyslexicFontScale; } }
    [SerializeField, Space(5)]
    private TMP_FontAsset dyslexicFont;
    public TMP_FontAsset DyslexicFont { get { return dyslexicFont; } }

    // Sets what ever is the current active font and its current scale
    public TMP_FontAsset currentFont { get; private set; }
    public float currentScale { get; private set; }
    #endregion

    // Currently used to affect font size but can have other areas to be used
    private TextMeshPro TMP;

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    public static ColorManager Instance { get; private set; } 

    public static void newUxActive()
    {
        if (onActiveUX != null)
        {
            onActiveUX();
        }
    }

    #region GENERIC METHODS
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
        currentScale = RegularFontScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        // To be removed (find out if it is some or all of them
        currentTileColor = tileMaterial.color;
        currentFloorColor = floorMaterial.color;
        colorChangeTimer = colorChangeTimerReset;

        //currentFont = RegularFont;
        /* To be ADDED
        SelectNewRandomColorIndices();
        UpdateColors(1f);
        
        StartCoroutine(MakeRandomColor());
        */
    }

    // Update is called once per frame
    void Update()
    {
        SetColorMode();
    }
    #endregion

    #region RANDOM COLOR METHODS

    #region new random color methods
    /// <summary>
    /// Updates color indices for all indices
    /// </summary>
    private void SelectNewRandomColorIndices()
    {
        // Cycles the indices in the lists of colors (Tiles and Floors)
        SetNewColorIndice(tileIndex, tileColorList); // Copy this row and change tileIndex and tileColorList to floor or other, if adding more.
        SetNewColorIndice(tileIndex, floorColorList);
    }

    /// <summary>
    /// Selects new indices for the provided indice, from the provided list.
    /// </summary>
    /// <param name="indice">The indice to update</param>
    /// <param name="colors">The list of colors to choose from</param>
    private void SetNewColorIndice(ColorIndex indice, Color[] colors)
    {
        // We've completed one full cycle of color fade, so "next" color index should be saved as "previous"
        indice.previous = indice.next;
        // Select a new color from the provided list
        indice.next = Random.Range(0, colors.Length - 1);
    }

    /// <summary>
    /// Updates colors for all materials
    /// </summary>
    /// <param name="fraction"></param>
    private void UpdateColors(float fraction)
    {
        // Updates the color of the material on Tiles and Floors
        UpdateColor(tileMaterial, tileColorList, tileIndex, fraction); // Copy this row and change tileMaterial, tileIndex and tileColorList to floor or other, if adding more.
        UpdateColor(floorMaterial, floorColorList, tileIndex, fraction);
        currentColorDuration = changeColorDuration;

    }

    /// <summary>
    /// Updates color for the specified material
    /// </summary>
    /// <param name="material"></param>
    /// <param name="colorList"></param>
    /// <param name="indice"></param>
    /// <param name="fraction"></param>
    private void UpdateColor(Material material, Color[] colorList, ColorIndex indice, float fraction)
    {
        material.color = Color.Lerp(colorList[indice.previous], colorList[indice.next], fraction);
    }

    /// <summary>
    /// "Blends" one color into another predetermined color 
    /// </summary>
    IEnumerator MakeRandomColor()
    {
        float elapsedTime = 0f;

        while (true)
        {
            SelectNewRandomColorIndices(); // Select the new Colors
            while (elapsedTime < changeColorTime)
            {
                // This loop makes sure the color is updated
                elapsedTime += Time.deltaTime;
                float fraction = Mathf.Sin(elapsedTime / changeColorTime);

                UpdateColors(fraction); // Update the actual material colors

                yield return new WaitForSeconds(0);
            }
            elapsedTime = 0;
            yield return new WaitForSeconds(changeColorDuration);
        }
    }

    /// <summary>
    /// To easier keep track of two indices
    /// </summary>
    private class ColorIndex
    {
        public int previous, next;
    }
    #endregion

    #region old random color methods
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
    #endregion

    #endregion

    #region SET SPECIFIC COLOR METHODS
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
    }
    #endregion

    #region ACCESSIBILITY METHODS
    ///<summary>
    /// Used to turn "Grayscale Mode" on and off, user can still set specific color.
    /// Disables color randomization when GrayscaleToggle.isOn is true, renables it when set to false
    /// </summary>
    public void SetGrayscaleMode()
    {
        // TODO 3a Take a look at if change to accessing Player Camera (which is a prefab in "final" version"),
        // TODO 3b how is the camera accessed? if it's a prefab, does that need to be changed?

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (GrayscaleToggleOn)
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
        else
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
            currentScale = DyslexicFontScale;
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
            currentScale = RegularFontScale;
            dyslexicFontStatus.text = "OFF";
            //PlayerPrefs.Save();
        }

        ///<summary>
        ///This null check is important, 
        ///because if no listeners are registered, 
        ///it will result in an NPE.
        /// </summary>
        if (onChangeFont != null) // 
        {
            // Inform text objects with ChangeFont class attached to update to the new font
            onChangeFont.Invoke(currentFont, currentScale);
        }
        //Debug.Log("Current font is: " + currentFont); // Uncomment to debug what font is active
    }
    #endregion

}