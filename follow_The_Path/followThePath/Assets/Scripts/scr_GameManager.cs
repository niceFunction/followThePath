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
    [Tooltip("The countdown timer text")]
    public TextMeshProUGUI countdownText;

    [Range(1, 60)]
    [Tooltip("Amount of time to trigger countdown timer")]
    public float triggerCountdownTimer = 5;
    [Range(1, 60)]
    [Tooltip("Amount of time to trigger Game Over")]
    public float countdownTimeAmount = 5.0f;
    private float countdownTimer;
    //public static bool showTimer = false;
    [Range(0.01f, 5.0f)]
    [Tooltip("Minimum 'speed' to activate triggerCountdownTimer")]
    public float minimumSpeed = 1.0f;

    void Start()
    {
        //Ball = GetComponent<scr_Ball>();
        //countdownText = GetComponent<TextMeshProUGUI>();
        //gameOverTimerObject = GetComponent<GameObject>();
        countdownTimer = countdownTimeAmount;
        
    }

    void Update()
    {
       
        if(Ball.RB.velocity.magnitude < minimumSpeed)
        {
            /*
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
            */
            //TODO: Look through (or rework) why the countdownTimeAmount isn't used for the actual countdown.
            triggerCountdownTimer -= Time.deltaTime;
            if (triggerCountdownTimer <=0)
            {
                //showTimer = true;
                gameOverTimerObject.SetActive(enabled);
                countdownTimer -= Time.deltaTime;
                countdownText.text = countdownTimeAmount.ToString();
                if (countdownTimer <= 0)
                {
                    GameOver();
                }
            }
        }
        else if(Ball.RB.velocity.magnitude > minimumSpeed)
        {
            /*
            isGameOver = false;
            showTimer = false;
            triggerCountdownTimer = 5;
            countdownTimer = 5;.
            */
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
