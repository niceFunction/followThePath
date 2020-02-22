using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manager class used to affect colors on materials, change fonts or improve user experience
/// </summary>
public class UxManager : MonoBehaviour
{
    public delegate void ChangeFontHandler(TMP_FontAsset newFont, float scaleFont);
    public event ChangeFontHandler onChangeFont;


    /*
     * For PlayerPrefs
     - Create private int(s)
     - or
     - Create a struct?

        int colorValue // Saves if either random or specific is active
        // if (randomValue == 1) Random Colors are active
        // if (randomValue == 0) Random Colors aren't active but Specufic Color is
      
        int colorListValue // Refers to specific colors
        // Take the index value from SpecificColor or the ColorList?
        // Should every color in the list of ParticularColor have its own int value?

        int grayscaleValue // Saves the grayscale overlay, disables random colors or specific colors
        int accessibleValue // Saves if changing font is on
    */

    #region COLORS AND MATERIALS VARIABLES
    // The Materials are added to the references in the Inspector
    [Tooltip("Used to change color on the Tiles")]
    [SerializeField]
    private Material tileMaterial;
    public Material TileMaterial { get { return tileMaterial; } }

    [Tooltip("Used to change the color of the Floor")]
    [SerializeField]
    private Material floorMaterial;
    public Material FloorMaterial { get { return floorMaterial; } }


    [Space(5)]
    /*
     The size of the color list is specified in the Inspector,
     in that array Name of the color and adding 2 colors for
     Tile and Floor can be added
    */
    [SerializeField]
    [Tooltip("Creates an array for specifying name and color for Tiles/Floors")]
    private Colors.ColorGroup[] colorList;

    public Colors.ColorGroup[] ColorList { get { return colorList; }}

    // Used to get/set the current Color
    private Color currentTileColor;
    private Color currentFloorColor;
    #endregion

    #region SET SPECIFIC COLORS VARIABLES
    [Space(5)]
    // colorDropDown and randomizeColorsToggle are used for specifying colors
    [Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    [SerializeField]
    private TMP_Dropdown colorDropdown;
    public TMP_Dropdown ColorDropdown { get { return colorDropdown; } }
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
    public Toggle DyslexicFontToggle { get { return dyslexicFontToggle; } }

    [SerializeField]
    // Visual text element to show the player if the dyslexic font is active or not
    private TextMeshProUGUI dyslexicFontStatus;

    #endregion

    private bool accessibilityKeyValue;

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    public static UxManager Instance { get; private set; } 

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
        

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTileColor = TileMaterial.color;
        currentFloorColor = FloorMaterial.color;
        
        SetColorMode();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// If randomizationToggle.isOn is set to true, colors are randomized
    /// if false, user can set specific color on materials
    /// </summary>
    public void SetColorMode()
    {
        if (RandomColorsToggle.isOn)
        {
            // Color Randomization is active and set specific color dropdown is non-interactable
            RandomColor.Instance.StartRandomColor();
            ColorDropdown.interactable = false;
            randomColorsStatus.text = "ON";
        }
        else
        {
            // Color randomization is inactive and set specific color dropdown is interactable
            RandomColor.Instance.StopRandomColor();
            ColorDropdown.interactable = true;
            randomColorsStatus.text = "OFF";
        }

        // If the grayscale toggle is active, make color dropdown not interactable
        if (GrayscaleToggle.isOn == true)
        {
            colorDropdown.interactable = false;
        }
    }

    /// <summary>
    /// Overlays an Image filter over the player camera
    /// </summary>
    public void SetGrayscaleOverlay()
    {
        Accessibility.Instance.GrayscaleOverlay();
    }

    public void SetDyslexicFont()
    {
        // Update the GUI
        if (DyslexicFontToggle.isOn)
        {
            dyslexicFontStatus.text = "ON";
        }
        else
        {
            dyslexicFontStatus.text = "OFF";
        }
        // Update all text objects
        Accessibility.Instance.DyslexicFontMode(DyslexicFontToggle.isOn);
    }
}