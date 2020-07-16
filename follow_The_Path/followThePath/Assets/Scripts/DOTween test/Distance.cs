using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance : MonoBehaviour
{
    // NOTE: This class should (probably) work together with "GameOver" class
    [SerializeField, Tooltip("Get the Ball to measure the Players distance")]
    private Player ball;

    // The Players distance value
    private float playerDistance;

    [SerializeField, Tooltip("Shows the Players (upper left corner) current distance")]
    private TextMeshProUGUI currentPlayerDistance;
    public TextMeshProUGUI CurrentPlayerDistance { get { return currentPlayerDistance; } }

    [SerializeField, Tooltip("On Game Over, shows the Players final distance")]
    private TextMeshProUGUI finalPlayerDistance; // Happens on the Game Over object in the Game scene, shows on top
    public TextMeshProUGUI FinalPlayerDistance { get { return finalPlayerDistance; } }

    [SerializeField, Tooltip("On Game Over, shows the previous final distance")]
    private TextMeshProUGUI previousPlayerDistance; // Shown at the same time as the final distance, shows on bottom
    public TextMeshProUGUI PreviousPlayerDistance { get { return previousPlayerDistance; } }
    
    /*
    [SerializeField, Tooltip("Shows the Player's score")]
    private TextMeshProUGUI playerHighscore;
    public TextMeshProUGUI PlayerHighscore { get { return playerHighscore; } }

    [SerializeField, Tooltip("currentHighscoreText displays while game is active")]
    private TextMeshProUGUI currentHighscore;
    public TextMeshProUGUI CurrentHighscore { get { return currentHighscore; } }

    [SerializeField, Tooltip("Displays the highscore on Game Over")]
    private TextMeshProUGUI gameOverHighscore;
    public TextMeshProUGUI GameOverHighscore { get { return gameOverHighscore; } }
    */

    public static Distance Instance { get; private set; }

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

    // Start is called before the first frame update
    void Start()
    {
        // NOTE: Get this variable/function in their own method?
        currentPlayerDistance.text = PlayerPrefs.GetFloat("Distance", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Measure the Players (Ball's) current distance
    /// </summary>
    public void MeasureDistance()
    {

    }

    /// <summary>
    /// Adds to the current distance
    /// </summary>
    /// <param name="newDistanceValue"></param>
    public void CalculateDistance(float newDistanceValue)
    {
        // NOTE: This method could change

        playerDistance += newDistanceValue;
        UpdateDistance(); // <-- Necessary?

        if (playerDistance > PlayerPrefs.GetFloat("Distance", 0))
        {
            PlayerPrefs.SetFloat("Distance", playerDistance);

        }
    }

    /// <summary>
    /// Updates the current distance
    /// </summary>
    public void UpdateDistance()
    {
        // NOTE: This method could change
        CurrentPlayerDistance.text = playerDistance.ToString();
        PreviousPlayerDistance.text = playerDistance.ToString();
    }
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
