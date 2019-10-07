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

    [Header("Game Over Variables")]
    [Tooltip("Manually get component from Player object")]
    public scr_Ball Ball;
    [Tooltip("GameObject responsible for the countdown text, disabled at the beginning")]
    public GameObject gameOverTimerObject;
    public GameObject gameOverMenuObject;
    [Tooltip("The countdown timer text")]
    public TextMeshProUGUI countdownText;

    [Range(1, 60)]
    [Tooltip("Amount of time to trigger countdown timer")]
    public float backgroundTimeAmount = 5;
    private float backgroundTimer;
    [Range(1, 60)]
    [Tooltip("Amount of time to trigger Game Over")]
    public float gameOverTimeAmount = 5.0f;
    private float gameOverTimer;
    //public static bool showTimer = false;
    [Range(0.01f, 5.0f)]
    [Tooltip("Minimum 'speed' to activate backgroundTimer")]
    public float minimumSpeed = 1.0f;

    void Start()
    {

        backgroundTimer = backgroundTimeAmount;
        gameOverTimer = gameOverTimeAmount;
        
    }

    void Update()
    {
       
        if(Ball.RB.velocity.magnitude < minimumSpeed)
        {
            //TODO: Look through (or rework) why the gameOverTimeAmount isn't used for the actual countdown.
            backgroundTimer -= Time.deltaTime;
            if (backgroundTimeAmount <=0)
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
        else if(Ball.RB.velocity.magnitude > minimumSpeed)
        {
            /*
            isGameOver = false;
            showTimer = false;
            backgroundTimer = 5;
            */
            gameOverTimerObject.SetActive(false);
            gameOverMenuObject.SetActive(false);
            backgroundTimer = backgroundTimeAmount;
            gameOverTimer = gameOverTimeAmount;

        }
       
    }

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void Playgame()
    {
        
        SceneManager.LoadScene("GameScene");
    }

    #region Pause Menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
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

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    #endregion
}
