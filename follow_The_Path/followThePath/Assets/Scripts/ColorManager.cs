using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manager class used to change the color of prefabs, specifically Tiles and Floors.
/// </summary>

// https://www.youtube.com/watch?v=pvo0RCiqtLQ&feature=youtu.be&t=254
// https://www.youtube.com/watch?v=usAaH5Mi0ZQ

//TODO will change class name to "VisualManager" instead in the future
public class ColorManager : MonoBehaviour
{
    /// <summary>
    /// The Materials are added to the references in the Inspector
    /// </summary>
    [Tooltip("Used to change color on the Tiles")]
    public Material tileMaterial;
    [Tooltip("Used to change the color of the Floor")]
    public Material floorMaterial;

    [Space(5)]
    /// <summary>
    /// colorDropDown and randomizeColorsToggle are used for specifying colors
    /// </summary>
    [Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    public TMP_Dropdown colorDropdown;

    [Space(5)]
    [Tooltip("Randomly changes colors on the level wjen active")]
    public Toggle randomColorsToggle;
    [Tooltip("Visual element that the user can see if randomizing colors are active or not")]
    [SerializeField]
    private TextMeshProUGUI randomColorsStatus;

    [Space(5)]
    [Tooltip("Toggle grayscale 'overlay' on an off")]
    public Toggle grayscaleToggle;
    [Tooltip("Visual element that the user can see if grayscale 'overlay' is active or not")]
    [SerializeField]
    private TextMeshProUGUI grayscaleStatus;

    [Space(5)]
    public Toggle dyslexicFontToggle;
    [SerializeField]
    private TextMeshProUGUI dyslexicFontStatus;

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

    // Variables used to set specific colors
    List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    [SerializeField]
    private ChangeFont changeFont;

    public List<GameObject> textObjects = new List<GameObject>();

    // https://flaredust.com/game-dev/unity/having-fun-with-shaders-in-unity/
    public static ColorManager ColorInstance { get; private set; }
    void Awake()
    {

        if (ColorInstance == null)
        {
            ColorInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        // Preferably I want to add all objects with the tag "UIText" at the run time
        // both active and inactive
        textObjects.AddRange(GameObject.FindGameObjectsWithTag("UIText"));
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTileColor = tileMaterial.color;
        currentFloorColor = floorMaterial.color;
        colorChangeTimer = colorChangeTimerReset;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Camera: " + playerCamera);
        Debug.Log(textObjects);
        //addedTextObjects = GameObject.FindGameObjectsWithTag("UIText");
        SetColorMode();
    }

    #region Setting specific color and Getting Random colors
    /// <summary>
    /// If randomizationToggle.isOn is set to true, colors are randomized
    /// if false, user can set specific color on materials
    /// </summary>
    public void SetColorMode()
    {   
        if (randomColorsToggle.isOn == true)
        {
            ///<summary>
            /// Color Randomization is active and set specific color dropdown is non-interactable
            /// </summary>
            colorDropdown.interactable = false;
            randomColorsStatus.text = "ON";
            NewRandomColor();
        }
        else if (randomColorsToggle.isOn == false)
        {
            ///<summary>
            /// Color randomization is inactive and set specific color dropdown is interactable
            /// </summary>
            colorDropdown.interactable = true;
            randomColorsStatus.text = "OFF";
            colorChangeTimer = colorChangeTimerReset;
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
        //TODO Look more into getting random element from array
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
        colorDropdown.AddOptions(colorNames);
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
    /// Disables color randomization when grayscaleToggle.isOn is true, renables it when set to false
    /// </summary>
    public void SetGrayscaleMode()
    {
        // TODO: 1. Take a look at if change to accessing Player Camera (which is a prefab in "final" version"),
        // TODO: 2. how is the camera accessed? if it's a prefab, does that need to be changed?
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (grayscaleToggle.isOn == true)
        {
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;
            randomColorsToggle.isOn = false;
            randomColorsToggle.interactable = false;
            grayscaleStatus.text = "ON";
            colorChangeTimer = colorChangeTimerReset;
        }
        else if (grayscaleToggle.isOn == false)
        {
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;
            randomColorsToggle.isOn = true;
            randomColorsToggle.interactable = true;
            grayscaleStatus.text = "OFF";
        }
    }

    public void SetDyslexicFont()
    {

        /*
         Different alternatives:
         1. Create an Array of ChangeFont and change UI elements that way
         2. Find out how to get access to object Tag and change it that way

            Best alternative should be finding the gameobject by tag,
            in ChangeFont class, see if changing the "textObject" variable
            from 'TextMeshProUGUI' to 'GameObject'.
            That's because there are UI elements in different scenes.
         */

        if (dyslexicFontToggle.isOn == true)
            {
                changeFont.ToDyslexic();
                dyslexicFontStatus.text = "ON";
            }
            else if (dyslexicFontToggle.isOn == false)
            {
                changeFont.ToRegular();
                dyslexicFontStatus.text = "OFF";
            }

    }

}
