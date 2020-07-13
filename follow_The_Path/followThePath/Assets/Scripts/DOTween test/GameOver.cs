using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    //TODO GameOver 1: look into breaking things out from "GameManager" that's related to "Game Over"
    //TODO GameOver 2: And call(?) those variables in "OnGameOver" from "GameManger" instead (maybe?)
    #region Game Over Components

    [SerializeField, Tooltip("Variables for Game Over state")]
    private GameOverItems.GameOverGroup gameOverItemGroup;
    public GameOverItems.GameOverGroup GameOverItemGroup { get { return gameOverItemGroup; } }

    [SerializeField, Tooltip("Sets the 'setBackgroundTimer' to 'backgroundTimer', (USED FOR TESTING)")]
    private float setBackgroundTimer; // SAVE THIS VARIABLE
    //public float SetBackgroundTimer { get { return setBackgroundTimer; } }

    // Resets the 'Game Over' timer
    private float resetGameOverTimer; // SAVE THIS VARIABLE
    //public float ResetGameOverTimer { get { return resetGameOverTimer; } }

    #endregion

    // Related to Tweens
    private Tween gameOverTween;

    //[SerializeField, Tooltip("Determine if it's Game Over or not"), Header("Related to Tweens")]
    //private bool showGameOver;

    [SerializeField, Tooltip("How much time will pass until the 'gameOverMenuObject' pops up?"), Range(0.01f, 1f)]
    private float gameOverTweenDuration;
    // Start is called before the first frame update

    public static GameOver Instance { get; private set; }

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

    public void SetTimers()
    {
        setBackgroundTimer = gameOverItemGroup.BackgroundTimer;
        resetGameOverTimer = gameOverItemGroup.GameOverTimer;
    }

    public void GameStatus()
    {
        if (GameManager.Instance.Ball.RB.velocity.magnitude < gameOverItemGroup.MinimumSpeed)
        {
            gameOverItemGroup.BackgroundTimer -= Time.deltaTime;
            if(gameOverItemGroup.BackgroundTimer <= 0)
            {
                gameOverItemGroup.BackgroundTimer = 0;
                gameOverItemGroup.GameOverTimerObject.SetActive(true);
                gameOverItemGroup.GameOverTimer -= Time.deltaTime;
                GameManager.Instance.CountdownText.text = gameOverItemGroup.GameOverTimer.ToString("F0");
                
                if (gameOverItemGroup.GameOverTimer <= 0)
                {
                    GameManager.Instance.IsGameOver = true;
                    OnGameOver();
                }
            }
        }
        else if (GameManager.Instance.Ball.RB.velocity.magnitude > gameOverItemGroup.MinimumSpeed)
        {
            gameOverItemGroup.GameOverTimerObject.SetActive(false);
            gameOverItemGroup.BackgroundTimer = setBackgroundTimer;
            gameOverItemGroup.GameOverTimer = resetGameOverTimer;
        }
    }

    /// <summary>
    /// "Plays" the Tween animation
    /// </summary>
    private void OnGameOver()
    {
        gameOverTween.Kill();
        gameOverTween = DOTween.Sequence()
            .Join(gameOverItemGroup.Background.DOFade(0.85f, gameOverTweenDuration))
            .Join(gameOverItemGroup.GameOverMenuObject.transform.DOScale(1, gameOverTweenDuration).OnComplete(() =>
            { Time.timeScale = 0; }));

    }
}

