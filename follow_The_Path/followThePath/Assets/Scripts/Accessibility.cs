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


    //private bool dyslexicKeyValue;
    //private string dyslexicKey = "dyslexicKey";

    [SerializeField]
    private string currentFontKey;
    private string regularFontKey = "regularFontValue";
    private string dyslexicFontKey = "dyslexicFontValue";

    [SerializeField]
    private bool currentFontKeyValue;
    private bool regularFontKeyValue = false;
    private bool dyslexicFontKeyValue = true;

    readonly string USE_DYSLEXIC_FONT = "USE_DYSLEXIC_FONT";
    readonly string USE_REGULAR_FONT = "USE_REGULAR_FONT";
    bool useDyslexicFont;
    bool useRegularFont;

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

        //UxManager.Instance.DyslexicFontToggle.isOn = PlayerPrefsX.GetBool(currentFontKey);
        //PlayerPrefsX.GetBool(USE_DYSLEXIC_FONT);
        //PlayerPrefs.GetInt();
        /*
        if (useDyslexicFont = dyslexicFontKeyValue)
        {
            currentFont = DyslexicFont;
            currentScale = DyslexicFontScale;
            //UxManager.Instance.DyslexicFontToggle.isOn = true;
        }
        else if (useDyslexicFont = regularFontKeyValue)
        {
            currentFont = RegularFont;
            currentScale = RegularFontScale;
            //UxManager.Instance.DyslexicFontToggle.isOn = false;
        }
        */
        //UxManager.Instance.DyslexicFontToggle.isOn = PlayerPrefsX.GetBool(currentFontKey, currentFontKeyValue);
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

        // TODO 1a Make "Accessibility" remember what font is active: regular or dyslexic
        // TODO 2a by using PlayerPrefs, when the game loads, use the last saved value, if a PlayerPrefs hasn't been saved use default (which is Regular)
        //currentFont = RegularFont;
        //currentScale = RegularFontScale;

    }

    ///<summary>
    /// Creates a grayscale overlay "over" the player camera
    /// </summary>
    public void GrayscaleOverlay()
    { 
        // NOTE: Keep in mind to see if enabling an image effect on the camera is too costly 
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (UxManager.Instance.GrayscaleToggleOn)
        {
            // If grayscale toggle object is on, activate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;

            // Turns off Random color toggle and makes it non-interactable
            UxManager.Instance.RandomColorsToggle.isOn = false;
            UxManager.Instance.RandomColorsToggle.interactable = false;
            
            // Makes the Color drop down non-interactable
            UxManager.Instance.ColorDropdown.interactable = false;
            
            UxManager.Instance.GrayscaleStatus.text = "ON";

        }
        else
        {
            // If grayscale toggle object is NOT on, deactivate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;

            // Random color toggle can be interacted with again
            UxManager.Instance.RandomColorsToggle.interactable = true;
            // Color dropdown can be interacted with again
            UxManager.Instance.ColorDropdown.interactable = true;

            UxManager.Instance.GrayscaleStatus.text = "OFF";
        }
    }

    public void DyslexicFontMode(bool toggleOn)
    {

        if (toggleOn)
        {
            // If dyslexic toggle IS on, set the current font to the dyslexic font
            currentFont = DyslexicFont;
            currentScale = DyslexicFontScale;

            useDyslexicFont = PlayerPrefsX.GetBool(USE_DYSLEXIC_FONT);
            PlayerPrefsX.SetBool(USE_DYSLEXIC_FONT, useDyslexicFont);
            PlayerPrefs.Save();

            Debug.Log(useDyslexicFont);

        }
        else
        {
            // If dyslexic toggle object is not on, set current font to the regular font
            currentFont = RegularFont;
            currentScale = RegularFontScale;

            useDyslexicFont = PlayerPrefsX.GetBool(USE_REGULAR_FONT);
            //PlayerPrefsX.SetBool(USE_REGULAR_FONT, useDyslexicFont);
            PlayerPrefsX.SetBool(USE_REGULAR_FONT, useDyslexicFont);
            PlayerPrefs.Save();

            Debug.Log(useDyslexicFont);
        }

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