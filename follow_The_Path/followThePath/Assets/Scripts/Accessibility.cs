using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Class that's responsible for making the game more accessibile 
/// </summary>
public class Accessibility : MonoBehaviour
{

    //PlayerPrefs set bool: http://wiki.unity3d.com/index.php?title=BoolPrefs&oldid=18094

    public delegate void UxEventHandler();
    public static event UxEventHandler onActiveUX;

    public delegate void ChangeFontHandler(TMP_FontAsset newFont, float scaleFont);
    public event ChangeFontHandler onChangeFont;

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

    // Currently used to affect font size but can have other areas to be used
    private TextMeshPro TMP;

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    // If the DyslexicToggle.isON is either true/false, it saves the changes when the application is shut down
    readonly string USE_DYSLEXIC_FONT = "USE_DYSLEXIC_FONT";
    bool useDyslexicFont;

    readonly string USE_GRAYSCALE_MODE = "USE_GRAYSCALE_MODE";
    bool useGrayscalemode;

    public static Accessibility Instance { get; set; }
    public static void newUxActive()
    {
        if (onActiveUX != null)
        {
            onActiveUX();
        }
    }

    private void Start()
    {
        GetSavedPlayerPrefs();
    }

    private void Awake()
    {
        if(Instance == null)
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

    /// <summary>
    /// Gets the saved PlayerPrefs values in "Accessibility", this method should only be accessed in "Accessibility"
    /// </summary>
    private void GetSavedPlayerPrefs()
    {
        useDyslexicFont = PlayerPrefsX.GetBool(USE_DYSLEXIC_FONT);
        useGrayscalemode = PlayerPrefsX.GetBool(USE_GRAYSCALE_MODE);

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (useDyslexicFont)
        {
            currentFont = DyslexicFont;
            currentScale = DyslexicFontScale;
            UxManager.Instance.DyslexicFontToggle.isOn = true;
        }
        else
        {
            currentFont = RegularFont;
            currentScale = RegularFontScale;
            UxManager.Instance.DyslexicFontToggle.isOn = false;
        }

        if (useGrayscalemode)
        {
            // If grayscale toggle object is on, activate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;
            UxManager.Instance.GrayscaleToggle.isOn = true;
            StopCoroutine(RandomColor.Instance.InitiateRandomColors);
        }
        else
        {
            // If grayscale toggle object is NOT on, deactivate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;
            UxManager.Instance.GrayscaleToggle.isOn = false;
        }
    }

    ///<summary>
    /// Creates a grayscale overlay "over" the player camera
    /// </summary>
    public void GrayscaleOverlay()
    { 
        // NOTE: Keep in mind to see if enabling an image effect on the camera is too costly 
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (UxManager.Instance.GrayscaleToggle.isOn)
        {
            useGrayscalemode = true;

            // If grayscale toggle object is on, activate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;

            // Turns off Random color toggle and makes it non-interactable
            UxManager.Instance.RandomColorsToggle.isOn = false;
            UxManager.Instance.RandomColorsToggle.interactable = false;
            
            // Makes the Color drop down non-interactable
            UxManager.Instance.ColorDropdown.interactable = false;
            StopCoroutine(RandomColor.Instance.InitiateRandomColors);
        }
        else
        {
            useGrayscalemode = false;
            // If grayscale toggle object is NOT on, deactivate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;

            // Random color toggle can be interacted with again
            UxManager.Instance.RandomColorsToggle.interactable = true;
            // Color dropdown can be interacted with again
            UxManager.Instance.ColorDropdown.interactable = true;
        }

        PlayerPrefsX.SetBool(USE_GRAYSCALE_MODE, useGrayscalemode);
    }

    public void DyslexicFontMode(bool toggleOn)
    {

        if (toggleOn)
        {
            // If dyslexic toggle IS on, set the current font to the dyslexic font
            useDyslexicFont = true;
            currentFont = DyslexicFont;
            currentScale = DyslexicFontScale;
        }
        else
        {
            // If dyslexic toggle object is not on, set current font to the regular font
            useDyslexicFont = false;
            currentFont = RegularFont;
            currentScale = RegularFontScale;
        }

        PlayerPrefsX.SetBool(USE_DYSLEXIC_FONT, useDyslexicFont);
        PlayerPrefs.Save();

        /*
        This null check is important, because if no listeners are registered, 
        it will result in an NPE.
        */
        if (onChangeFont != null) // 
        {
            // Inform text objects with ChangeFont class attached to update to the new font
            onChangeFont.Invoke(currentFont, currentScale);
        }
    }
}