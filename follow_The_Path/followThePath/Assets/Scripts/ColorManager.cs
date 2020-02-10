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
    /*
    public delegate void UxEventHandler();
    public static event UxEventHandler onActiveUX;
    */
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
    public Material TileMaterial { get { return tileMaterial; } }


    [Tooltip("Used to change the color of the Floor")]
    [SerializeField]
    private Material floorMaterial;
    public Material FloorMaterial { get { return floorMaterial; } }


    [Space(5)]
    /// <summary>
    /// The Color arrays size are specified in the Inspector.
    /// In this case, colors of the Rainbow and the colors for the floor
    /// is in a darker hue.
    /// </summary>
    [SerializeField]
    [Tooltip("Creates an Array of Colors for Tiles")]
    private Color[] tileColorList;
    public Color[] TileColorList { get { return tileColorList; } }


    [SerializeField]
    [Tooltip("Create an Array of Colors for Floors")]
    private Color[] floorColorList;
    public Color[] FloorColorList { get { return floorColorList; } }

    // Used to get/set the current Color
    private Color currentTileColor;
    private Color currentFloorColor;
    #endregion

    #region SET SPECIFIC COLORS VARIABLES
    [Space(5)]
    // colorDropDown and randomizeColorsToggle are used for specifying colors
    // NOTE: Save "colorDropdown" and "ColorDropdown"
    [Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    [SerializeField]
    private TMP_Dropdown colorDropdown;
    #endregion

    #region RANDOM COLORS VARIABLES
    [Tooltip("Randomly changes colors on the level when active")]
    [SerializeField]
    private Toggle randomColorsToggle;

    public Toggle RandomColorsToggle { get { return randomColorsToggle; } }

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

    public TextMeshProUGUI GrayscaleStatus { get { return grayscaleStatus; } }
    #endregion

    #region FONT VARIABLES
    [Space(5)]
    [SerializeField]
    // Toggle UI object
    private Toggle dyslexicFontToggle;

    [SerializeField]
    // Visual text element to show the player if the dyslexic font is active or not
    private TextMeshProUGUI dyslexicFontStatus;

    #endregion

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    

    public static ColorManager Instance { get; private set; } 
/*
    public static void newUxActive()
    {
        if (onActiveUX != null)
        {
            onActiveUX();
        }
    }
*/

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
    }

    // Start is called before the first frame update
    void Start()
    {
        // To be removed (find out if it is some or all of them
        currentTileColor = tileMaterial.color;
        currentFloorColor = floorMaterial.color;

        SetColorMode();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region SET SPECIFIC COLOR METHODS
    /// <summary>
    /// If randomizationToggle.isOn is set to true, colors are randomized
    /// if false, user can set specific color on materials
    /// </summary>
    public void SetColorMode()
    {

        if (randomColorsToggle.isOn)
        {
            ///<summary>
            /// Color Randomization is active and set specific color dropdown is non-interactable
            /// </summary>

            // TODO Add new random color method here
            RandomColor.Instance.StartRandomColor();
            //StartCoroutine(MakeRandomColor());
            colorDropdown.interactable = false;
            randomColorsStatus.text = "ON";
        }
        else
        {
            ///<summary>
            /// Color randomization is inactive and set specific color dropdown is interactable
            /// </summary>
            RandomColor.Instance.StopRandomColor();
            //StopCoroutine(MakeRandomColor());
            colorDropdown.interactable = true;
            randomColorsStatus.text = "OFF";
        }

        // if the grayscale toggle is active, make color dropdown not interactable
        if (GrayscaleToggle.isOn == true)
        {
            colorDropdown.interactable = false;
        }

    }

    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>

    public void SetSpecificColor()
    {
        SpecificColor.Instance.ParticularColor(colorDropdown.value);
    }

    #endregion

    // Accessibility Methods
    public void SetGrayscaleOverlay()
    {
        Accessibility.Instance.GrayscaleOverlay();
    }

    public void SetDyslexicFont()
    {
        // Update the GUI
        if (dyslexicFontToggle.isOn)
        {
            dyslexicFontStatus.text = "ON";
        }
        else
        {
            dyslexicFontStatus.text = "OFF";
        }
            // Update all text
        Accessibility.Instance.DyslexicFontMode(dyslexicFontToggle.isOn);
    }
}