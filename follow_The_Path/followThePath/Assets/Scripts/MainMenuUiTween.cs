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

    [SerializeField, Header("Tween-able Main Menu Objects"),Tooltip("Elements of tween-able objects")]
    private Tweens.UIGroup[] mainMenuTweens;
    // TODO the objects in mainMenuTweens are different objects. For clarify, declare them as different objects, instead of in an array. That will make all the code clearer.
    // Example: settings.TweenTarget.DOAnchorPos(...) instead of mainMenuTweens[2]...
    public Tweens.UIGroup[] MainMenuTweens { get { return mainMenuTweens; } } // TODO remove this, no other object should directly access the main menu tweens defined in this

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
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, MainMenuTweens[0].YPosition), MainMenuTweens[0].TweenTime);
        MainMenuTweens[2].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[2].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[2].Alpha, MainMenuTweens[2].TweenTime);
    }

    /// <summary>
    /// The Settings menu will move back to its initial position
    /// </summary>
    public void ExitSettingsMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[0].TweenTime);
        MainMenuTweens[2].TweenTarget.DOAnchorPos(new Vector2(MainMenuTweens[2].XPosition, 0), MainMenuTweens[2].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[0].Alpha, MainMenuTweens[0].TweenTime);
    }

    /// <summary>
    /// The How To Play menu will be the "active" object on screen
    /// </summary>
    public void EnterHowToPlayMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, MainMenuTweens[0].YPosition), MainMenuTweens[0].TweenTime);
        MainMenuTweens[1].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[1].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[1].Alpha, MainMenuTweens[1].TweenTime);
        instructionCanvasText.DOFade(1, MainMenuTweens[1].TweenTime);
    }

    /// <summary>
    /// The How To Play menu will move back to its initial position
    /// </summary>
    public void ExitHowToPlayMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[0].TweenTime);
        MainMenuTweens[1].TweenTarget.DOAnchorPos(new Vector2(0, MainMenuTweens[1].YPosition), MainMenuTweens[1].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[0].Alpha, MainMenuTweens[0].TweenTime);
        instructionCanvasText.DOFade(0, MainMenuTweens[0].TweenTime);
    }

    /// <summary>
    /// Used to make certain objects inside the dropdown menu transparent to indicate the object isn't interactable
    /// </summary>
    public void FadeDropdownObjects()
    {
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
