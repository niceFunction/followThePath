﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/// <summary>
/// Class that manages different states in the game
/// </summary>
public class GameManager : MonoBehaviour
{

    // Game "States"
    public static bool GameIsPaused = false;
    public static bool isGameOver = false;

    private AudioSource buttonTapSource;
    [Tooltip("Used to Play an SFX when pressing a button")]
    public AudioClip buttonTapClip;
    private float delayButtonSound = 0.2f;


    private Collectible collectible;
    private int score;
    // currentScoreText displays while game is active
    public TextMeshProUGUI currentScore;
    // highscoreText displays when the game is over
    public TextMeshProUGUI highscore;
    

    [Space(10)]
    #region GAME OVER VARIABLES
    [Header("Game Over Variables")]
    [Tooltip("True if player is inside a 'active' game scene, false if they aren't")]
    public bool insideGameScene = false;
    [Tooltip("Manually get component from Player object")]
    public Ball Ball;
    [Tooltip("GameObject responsible for the countdown text, disabled at the beginning")]
    public GameObject gameOverTimerObject;
    public GameObject gameOverMenuObject;
    [Tooltip("The countdown timer text")]
    public TextMeshProUGUI countdownText;

    [Range(1, 60)]
    [Tooltip("Amount of time to trigger game over timer")]
    public float backgroundTimer = 5.0f;
    private float resetBackgroundTimer; // Used to reset 'backgroundTimer'.

    [Range(1, 60)]
    [Tooltip("Amount of time to trigger Game Over")]
    public float gameOverTimer = 5.0f;
    private float resetGameOverTimer;

    [Range(0.01f, 5.0f)]
    [Tooltip("Minimum 'speed' to activate backgroundTimer")]
    public float minimumSpeed = 1.0f;

    /// <summary>
    /// Another version used to display Player's score on Game Over.
    /// Temporary solution, variable "currentScore" should be used instead.
    /// </summary>
    [Tooltip("Display Score on Game Over")]
    public TextMeshProUGUI gameOverScore;
    #endregion

    void Start()
    {
        buttonTapSource = GetComponent<AudioSource>();
        resetBackgroundTimer = backgroundTimer;
        resetGameOverTimer = gameOverTimer;

        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        #region Game Over Conditions
        if (insideGameScene == true)
        {
            // If the players "velocity" is below a certain value, activate timer
            if (Ball.RB.velocity.magnitude < minimumSpeed)
            {
                backgroundTimer -= Time.deltaTime;
                if (backgroundTimer <= 0)
                {
                    // If background timer is zero, "activate" visual timer
                    backgroundTimer = 0;
                    gameOverTimerObject.SetActive(true);
                    gameOverTimer -= Time.deltaTime;
                    countdownText.text = gameOverTimer.ToString("F0");
                    if (gameOverTimer <= 0)
                    {
                        isGameOver = true;
                        GameOver();
                    }
                }
            }
            // If the players velocity is above a certain value, reset all timers
            else if (Ball.RB.velocity.magnitude > minimumSpeed)
            {
                gameOverTimerObject.SetActive(false);
                gameOverMenuObject.SetActive(false);
                backgroundTimer = resetBackgroundTimer;
                gameOverTimer = resetGameOverTimer;
            }
        }
        #endregion

    }

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void Playgame()
    {
        Time.timeScale = 1;
        isGameOver = false;
        backgroundTimer = resetBackgroundTimer;
        gameOverTimer = resetGameOverTimer;
        Invoke("OpenPlayGame", delayButtonSound);
    }

    #region Pause Menu Methods
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        isGameOver = false;
        backgroundTimer = resetBackgroundTimer;
        gameOverTimer = resetGameOverTimer;
        Invoke("OpenMainMenu", delayButtonSound);
        
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    #endregion

    #region Game Over Menu
    public void GameOver()
    {
        Time.timeScale = 0;
        isGameOver = true;
        countdownText.enabled = false;
        currentScore.enabled = false;
        gameOverMenuObject.SetActive(true);
    }
    #endregion

    //NOTE: Maybe move this method to another script in the future
    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    #region Delay specific UI methods
    //TODO: Personal note: Look into if a better method would work in the long run
    /// <summary>
    /// Plays an SFX before opening a scene which is on a delay.
    /// </summary>
    public void OnPressingQuitGame()
    {
        PlayButtonTapSound();
        Invoke("QuitGame", delayButtonSound);
    }
    /// <summary>
    /// Used to Invoke the Scene in "LoadMainMenu".
    /// </summary>
    void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// Used to Invoke the Scene in the method "Playgame".
    /// </summary>
    void OpenPlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    #endregion

    //TODO: Look into moving this method in UI certain methods
    public void PlayButtonTapSound()
    {
        buttonTapSource.Stop();
        buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }

    #region Score specific methods
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscore.text = score.ToString();
            //gameOverHighScore.text = score.ToString();
        }
    }

    void UpdateScore()
    {
        currentScore.text = score.ToString();
        gameOverScore.text = score.ToString();
    }

    /// <summary>
    /// Used for Debugging and testing, will be removed in the future.
    /// </summary>
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highscore.text = "0";
        buttonTapSource.Stop();
        buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }
    #endregion
}
