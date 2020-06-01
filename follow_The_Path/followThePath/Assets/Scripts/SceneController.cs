
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

    // Note: have a function (or method) that can be called from anywhere(?) or only from this class, 
    //to set timeScale to 0 or 1 from different methods?

    // Gets the names of the different Scenes
    // Note to self: Should this be considered useful or wasteful?
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
        //TODO reminder to self: Add Scene objects at runtime(?)
        mainMenuName = "MainMenu";
        gameSceneName = "GameScene";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Opens scene to the Main Menu
    /// </summary>
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
    }

    /// <summary>
    /// Opens scene to the game scene
    /// </summary>
    public void OpenGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    /// <summary>
    /// Sets timeScale to 1 and opens the Main Menu scene
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1;

        OpenMainMenu();
    }

    /// <summary>
    /// Reloads the game scene
    /// </summary>
    public void ReloadGame()
    {
        //TODO Note to self: When using (if using it in this class) set DOTween.Clear(true)
        // Reminder to self: If timeScale has been set to 0, be sure to set timeScale to 1 again
        Time.timeScale = 1;
        //TODO reminder to self: Opt to slighly delay opening the Game Scene to delay button opening sound, if yes use Invoke

        OpenGame();
    }
}
