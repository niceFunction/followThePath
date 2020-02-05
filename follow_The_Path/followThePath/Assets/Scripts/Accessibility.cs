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

    public static Accessibility Instance { get; set; }
    public static void newUxActive()
    {
        if (onActiveUX != null)
        {
            onActiveUX();
        }
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

        currentFont = RegularFont;
        currentScale = RegularFontScale;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    ///<summary>
    /// Creates a grayscale overlay "over" the player camera
    /// </summary>
    public void GrayscaleOverlay()
    {
        
        // NOTE: Keep in mind to see if enabling an image effect on the camera is too costly 
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (ColorManager.Instance.GrayscaleToggleOn)
        {
            // If grayscale toggle object is on, activate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;

            ColorManager.Instance.RandomColorsToggle.isOn = false;
            ColorManager.Instance.RandomColorsToggle.interactable = false;
            ColorManager.Instance.GrayscaleStatus.text = "ON";
        }
        else
        {
            // If grayscale toggle object is NOT on, deactivate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;

            ColorManager.Instance.RandomColorsToggle.interactable = true;
            ColorManager.Instance.GrayscaleStatus.text = "OFF";
        }
    }

    public void DyslexicFontMode()
    {
        
        //if (colorManager.DyslexicFontToggleOn)
        if (ColorManager.Instance.DyslexicFontToggleOn)
        {
            // If dyslexic toggle object IS on, set the current font to the dyslexic font
            currentFont = DyslexicFont;
            currentScale = DyslexicFontScale;
            ColorManager.Instance.DyslexicFontStatus.text = "ON";
            //PlayerPrefs.Save();
        }
        else
        {
            // If dyslexic toggle object is not on, set current font to the regular font
            currentFont = RegularFont;
            currentScale = RegularFontScale;
            ColorManager.Instance.DyslexicFontStatus.text = "OFF";
            //PlayerPrefs.Save();
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
        //Debug.Log("Current font is: " + currentFont); // Uncomment to debug what font is active
    }
}