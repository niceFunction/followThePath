using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

/// <summary>
/// Same as "MainMenuUiTween" but dedicated for the game scene
/// </summary>
public class GameUiTween : MonoBehaviour
{

    [SerializeField]
    private Tweens.UIGroup[] gameUiTweens;
    public Tweens.UIGroup[] GameUiTweens { get { return gameUiTweens; } }

    [SerializeField, Tooltip("The background image in the Game scene")]
    private Image backgroundImage;
    public Image BackgroundImage { get { return backgroundImage; } }

    public static GameUiTween Instance { get; private set; }

    public void EnterPauseMenu()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(GameUiTweens[0].XPosition, 0), GameUiTweens[0].TweenTime);
        GameUiTweens[1].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[1].TweenTime).OnComplete(() => { Time.timeScale = 0; }); 
        BackgroundImage.DOFade(GameUiTweens[1].Alpha, GameUiTweens[1].TweenTime);
    }

    public void ExitPauseMenu()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[0].TweenTime);
        GameUiTweens[1].TweenTarget.DOAnchorPos(new Vector2(GameUiTweens[1].XPosition, 0), GameUiTweens[1].TweenTime);

        BackgroundImage.DOFade(GameUiTweens[0].Alpha, GameUiTweens[0].TweenTime);
    }

    // What will happen to the UI on a Game Over?
    public void OnGameOver()
    {
        //GameUiTweens[2].TweenTarget.DOScale(GameUiTweens[2].Scale, GameUiTweens[2].TweenTime).OnComplete(() =>
        //{ GameManager.Instance.GameStatus(); });
        //GameUiTweens[2].TweenTarget.DOScale(GameUiTweens[2].Scale, GameUiTweens[2].TweenTime);
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, GameUiTweens[0].YPosition), GameUiTweens[2].TweenTime);
        GameUiTweens[2].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[2].TweenTime).OnComplete(() => 
        { Time.timeScale = 0; });

        BackgroundImage.DOFade(GameUiTweens[2].Alpha, GameUiTweens[2].TweenTime);
    }    
}
