
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controls changes between scenes
/// </summary>
public class SceneController : MonoBehaviour
{
    // Gets the names of the different Scenes
    [SerializeField, Tooltip("Name of Main Menu scene")]
    private string mainMenuName;
    public string MainMenuName { get { return mainMenuName; } }
    [SerializeField, Tooltip("Name of Game scene")]
    private string gameSceneName;
    public string GameSceneName { get { return gameSceneName; } }

    public static SceneController Instance { get; private set; }

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
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Opens the Main Menu scene
    /// </summary>
    public void LoadMainMenu()
    {
        // Has a button that "opens" the Main Menu scene been used?
        Debug.Log("OPEN MAIN MENU");

        // Sets the timeScale to 1 if game has been paused
        Time.timeScale = 1;

        // Opens the specified Scene name        
        SceneManager.LoadScene(MainMenuName);
    }

    /// <summary>
    /// Loads the Game scene
    /// </summary>
    public void LoadGame()
    {
        // Has a button that opens the Game scene been used?
        Debug.Log("OPEN GAME");

        // Sets the timeScale to 1 if game has been paused
        Time.timeScale = 1;

        // Opens the specified Scene name
        SceneManager.LoadScene(GameSceneName);
    }
}
