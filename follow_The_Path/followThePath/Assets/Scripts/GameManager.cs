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
    // TODO Instead of collectibles, create a scoring system that measures distance instead
    [SerializeField]
    private GameOver gameOver;

    private float gameOverDistanceScore;

    [SerializeField, Tooltip("Object that tweens Ui element in the Game scene")]
    private GameUiTween gameUiTween;

    public static bool GameIsPaused = false;
    private bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver = false; } set { isGameOver = value; } }

    private Collectible collectible;
   /*
    private int score;
    [Space(10), SerializeField, Tooltip("currentScoreText displays while game is active")]
    private TextMeshProUGUI currentScore;
    [SerializeField, Tooltip("highscoreText displays when the game is over")]
    private TextMeshProUGUI highscore;

    public Collectible Collectible { get { return collectible; } }
    public int Score { get { return score; } }
    public TextMeshProUGUI CurrentScore { get { return currentScore; } }
    public TextMeshProUGUI Highscore { get { return highscore; } }
    */
    [Space(10)]
    #region GAME OVER VARIABLES

    [SerializeField, Tooltip("The countdown timer text")]
    private TextMeshProUGUI countdownText;

    public TextMeshProUGUI CountdownText { get { return countdownText; } }

    [SerializeField, Tooltip("Display Score on Game Over")]
    private TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI GameOverScore { get { return gameOverScore; } }
    #endregion

    public static GameManager Instance { get; private set; }

    void Start()
    {
        Time.timeScale = 1;
        
        Distance.Instance.SetBaseValues();
        GameOver.Instance.SetBaseValues();

        //Highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        GameOver.Instance.GameStatus();
        //Distance.Instance.MeasureDistance();
        Distance.Instance.AddScoreDistance(gameOverDistanceScore);
    }

    private void Awake()
    {
        //Screen.sleepTimeout = SleepTimeout.NeverSleep; // will probably be removed
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

    /*
    #region Score specific methods
    public void AddScore(int newScoreValue)
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
    */
}
