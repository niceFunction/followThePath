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
    public Image BackhroundImage { get { return backgroundImage; } }

    public static GameUiTween Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnterPauseMenu()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(GameUiTweens[0].XPosition, 0), GameUiTweens[0].TweenTime);
        GameUiTweens[2].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[2].TweenTime);
    }

    public void ExitPauseMenu()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[0].TweenTime);
        GameUiTweens[2].TweenTarget.DOAnchorPos(new Vector2(GameUiTweens[2].XPosition, 0), GameUiTweens[2].TweenTime);
    }

    // What will happen to the UI on a Game Over?
    public void OnGameOver()
    {
        GameUiTweens[1].TweenTarget.DOScale(GameUiTweens[1].Scale, GameUiTweens[1].TweenTime);
        BackhroundImage.DOFade(GameUiTweens[1].Alpha, GameUiTweens[1].TweenTime);
    }
    
}
