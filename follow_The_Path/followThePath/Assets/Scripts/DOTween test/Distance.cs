using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance : MonoBehaviour
{
    /*
     Points by distance:
    distance based scoring system: https://answers.unity.com/questions/923146/distance-based-score-system.html
    */

    // NOTE: This class should (probably) work together with "GameOver" class
    [SerializeField, Tooltip("Get the Ball to measure the Players distance")]
    private Player ball;

    // The Players distance value
    private float playerDistance;

    private float addHighscoreDistance;
    // Player's last "known" position
    private float playerLastPosition;

    [SerializeField, Tooltip("Shows the Players (upper left corner) current distance")]
    private TextMeshProUGUI currentPlayerDistance;
    public TextMeshProUGUI CurrentPlayerDistance { get { return currentPlayerDistance; } }

    [SerializeField, Tooltip("On Game Over, shows the Players final distance"), Header("Displayed on GameOver")]
    private TextMeshProUGUI finalPlayerDistance; // Happens on the Game Over object in the Game scene, shows on top
    public TextMeshProUGUI FinalPlayerDistance { get { return finalPlayerDistance; } }

    [SerializeField, Tooltip("On Game Over, shows the previous final distance")]
    private TextMeshProUGUI longestPlayerDistance; // Shown at the same time as the final distance, shows on bottom
    public TextMeshProUGUI LongestPlayerDistance { get { return longestPlayerDistance; } }

    public static Distance Instance { get; private set; }

    //TODO Distance 3: (Has to be done laster) Distance will be measured in Meters but as a "Setting", can be changed to Imperial instead
    // NOTE: Consider using a Button slider for it with an INT, 0 = OFF & 1 = ON

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
        // What is the Ball's last position on Z-axis
        //playerLastPosition = ball.transform.position.z;

        // NOTE: Get this variable/function in their own method?
        LongestPlayerDistance.text = PlayerPrefs.GetFloat("DistanceScore", 0).ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        MeasureDistance();
    }

    public void SetBaseValues()
    {
        // What is the Ball's last position on Z-axis
        playerLastPosition = ball.transform.position.z;

        // NOTE: Get this variable/function in their own method?
        LongestPlayerDistance.text = PlayerPrefs.GetFloat("DistanceScore", 0).ToString();
    }

    /// <summary>
    /// Measure the Players (Ball's) current distance
    /// </summary>
    public void MeasureDistance()
    {
        // NOTE 1: Ball's value is now only increasing aslong as it moves further along Z-axis
        // NOTE 2: however, its updating "playerLastPosition" every frame(?), can that be "healthy"?
        //AddScoreDistance(playerDistance);
        // Increases the distance as long as the Ball is moving further on the Z-axis
        if(ball.transform.position.z > playerLastPosition)
        {
            playerLastPosition = ball.transform.position.z;
            playerDistance = Vector3.Distance(ball.transform.position, transform.position);
        }

        

        // TODO for the future when adding "M" or "FT" use + "whatDistanceFormat" at the end of this function
        currentPlayerDistance.text = playerDistance.ToString("F1");
        AddScoreDistance(addHighscoreDistance);
    }

    /// <summary>
    /// Adds to the current distance
    /// </summary>
    /// <param name="newDistanceValue"></param>
    public void AddScoreDistance(float newDistanceValue)
    {
        // NOTE: This method could change

        playerDistance += newDistanceValue;
        UpdateDistanceText(); // <-- Necessary?

        if (playerDistance > PlayerPrefs.GetFloat("DistanceScore", 0))
        {
            PlayerPrefs.SetFloat("DistanceScore", addHighscoreDistance);
            FinalPlayerDistance.text = playerDistance.ToString("F1");
            PlayerPrefs.Save();

        }
    }

    /// <summary>
    /// Updates the current distance
    /// </summary>
    public void UpdateDistanceText()
    {
        // TODO Ensure that "Distance" highscore is displaying correctly, test it by moving it to the Game Scene
        FinalPlayerDistance.text = playerDistance.ToString("F1");
        LongestPlayerDistance.text = playerDistance.ToString("F1");
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
