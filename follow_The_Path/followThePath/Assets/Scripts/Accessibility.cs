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

    public delegate void GrayscaleHandler(Toggle grayscaleToggle, string grayscaleStatus);
    public event GrayscaleHandler onGrayscaleMode;

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
    }

    /// <summary>
    /// Gets the saved PlayerPrefs values in "Accessibility", this method should only be accessed in "Accessibility"
    /// </summary>
    private void GetSavedPlayerPrefs()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (ColorController.Instance.UseGrayscaleMode)
        {
            // If grayscale toggle object is on, activate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;
            UxManager.Instance.GrayscaleToggle.isOn = true;

            // Fades certain UI objects to indicate the object is not interactable
            MainMenuUiTween.Instance.FadeDropdownObjects();
            MainMenuUiTween.Instance.FadeRandomColorToggleObject();
        }
        else
        {
            // If grayscale toggle object is NOT on, deactivate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;
            UxManager.Instance.GrayscaleToggle.isOn = false;

            // Fades caertain UI objects back to indicate the object can be interactable
            MainMenuUiTween.Instance.FadeBackDropdownObjects();
            MainMenuUiTween.Instance.FadeBackRandomColorToggleObject();
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
            ColorController.Instance.SetUseGrayscaleOverlay();
        }
        else
        {
            ColorController.Instance.SetRandomColorMode(true);
        }
        

        if (ColorController.Instance.UseGrayscaleMode)
        {
            // If grayscale toggle object is on, activate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = true;

            // Turns off Random color toggle and makes it non-interactable
            UxManager.Instance.RandomColorsToggle.isOn = false;
            UxManager.Instance.RandomColorsToggle.interactable = false;
            // Fades certain UI objects to indicate the object is not interactable
            MainMenuUiTween.Instance.FadeDropdownObjects();
            MainMenuUiTween.Instance.FadeRandomColorToggleObject();

            // Makes the Color drop down non-interactable
            UxManager.Instance.ColorDropdown.interactable = false;
            ColorController.Instance.StopRandomColor();
        }
        else
        {
            // If grayscale toggle object is NOT on, deactivate grayscale camera overlay.
            playerCamera.GetComponent<GrayscaleCamera>().enabled = false;

            // Random color toggle can be interacted with again
            UxManager.Instance.RandomColorsToggle.interactable = true;
            // Color dropdown can be interacted with again
            UxManager.Instance.ColorDropdown.interactable = true;
            // Fades caertain UI objects back to indicate the object can be interactable
            MainMenuUiTween.Instance.FadeBackDropdownObjects();
            MainMenuUiTween.Instance.FadeBackRandomColorToggleObject();
        }
    }

    public void DyslexicFontMode(bool toggleOn)
    {
        FontController.Instance.SetDyslexicFontMode(toggleOn);

        
        /*
        This null check is important, because if no listeners are registered, 
        it will result in an NPE.
        */
    }
}