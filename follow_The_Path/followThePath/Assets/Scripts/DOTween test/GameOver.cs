using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    //TODO Remove commented code

    //TODO On Game Over, ensure that the game IS paused and the Ball can't move
    #region Game Over Components

    [SerializeField, Tooltip("Variables for Game Over state")]
    private GameOverGroup gameOverItemGroup;
    public GameOverGroup GameOverItemGroup { get { return gameOverItemGroup; } }

    [SerializeField, Tooltip("Sets the 'setBackgroundTimer' to 'backgroundTimer', (USED FOR TESTING)")]
    private float setBackgroundTimer;

    // Resets the 'Game Over' timer
    private float resetGameOverTimer;
    #endregion

    // Related to Tweens
    private Tween gameOverTween;

    [SerializeField, Tooltip("How much time will pass until the 'gameOverMenuObject' pops up?"), Range(0.01f, 1f)]
    private float gameOverTweenDuration;

    [SerializeField, Header("Player Variables"), Tooltip("Get the Ball to get the distance between this object & the Player")]
    private Player ball;

    // Player's current distance
    private float playerDistance;
    private float playersLastPosition;
    private float distanceScore;
    private float previousPlayerDistance;


    [SerializeField, Tooltip("Shows the Players current distance in game")]
    private TextMeshProUGUI currentPlayerDistance;

    [SerializeField, Header("Displayed on Game Over"), Tooltip("On GAME OVER, shows the Players final distance")]
    private TextMeshProUGUI finalPlayerDistance;

    [SerializeField, Tooltip("On GAME OVER, show previous longest distance")]
    private TextMeshProUGUI longestPlayerDistance;

    // Used to save "Distance" score
    readonly string DISTANCE_SCORE = "DistanceScore";

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

    private void Start()
    {
        playersLastPosition = ball.transform.position.z;
        longestPlayerDistance.text = PlayerPrefs.GetFloat(DISTANCE_SCORE, 0).ToString("F1");
    }

    private void Update()
    {
        MeasureDistance();
    }
    /// <summary>
    /// "Restores" basic values to their starting values
    /// </summary>
    public void SetBaseValues()
    {
        gameOverItemGroup.IsGameOver = false;

        setBackgroundTimer = gameOverItemGroup.BackgroundTimer;
        resetGameOverTimer = gameOverItemGroup.GameOverTimer;

        Debug.Log("GETS Distance score: " + DISTANCE_SCORE);
    }

    /// <summary>
    /// Depending how fast the Player is moving, update the current status of the game
    /// </summary>
    public void GameStatus()
    {
        //TODO Break out all of the if statements to their own methods (not important right now)

        // If the Player's movement speed is too low, start the BackgroundTimer
        if (gameOverItemGroup.Ball.RB.velocity.magnitude < gameOverItemGroup.MinimumSpeed)
        {
            // BackgroundTimer starts counting down
            gameOverItemGroup.BackgroundTimer -= Time.deltaTime;

            
            InitiateGameOver();
        }
        else
        {
            GameIsNotOver();
        }
    }

    /// <summary>
    /// When BackgroundTimer is 0, GameOverTimer shows up & starts counting down
    /// </summary>
    private void InitiateGameOver()
    {
        if (gameOverItemGroup.BackgroundTimer <= 0)
        {
            gameOverItemGroup.BackgroundTimer = 0;
            gameOverItemGroup.GameOverTimerObject.SetActive(true);
            gameOverItemGroup.GameOverTimer -= Time.deltaTime;
            gameOverItemGroup.CountdownText.text = gameOverItemGroup.GameOverTimer.ToString("F0");

            GameIsOver();
        }
    }

    /// <summary>
    ///  Game is Over if the GameOverTimer reaches 0
    /// </summary>
    private void GameIsOver()
    {
        if (gameOverItemGroup.GameOverTimer <= 0)
        {
            SetScore(distanceScore);
            gameOverItemGroup.IsGameOver = true;
            OnGameOver();
        }
    }

    /// <summary>
    ///  If the Player's movement speed is above the minimum speed threshold, restore & hide timers
    /// </summary>
    private void GameIsNotOver()
    {
        gameOverItemGroup.GameOverTimerObject.SetActive(false);
        gameOverItemGroup.BackgroundTimer = setBackgroundTimer;
        gameOverItemGroup.GameOverTimer = resetGameOverTimer;
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

        // Set the GameOverTimer to 0 & hide it         
        gameOverItemGroup.GameOverTimer = 0;
        gameOverItemGroup.CountdownText.enabled = false;

    }

    public void MeasureDistance()
    {
        if (ball.transform.position.z > playersLastPosition)
        {
            playersLastPosition = ball.transform.position.z;
            playerDistance = Vector3.Distance(ball.transform.position, transform.position);
        }

        currentPlayerDistance.text = playerDistance.ToString("F1");
    }

    //TODO look through this method more
    public void SetScore(float newHighscore) //TODO Rename newDistanceValue to something else, more "tydligt"?
    {
        //TODO should playerDistance be something else maybe use distanceScore?
        distanceScore += newHighscore;
        UpdateText();

        if (playerDistance > PlayerPrefs.GetFloat(DISTANCE_SCORE, 0))
        {
            previousPlayerDistance = playerDistance;
            finalPlayerDistance.text = playerDistance.ToString("F1");
            
            PlayerPrefs.SetFloat(DISTANCE_SCORE, playerDistance);
            Debug.Log("SETS Distance score: " + DISTANCE_SCORE);
            PlayerPrefs.Save();
        }
    }

    public void UpdateText()
    {
        finalPlayerDistance.text = playerDistance.ToString("F1");
        longestPlayerDistance.text = PlayerPrefs.GetFloat(DISTANCE_SCORE, 0).ToString("F1");
    }
}

