using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;

    [SerializeField, Tooltip("Shows the Player's score")]
    private TextMeshProUGUI playerHighscore;
    public TextMeshProUGUI PlayerHighscore { get { return playerHighscore; } }

    [SerializeField, Tooltip("currentHighscoreText displays while game is active")]
    private TextMeshProUGUI currentHighscore;
    public TextMeshProUGUI CurrentHighscore { get { return currentHighscore; } }

    [SerializeField, Tooltip("Displays the highscore on Game Over")]
    private TextMeshProUGUI gameOverHighscore;
    public TextMeshProUGUI GameOverHighscore { get { return gameOverHighscore; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds to the Players current highscore and updates it
    /// </summary>
    /// <param name="newScoreValue"></param>
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            playerHighscore.text = score.ToString();
        }
    }

    /// <summary>
    /// "Updates" the highscore text
    /// </summary>
    private void UpdateScore()
    {
        CurrentHighscore.text = score.ToString();
        GameOverHighscore.text = score.ToString();
    }
}
