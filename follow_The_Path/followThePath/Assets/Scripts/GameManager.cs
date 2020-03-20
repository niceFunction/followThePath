using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using DG.Tweening;

/// <summary>
/// Class that manages different states in the game
/// </summary>
public class GameManager : MonoBehaviour
{

    [SerializeField, Tooltip("Object that tweens Ui element in the Game scene")]
    private GameUiTween gameUiTween;

    public static bool GameIsPaused = false;
    private bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver = false; } set { isGameOver = value; } }

    private Collectible collectible;
    private int score;
    [Space(10), SerializeField, Tooltip("currentScoreText displays while game is active")]
    private TextMeshProUGUI currentScore;
    [SerializeField, Tooltip("highscoreText displays when the game is over")]
    private TextMeshProUGUI highscore;

    public Collectible Collectible { get { return collectible; } }
    public int Score { get { return score; } }
    public TextMeshProUGUI CurrentScore { get { return currentScore; } }
    public TextMeshProUGUI Highscore { get { return highscore; } }

    [Space(10)]
    #region GAME OVER VARIABLES
    [SerializeField, Tooltip("Manually get component from Player object")]
    private Player ball;
    [SerializeField,Tooltip("GameObject responsible for the countdown text, disabled at the beginning")]
    private GameObject gameOverTimerObject;
    [SerializeField]
    private GameObject gameOverMenuObject;
    [SerializeField, Tooltip("The countdown timer text")]
    private TextMeshProUGUI countdownText;

    // Getter variables
    public Player Ball { get { return ball; } }
    public GameObject GameOverTimerObject { get { return gameOverTimerObject; } }
    public GameObject GameOverMenuObject { get { return gameOverMenuObject; } }
    public TextMeshProUGUI CountdownText { get { return countdownText; } }


    [SerializeField, Tooltip("Amount of time to trigger game over timer"), Range(1, 60)]
    private float backgroundTimer = 5.0f;

    [SerializeField]
    private float setBackgroundTimer;

    [SerializeField, Tooltip("Amount of time to trigger Game Over"), Range(1, 60)]
    private float gameOverTimer = 5.0f;
    private float resetGameOverTimer;

    [SerializeField, Tooltip("Minimum 'speed' to activate backgroundTimer"), Range(0.01f, 5.0f)]
    private float minimumSpeed = 1.0f;

    public float BackgroundTimer { get { return backgroundTimer; } set { backgroundTimer = value; } }
    public float GameOverTimer { get { return gameOverTimer; } set { gameOverTimer = value; } }
    public float ResetGameOverTimer { get { return resetGameOverTimer; } set { resetGameOverTimer = value; } }
    public float MinimumSpeed { get { return minimumSpeed; } }

    /*
    Another version used to display Player's score on Game Over.
    Temporary solution, variable "currentScore" should be used instead.
    */
    [SerializeField, Tooltip("Display Score on Game Over")]
    private TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI GameOverScore { get { return gameOverScore; } }
    #endregion

    public static GameManager Instance { get; private set; }

    void Start()
    {
        Time.timeScale = 1;
        isGameOver = false;
        setBackgroundTimer = BackgroundTimer;
               
        ResetGameOverTimer = GameOverTimer;

        Highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        GameStatus();
    }

    private void Awake()
    {
        //Screen.sleepTimeout = SleepTimeout.NeverSleep; // will probably be removed
    }

    /// <summary>
    /// Updates the status of the game
    /// </summary>
    public void GameStatus()
    {
        // If the players "velocity" is below a certain value, activate timer
        if (Ball.RB.velocity.magnitude < MinimumSpeed)
        {
            BackgroundTimer -= Time.deltaTime;
            if (BackgroundTimer <= 0)
            {
                // If background timer is zero, "activate" visual timer
                BackgroundTimer = 0;
                GameOverTimerObject.SetActive(true);
                GameOverTimer -= Time.deltaTime;
                CountdownText.text = GameOverTimer.ToString("F0");
                if (GameOverTimer <= 0)
                {
                    isGameOver = true;
                    GameOver();
                }
            }
        }
        // If the players velocity is above a certain value, reset all timers
        else if (Ball.RB.velocity.magnitude > MinimumSpeed)
        {
            GameOverTimerObject.SetActive(false);
            BackgroundTimer = setBackgroundTimer;

            GameOverTimer = ResetGameOverTimer;
        }
    }

    #region Pause Menu Methods
    /// <summary>
    /// Resumes the game and continues game time
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    /// <summary>
    /// Pauses the game and stops game time
    /// </summary>
    public void Pause()
    {
        gameUiTween.EnterPauseMenu();
        GameIsPaused = true;
    }
    #endregion

    public void GameOver()
    {
        gameUiTween.OnGameOver();
        isGameOver = true;
        CountdownText.enabled = false;
        CurrentScore.enabled = false;
    }

    #region Score specific methods
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            Highscore.text = score.ToString();
        }
    }

    /// <summary>
    /// Updates the score
    /// </summary>
    void UpdateScore()
    {
        CurrentScore.text = Score.ToString();
        GameOverScore.text = Score.ToString();
    }
    #endregion
}
