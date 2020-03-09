using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuUiTween : MonoBehaviour
{
    // MainMenu starting position
    // MainMenu pos: X = 0, Y = 3700
    // SettingsMenu pos: X = 2100, Y = 0
    // HowtoPlay pos: X = 0, Y = -4860

    // "Appear on screen position" (usually at 0,0 except how to play button)
    // Ignore HowtoPlay back button appearance pos: X = 0, Y = -858

    // Background image alpha
    // Main menu: 175
    // Settings Menu: 200
    // How to Play Menu: 0

    [SerializeField, Tooltip("The grouped Main Menu items")]
    private RectTransform mainMenu, settingsMenu, howToPlayMenu;

    [SerializeField, Tooltip("The background image in the Main Menu")]
    private Image backgroundImage;

    [SerializeField, Tooltip("The time it takes for the tween to happen"),Range(0.01f, 1)]
    private float tweenTime = 0.01f;

    [SerializeField, Tooltip("Quicker version of how long tween time happens"), Range(0.01f, 0.75f)]
    private float fastTweenTime = 0.01f;

    private int mainMenuAlpha = 175;

    // Start is called before the first frame update
    void Start()
    {
        //mainMenu.DOAnchorPos(Vector2.zero, tweenTime);
    }
    
    public void EnterSettingsMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 5000), tweenTime);
        settingsMenu.DOAnchorPos(new Vector2(0, 0), tweenTime);
        backgroundImage.DOFade(0.78f, tweenTime);
    }
    public void ExitSettingsMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), tweenTime);
        settingsMenu.DOAnchorPos(new Vector2(5940, 0), fastTweenTime);
        backgroundImage.DOFade(0.69f, tweenTime);
    }

    public void EnterHowToPlayMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 4648), tweenTime);
        howToPlayMenu.DOAnchorPos(new Vector2(0, 0), fastTweenTime);
        backgroundImage.DOFade(0, tweenTime);
    }

    public void ExitHowToPlayMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), tweenTime);
        howToPlayMenu.DOAnchorPos(new Vector2(0, -4860), tweenTime);
        backgroundImage.DOFade(0.69f, tweenTime);
    }
}
