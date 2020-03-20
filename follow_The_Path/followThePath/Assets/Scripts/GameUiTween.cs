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

    /// <summary>
    /// When pressing the "Pause" button, Pause Menu will slide in
    /// </summary>

    public void Start()
    {
        DOTween.Clear(true);
    }
    public void EnterPauseMenu()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, GameUiTweens[0].YPosition), GameUiTweens[0].TweenTime);
        // When the "animation" is complete, the scale of time will be set to 0
        GameUiTweens[1].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[1].TweenTime).OnComplete(() => 
        { Time.timeScale = 0; }); 
        BackgroundImage.DOFade(GameUiTweens[1].Alpha, GameUiTweens[1].TweenTime);
    }

    /// <summary>
    /// When pressing the "Continue" button in the Pause Menu, the Pause Menu will move away
    /// </summary>
    public void ExitPauseMenu()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[0].TweenTime);
        GameUiTweens[1].TweenTarget.DOAnchorPos(new Vector2(GameUiTweens[1].XPosition, 0), GameUiTweens[1].TweenTime);

        BackgroundImage.DOFade(GameUiTweens[0].Alpha, GameUiTweens[0].TweenTime);
    }

    // What will happen to the UI on a Game Over?
    /// <summary>
    /// When time runs out, the "Game OVer" Menu will appear on the screen
    /// </summary>
    public void OnGameOver()
    {
        GameUiTweens[0].TweenTarget.DOAnchorPos(new Vector2(0, GameUiTweens[0].YPosition), GameUiTweens[2].TweenTime);
        // When the animation is complete, the time scale will be set to 0
        GameUiTweens[2].TweenTarget.DOAnchorPos(new Vector2(0, 0), GameUiTweens[2].TweenTime).OnComplete(() => 
        { Time.timeScale = 0; });

        BackgroundImage.DOFade(GameUiTweens[2].Alpha, GameUiTweens[2].TweenTime);
    }    
}
