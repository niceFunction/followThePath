using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

/// <summary>
/// Uses DOTween to make MainMenu UI elements more interesting
/// </summary>
public class MainMenuUiTween : MonoBehaviour
{
    // TODO the objects in mainMenuTweens are different objects. For clarify, declare them as different objects, instead of in an array. That will make all the code clearer.
    // Example: settings.TweenTarget.DOAnchorPos(...) instead of mainMenuTweens[2]...

    [SerializeField, Header("Tween-able Main Menu Objects")]
    private Tweens.MainMenu mainMenuObject;
    public Tweens.MainMenu MainMenuObject { get { return mainMenuObject; } }

    [SerializeField]
    private Tweens.HowToPlayMenu howToPlayMenuObject;
    public Tweens.HowToPlayMenu HowToPlayMenuObject { get { return howToPlayMenuObject; } }

    [SerializeField]
    private Tweens.SettingsMenu settingsMenuObject;
    public Tweens.SettingsMenu SettingsMenuObject { get { return settingsMenuObject; } }

    [SerializeField, Header("Background Image"),Tooltip("The background image in the Main Menu")]
    private Image backgroundImage;

    [SerializeField, Header("How To Play instructions"),Tooltip("The instructions in the 'How To Play' menu")]
    private TextMeshProUGUI instructionCanvasText;

    [SerializeField, Header("Dropdown menu items"), Tooltip("Objects found in the dropdown menu")]
    private UiItems.DropdownGroup dropdownItemGroup;

    [SerializeField, Header("Toggle items"), Tooltip("Certain objects found in a Toggle object")]
    private UiItems.ToggleGroup[] toggleItemsGroup; // TODO same as for mainMenuTweens. Also ,this seems to always be empty.

    public static MainMenuUiTween Instance { get; private set; }

    private void Awake()
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
    }

    /// <summary>
    /// The Settings menu will be the "active" object on screen
    /// </summary>
    public void EnterSettingsMenu()
    {
        MainMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, MainMenuObject.YPosition), MainMenuObject.TweenTime);
        SettingsMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, 0), SettingsMenuObject.TweenTime);

        backgroundImage.DOFade(SettingsMenuObject.Alpha, SettingsMenuObject.TweenTime);

    }

    /// <summary>
    /// The Settings menu will move back to its initial position
    /// </summary>
    public void ExitSettingsMenu()
    {
        MainMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuObject.TweenTime);
        SettingsMenuObject.TweenTarget.DOAnchorPos(new Vector2(SettingsMenuObject.XPosition, 0), SettingsMenuObject.TweenTime);

        backgroundImage.DOFade(MainMenuObject.Alpha, MainMenuObject.TweenTime);
    }

    /// <summary>
    /// The How To Play menu will be the "active" object on screen
    /// </summary>
    public void EnterHowToPlayMenu()
    {
        MainMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, MainMenuObject.YPosition), MainMenuObject.TweenTime);
        HowToPlayMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, 0), HowToPlayMenuObject.TweenTime);

        backgroundImage.DOFade(HowToPlayMenuObject.Alpha, HowToPlayMenuObject.TweenTime);
        instructionCanvasText.DOFade(1, HowToPlayMenuObject.TweenTime);

    }

    /// <summary>
    /// The How To Play menu will move back to its initial position
    /// </summary>
    public void ExitHowToPlayMenu()
    {
        MainMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuObject.TweenTime);
        HowToPlayMenuObject.TweenTarget.DOAnchorPos(new Vector2(0, HowToPlayMenuObject.YPosition), HowToPlayMenuObject.TweenTime);

        backgroundImage.DOFade(MainMenuObject.Alpha, MainMenuObject.TweenTime);
        instructionCanvasText.DOFade(0, MainMenuObject.TweenTime);
    }

    /// <summary>
    /// Used to make certain objects inside the dropdown menu transparent to indicate the object isn't interactable
    /// </summary>
    public void FadeDropdownObjects()
    {
        //TODO Personal reminder: rename dropdownItemGroup to something like "specificColor"?
        dropdownItemGroup.DropdownText.DOFade(dropdownItemGroup.Alpha, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownArrowImage.DOFade(dropdownItemGroup.Alpha, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownCaptionImage.DOFade(dropdownItemGroup.Alpha, dropdownItemGroup.TweenTime);
    }

    /// <summary>
    ///  Used to make certain objects inside the dropdown menu transparent to indicate the object can be interacted with again
    /// </summary>
    public void FadeBackDropdownObjects()
    {
        dropdownItemGroup.DropdownText.DOFade(1, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownArrowImage.DOFade(1, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownCaptionImage.DOFade(1, dropdownItemGroup.TweenTime);
    }

    /// <summary>
    /// Fades the toggle object for "Random Level Color" away to indicate the object can't be interacted with
    /// </summary>
    public void FadeRandomColorToggleObject()
    {
        //TODO Personal reminder: rename FadeRandomColorToggleObject to something easier to remember?
        toggleItemsGroup[0].ToggleActiveText.DOFade(toggleItemsGroup[0].Alpha, toggleItemsGroup[0].TweenTime);
        toggleItemsGroup[0].ToggleBackgroundImage.DOFade(toggleItemsGroup[0].Alpha, toggleItemsGroup[0].TweenTime);
    }

    /// <summary>
    /// Fades the toggle object for "Random Level Color" back to indicate the object can be interacted with
    /// </summary>
    public void FadeBackRandomColorToggleObject()
    {
        toggleItemsGroup[0].ToggleActiveText.DOFade(1, toggleItemsGroup[0].TweenTime);
        toggleItemsGroup[0].ToggleBackgroundImage.DOFade(1, toggleItemsGroup[0].TweenTime);
    }
}
