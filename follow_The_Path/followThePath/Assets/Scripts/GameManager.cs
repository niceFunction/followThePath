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

    //TODO Divide Game related variables/methods and "state" related variables/methods to their own scripts
    // Game "States"

    [SerializeField, Tooltip("Object that tweens Ui element in the Game scene")]
    private GameObject gameUiTweenObject;
    [Space(10)]
    public static bool GameIsPaused = false; // Related to "GameManager"
    public static bool isGameOver = false; // Related to "GameManager"
    /*
    #region Moved to "ActionHandler"
    private AudioSource buttonTapSource; // Related to "state" or "action"
    [Tooltip("Used to Play an SFX when pressing a button")]
    public AudioClip buttonTapClip; // Related to "state" or "action"
    private float delayButtonSound = 0.2f; // Related to "state" or "action"
    #endregion
    */
    private Collectible collectible; // Related to "GameManager"
    private int score; // Related to "GameManager"
    [SerializeField, Tooltip("currentScoreText displays while game is active")]
    private TextMeshProUGUI currentScore; // Related to "GameManager"
    [SerializeField, Tooltip("highscoreText displays when the game is over")]
    private TextMeshProUGUI highscore; // Related to "GameManager"

    public Collectible Collectible { get { return collectible; } }
    public int Score { get { return score; } }
    public TextMeshProUGUI CurrentScore { get { return currentScore; } }
    public TextMeshProUGUI Highscore { get { return highscore; } }

    //TODO turn most (if not all variables) private and add getters for them
    [Space(10)]
    #region GAME OVER VARIABLES
    [Header("Game Over Variables")]
    //[Tooltip("True if player is inside a 'active' game scene, false if they aren't")]
    //public bool insideGameScene = false; // if divided, this should be removed
    
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
    private float resetBackgroundTimer; // Used to reset 'backgroundTimer'.

    [SerializeField, Tooltip("Amount of time to trigger Game Over"), Range(1, 60)]
    private float gameOverTimer = 5.0f;
    private float resetGameOverTimer;
    [SerializeField, Tooltip("Minimum 'speed' to activate backgroundTimer"), Range(0.01f, 5.0f)]
    private float minimumSpeed = 1.0f;

    public float BackgroundTimer { get { return backgroundTimer; } set { backgroundTimer = value; } }
    public float ResetBackgroundTimer { get { return resetBackgroundTimer; } set { resetGameOverTimer = value; } }
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
        //buttonTapSource = GetComponent<AudioSource>();
        ResetBackgroundTimer = BackgroundTimer;
        ResetGameOverTimer = GameOverTimer;

        Highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        //GameStatus();
        /*
        #region Game Over Conditions
        if (insideGameScene == true)
        {
            // TODO create and move the following content to its own method
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
                GameOverMenuObject.SetActive(false);
                BackgroundTimer = ResetBackgroundTimer;
                GameOverTimer = ResetGameOverTimer;
            }
        }
        #endregion
        */
    }

    private void Awake()
    {
        //Screen.sleepTimeout = SleepTimeout.NeverSleep; // will probably be removed
        //gameUiTweenObject = GetComponent<GameObject>();
    }

    /// <summary>
    /// Updates the status of the game
    /// </summary>
    void GameStatus()
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
            GameOverMenuObject.SetActive(false);
            BackgroundTimer = ResetBackgroundTimer;
            GameOverTimer = ResetGameOverTimer;
        }
    }
    /*
    public void Playgame() // Moved to ActionHandler
    {
        Time.timeScale = 1;
        //isGameOver = false;
        //BackgroundTimer = ResetBackgroundTimer;
        //GameOverTimer = ResetGameOverTimer;
        Invoke("OpenPlayGame", delayButtonSound);
    }


    public void LoadMainMenu() // Moved to ActionHandler
    {
        Time.timeScale = 1;
        //isGameOver = false;
        //BackgroundTimer = ResetBackgroundTimer;
        //GameOverTimer = ResetGameOverTimer;
        Invoke("OpenMainMenu", delayButtonSound);
        
    }
    */
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
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    #endregion

    public void GameOver()
    {
        //gameUiTweenObject = GetComponent<GameObject>();

        Time.timeScale = 0;
        isGameOver = true;
        CountdownText.enabled = false;
        CurrentScore.enabled = false;
        GameUiTween.Instance.OnGameOver();
        //GameOverMenuObject.SetActive(true);
    }

    /*
    //NOTE: Maybe move this method to another script in the future

    public void QuitGame() // Moved to ActionHandler
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    #region Delay specific UI methods
    //TODO: Personal note: Look into if a better method would work in the long run
    /// <summary>
    /// Plays an SFX before opening a scene which is on a delay.
    /// </summary>
    public void OnPressingQuitGame() // Moved to ActionHandler
    {
        PlayButtonTapSound();
        Invoke("QuitGame", delayButtonSound);
    }
    /// <summary>
    /// Used to Invoke the Scene in "LoadMainMenu".
    /// </summary>
    void OpenMainMenu() // Moved to ActionHandler
    {
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// Used to Invoke the Scene in the method "Playgame".
    /// </summary>
    void OpenPlayGame() // Moved to ActionHandler
    {
        SceneManager.LoadScene("GameScene");
    }
    #endregion

    //TODO: Look into moving this method in UI certain methods
    public void PlayButtonTapSound() // Moved to ActionHandler
    {
        buttonTapSource.Stop();
        buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }
    */
    #region Score specific methods
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            Highscore.text = score.ToString();
            //gameOverHighScore.text = score.ToString();
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
    /*
    /// <summary>
    /// Used for Debugging and testing, will be removed in the future.
    /// </summary>
    public void ResetHighScore() // Moved to ActionHandler
    {
        PlayerPrefs.DeleteKey("HighScore");
        Highscore.text = "0";
        //buttonTapSource.Stop();
        //buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }
    */
    #endregion
}
