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

    public TextMeshPro countdownText;

    public float triggerCountdownTimer = 5;
    public float countdownTimer = 5;
    public static bool showTimer = false;

    public float minimumSpeed = 1.0f;

    //public Text countdownText;

    private scr_Ball Ball;

    void Start()
    {
        Ball = GetComponent<scr_Ball>();
        countdownText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if(Ball.RB.velocity.magnitude < minimumSpeed)
        {
            triggerCountdownTimer -= Time.deltaTime;
            if(triggerCountdownTimer <= 0)
            {
                showTimer = true;
                countdownTimer -= Time.deltaTime;
                if(countdownTimer <= 0)
                {
                    GameOver();
                }
            }
        }
        else if(Ball.RB.velocity.magnitude > minimumSpeed)
        {
            isGameOver = false;
            showTimer = false;
            triggerCountdownTimer = 5;
            countdownTimer = 5;
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
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    #endregion
}
