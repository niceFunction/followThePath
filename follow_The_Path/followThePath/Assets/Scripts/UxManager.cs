using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manager class used to affect colors on materials, change fonts or improve user experience
/// </summary>
public class UxManager : MonoBehaviour
{
    #region COLORS AND MATERIALS VARIABLES
    // The Materials are added to the references in the Inspector
    [SerializeField, Header("Colors & Materials"),Tooltip("Used to change color on the Tiles")]
    private Material tileMaterial;
    public Material TileMaterial { get { return tileMaterial; } }

    [SerializeField, Tooltip("Used to change the color of the Floor")]
    private Material floorMaterial;
    public Material FloorMaterial { get { return floorMaterial; } }

    /*
     The size of the color list is specified in the Inspector,
     in that array Name of the color and adding 2 colors for
     Tile and Floor can be added
    */
    [SerializeField, Tooltip("Creates an array for specifying name and color for Tiles/Floors")]
    private Colors.ColorGroup[] colorList;

    public Colors.ColorGroup[] ColorList { get { return colorList; }}
    #endregion

    #region SET SPECIFIC COLORS VARIABLES
    // colorDropDown and randomizeColorsToggle are used for specifying colors
    [SerializeField, Header("Specific Color"), Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    private TMP_Dropdown colorDropdown;
    public TMP_Dropdown ColorDropdown { get { return colorDropdown; } }
    #endregion

    #region RANDOM COLORS VARIABLES
    [SerializeField, Header("Random Color"), Tooltip("Randomly changes colors on the level when active")]
    private Toggle randomColorsToggle;
    public Toggle RandomColorsToggle { get { return randomColorsToggle; } }

    [Tooltip("Visual element that the user can see if randomizing colors are active or not")]
    [SerializeField]
    private TextMeshProUGUI randomColorsStatus;
    #endregion

    #region GRAYSCALE VARIABLES
    [SerializeField, Header("Grayscale"),Tooltip("Toggle grayscale 'overlay' on an off")]
    private Toggle grayscaleToggle;
    public Toggle GrayscaleToggle { get { return grayscaleToggle; } }

    [SerializeField, Tooltip("Visual element that the user can see if grayscale 'overlay' is active or not")]
    private TextMeshProUGUI grayscaleStatus;
    public TextMeshProUGUI GrayscaleStatus { get { return grayscaleStatus; } }
    #endregion

    #region FONT VARIABLES
    [SerializeField, Header("Dyslexic"),Tooltip("Object that toggles the font of text ON/OFF")]
    // Toggle UI object
    private Toggle dyslexicFontToggle;

    [SerializeField, Tooltip("Visual text element to show the player if the dyslexic font is active or not")]
    private TextMeshProUGUI dyslexicFontStatus;

    #endregion

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
        
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetSavedPlayerPrefs();

        dyslexicFontToggle.isOn = FontController.Instance.UseDyslexicFont;
        dyslexicFontStatus.text = FontController.Instance.UseDyslexicFont ? "ON" : "OFF";

        SetColorMode(ColorController.Instance.UseRandomColors);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Gets saved PlayerPrefs values and uses what ever was last chosen, this method should only be accessed in "UxManager"
    /// </summary>
    private void GetSavedPlayerPrefs()
    {
        RandomColorsToggle.isOn = ColorController.Instance.UseRandomColors;
        ColorDropdown.interactable = !ColorController.Instance.UseRandomColors;
        randomColorsStatus.text = ColorController.Instance.UseRandomColors ? "ON" : "OFF";

        if (ColorController.Instance.UseRandomColors)
        {
            MainMenuUiTween.Instance.FadeDropdownObjects();
        }
        else
        {
            MainMenuUiTween.Instance.FadeBackDropdownObjects();
        }
    }

    /// <summary>
    /// If randomizationToggle.isOn is set to true, colors are randomized
    /// if false, user can set specific color on materials
    /// </summary>
    public void SetColorMode(bool on)
    {
        ColorController.Instance.SetRandomColorMode(on);

        if (ColorController.Instance.UseRandomColors)
        {
            //SpecificColor.Instance.RemoveDropdownValue();
            // Color Randomization is active and set specific color dropdown is non-interactable
            //RandomColorsToggle.isOn = true;
            ColorDropdown.interactable = false;
            randomColorsStatus.text = "ON";
            // Fades dropdown objects to indicate the object is not interactable
            MainMenuUiTween.Instance.FadeDropdownObjects();
        }
        else
        {  
            // Color randomization is inactive and set specific color dropdown is interactable
            //RandomColorsToggle.isOn = false;
            ColorDropdown.interactable = true;
            randomColorsStatus.text = "OFF";
            // Fades the dropdown objects back to indicate the object can be interactable
            MainMenuUiTween.Instance.FadeBackDropdownObjects();
        }
        
        // If the grayscale toggle is active, make color dropdown not interactable
        if (GrayscaleToggle.isOn == true)
        {
            colorDropdown.interactable = false;
        }
    }

    public void SetSpecificColor(int index)
    {
        ColorController.Instance.SetSpecificColor(index);
    }

    /// <summary>
    /// Overlays an Image filter over the player camera
    /// </summary>
    public void SetGrayscaleOverlay()
    {
        // Update the status if Grayscale mode is active or not
        if (GrayscaleToggle.isOn)
        {
            GrayscaleStatus.text = "ON";
        }
        else
        {
            GrayscaleStatus.text = "OFF";
        }

        // Adds an "overlay" over the player camera, turning the screen in different shades of gray
        Accessibility.Instance.GrayscaleOverlay();
    }

    /// <summary>
    /// Changes the font to dyslexic when on, changes to regular font when off
    /// </summary>
    public void SetDyslexicFont(bool on)
    { 
        FontController.Instance.SetDyslexicFontMode(on);

        dyslexicFontToggle.isOn = FontController.Instance.UseDyslexicFont;
        dyslexicFontStatus.text = FontController.Instance.UseDyslexicFont ? "ON" : "OFF";
    }
}