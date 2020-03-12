using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
/// <summary>
/// Deals with actions such as pressing buttons or switching scenes
/// </summary>
public class ActionHandler : MonoBehaviour
{
    private AudioSource buttonTapSource; // Related to "state" or "action"
    [Tooltip("Used to Play an SFX when pressing a button")]
    public AudioClip buttonTapClip; // Related to "state" or "action"
    private float delayButtonSound = 0.2f; // Related to "state" or "action"


    public static ActionHandler Instance { get; private set; }

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonTapSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// "Loads" the game scene
    /// </summary>
    public void Playgame() // move to ActionHandler?
    {
        Time.timeScale = 1;
        //isGameOver = false;
        //backgroundTimer = resetBackgroundTimer;
        //gameOverTimer = resetGameOverTimer;
        Invoke("OpenPlayGame", delayButtonSound);
    }

    /// <summary>
    /// "Loads" the Main Menu Scene
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        //isGameOver = false;
        //backgroundTimer = resetBackgroundTimer;
        //gameOverTimer = resetGameOverTimer;
        Invoke("OpenMainMenu", delayButtonSound);

    }
    /// <summary>
    /// Everytime the player taps an interactive UI element (ex: a button) an sfx plays
    /// </summary>
    public void PlayButtonTapSound()
    {
        buttonTapSource.Stop();
        buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }

    /// <summary>
    /// Used to Invoke the Scene in "LoadMainMenu".
    /// </summary>
    void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// Used to Invoke the Scene in the method "Playgame".
    /// </summary>
    void OpenPlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// Quits the application
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
    /// <summary>
    /// Slightly delays time before quitting the application so that the button tap sound can play
    /// </summary>
    public void OnPressingQuitGame()
    {
        PlayButtonTapSound();
        Invoke("QuitGame", delayButtonSound);
    }

    /// <summary>
    /// Used for Debugging and testing, will be removed in the future.
    /// </summary>
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        //highscore.text = "0";
        buttonTapSource.Stop();
        buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }
}
