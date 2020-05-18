using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

// TODO this object in Scene lies outside the GUI objects, but manipulates them.

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

    #endregion

    #region SET SPECIFIC COLORS VARIABLES
    // colorDropDown and randomizeColorsToggle are used for specifying colors
    [SerializeField, Header("Specific Color"), Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    private TMP_Dropdown colorDropdown;
    public TMP_Dropdown ColorDropdown { get { return colorDropdown; } }
    #endregion


    #region GRAYSCALE VARIABLES
    [SerializeField, Header("Grayscale"),Tooltip("Toggle grayscale 'overlay' on an off")]
    private Toggle grayscaleToggle;
    public Toggle GrayscaleToggle { get { return grayscaleToggle; } }

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

        SetColorMode(ColorController.Instance.UseRandomColors);
    }


    /// <summary>
    /// Gets saved PlayerPrefs values and uses what ever was last chosen, this method should only be accessed in "UxManager"
    /// </summary>
    private void GetSavedPlayerPrefs()
    {
        //RandomColorsToggle.isOn = ColorController.Instance.UseRandomColors;
       // ColorDropdown.interactable = !ColorController.Instance.UseRandomColors;
      //  randomColorsStatus.text = ColorController.Instance.UseRandomColors ? "ON" : "OFF";

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
     //   ColorController.Instance.SetRandomColorMode(on);

        if (ColorController.Instance.UseRandomColors)
        {
            ColorDropdown.interactable = false;
            // Fades dropdown objects to indicate the object is not interactable
            MainMenuUiTween.Instance.FadeDropdownObjects();
        }
        else
        {  

            // Fades the dropdown objects back to indicate the object can be interactable
            MainMenuUiTween.Instance.FadeBackDropdownObjects();
        }
    }
}