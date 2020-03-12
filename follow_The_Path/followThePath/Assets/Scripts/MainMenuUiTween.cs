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

    [SerializeField]
    private Tweens.UIGroup[] mainMenuTweens;
    public Tweens.UIGroup[] MainMenuTweens { get { return mainMenuTweens; } }

    [SerializeField, Tooltip("The background image in the Main Menu")]
    private Image backgroundImage;

    [SerializeField]
    private TextMeshProUGUI instructionCanvasText;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void EnterSettingsMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, MainMenuTweens[0].YPosition), MainMenuTweens[0].TweenTime);
        MainMenuTweens[2].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[2].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[2].Alpha, MainMenuTweens[2].TweenTime);
    }
    public void ExitSettingsMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[0].TweenTime);
        MainMenuTweens[2].TweenTarget.DOAnchorPos(new Vector2(MainMenuTweens[2].XPosition, 0), MainMenuTweens[2].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[0].Alpha, MainMenuTweens[0].TweenTime);
    }

    public void EnterHowToPlayMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, MainMenuTweens[0].YPosition), MainMenuTweens[0].TweenTime);
        MainMenuTweens[1].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[1].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[1].Alpha, MainMenuTweens[1].TweenTime);
        instructionCanvasText.DOFade(1, MainMenuTweens[1].TweenTime);
    }

    public void ExitHowToPlayMenu()
    {
        MainMenuTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), MainMenuTweens[0].TweenTime);
        MainMenuTweens[1].TweenTarget.DOAnchorPos(new Vector2(0, MainMenuTweens[1].YPosition), MainMenuTweens[1].TweenTime);
        backgroundImage.DOFade(MainMenuTweens[0].Alpha, MainMenuTweens[0].TweenTime);
        instructionCanvasText.DOFade(0, MainMenuTweens[0].TweenTime);
    }
}
