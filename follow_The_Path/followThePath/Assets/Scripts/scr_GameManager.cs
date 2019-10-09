using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_GameManager : MonoBehaviour
{
    

    // Game "States"
    public static bool GameIsPaused = false;
    public static bool isGameOver = false;

    [Space(10)]
    #region GAME OVER VARIABLES
    [Header("Game Over Variables")]
    [Tooltip("True if player is inside a 'active' game scene, false if they aren't")]
    public bool insideGameScene = false;
    [Tooltip("Manually get component from Player object")]
    public scr_Ball Ball;
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
    #endregion

    void Start()
    {
        resetBackgroundTimer = backgroundTimer;
        resetGameOverTimer = gameOverTimer;   
    }

    void Update()
    {
       Debug.Log(isGameOver);
        if (insideGameScene == true)
        {

            if (Ball.RB.velocity.magnitude < minimumSpeed)
            {
                backgroundTimer -= Time.deltaTime;
                if (backgroundTimer <= 0)
                {
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
            else if (Ball.RB.velocity.magnitude > minimumSpeed)
            {
                gameOverTimerObject.SetActive(false);
                gameOverMenuObject.SetActive(false);
                backgroundTimer = resetBackgroundTimer;
                gameOverTimer = resetGameOverTimer;
            }
        }
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
        SceneManager.LoadScene("GameScene");
    }

    #region Pause Menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        isGameOver = false;
        backgroundTimer = resetBackgroundTimer;
        gameOverTimer = resetGameOverTimer;
        SceneManager.LoadScene("MainMenu");
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
        gameOverMenuObject.SetActive(true);
    }

    //TODO: Is this method necessary?
    public void Restart()
    {
        //Time.timeScale = 1;
        isGameOver = false;
        gameOverMenuObject.SetActive(false);
        SceneManager.LoadScene("GameScene");    
    }
    #endregion
}
