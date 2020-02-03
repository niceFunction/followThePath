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
    [Space(5)]
    [Tooltip("Toggle grayscale 'overlay' on an off")]
    [SerializeField]
    private Toggle grayscaleToggle;
    public Toggle GrayscaleToggle { get { return grayscaleToggle; } }
    public bool GrayscaleToggleOn { get { return grayscaleToggle.isOn; } }

    [Tooltip("Visual element that the user can see if grayscale 'overlay' is active or not")]
    [SerializeField]
    private TextMeshProUGUI grayscaleStatus;

    [SerializeField]
    // Toggle UI object
    private Toggle dyslexicFontToggle;
    public bool DyslexicFontToggleOn { get { return dyslexicFontToggle.isOn; } }

    [SerializeField]
    // Visual text element to show the player if the dyslexic font is active or not
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


    // Currently used to affect font size but can have other areas to be used
    private TextMeshPro TMP;

    // Used to access "Grayscale Camera" component on MainCamera
    private GameObject playerCamera;

    private void Awake()
    {
        currentFont = RegularFont;
        currentScale = RegularFontScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>
    /// Used to turn "Grayscale Mode" on and off, user can still set specific color.
    /// Disables color randomization when GrayscaleToggle.isOn is true, renables it when set to false
    /// </summary>
    public void SetGrayscaleMode()
    {
        // TODO 3a Take a look at if change to accessing Player Camera (which is a prefab in "final" version"),
        // TODO 3b how is the camera accessed? if it's a prefab, does that need to be changed?
        /*
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
        */
    }

    public void SetDyslexicFont()
    {
        /*
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
        */
    }
}
