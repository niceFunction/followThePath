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
    public Tweens.UIGroup[] MainMenuTweens { get { return mainMenuTweens; } }

    [SerializeField, Header("Background Image"),Tooltip("The background image in the Main Menu")]
    private Image backgroundImage;

    [SerializeField, Header("How To Play instructions"),Tooltip("The instructions in the 'How To Play' menu")]
    private TextMeshProUGUI instructionCanvasText;

    [SerializeField, Header("Dropdown menu items"), Tooltip("Objects found in the dropdown menu")]
    private DropdownItems.DropdownGroup dropdownItemGroup;

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

    // Start is called before the first frame update
    void Start()
    {

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
}
