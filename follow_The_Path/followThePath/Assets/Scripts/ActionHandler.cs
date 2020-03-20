using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
/// <summary>
/// Deals with actions such as pressing buttons or switching scenes
/// </summary>
public class ActionHandler : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private AudioSource buttonTapSource;
    [SerializeField, Tooltip("Sets itself as the 'tapClip', is using SerializeFiled for testing (Will be removed)")]
    private AudioClip buttonTapClip;
    [SerializeField,Tooltip("Used to Play an SFX when pressing a button")]
    private AudioClip tapClip;
    private float delayButtonSound = 0.2f;


    public static ActionHandler Instance { get; private set; }

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
        //DontDestroyOnLoad(gameObject);

        buttonTapSource = GetComponent<AudioSource>();
        buttonTapClip = tapClip;
        buttonTapSource.clip = buttonTapClip;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// "Loads" the game scene
    /// </summary>
    public void Playgame()
    {
        //TODO Look up how to "kill" tweens
        //DOTween.Clear(true);
        Time.timeScale = 1;
        Invoke("OpenPlayGame", delayButtonSound);
    }

    public void ResetGame()
    {
        DOTween.Clear(true);
        Time.timeScale = 1;
        gameManager.IsGameOver = false;

        Invoke("OpenPlayGame", delayButtonSound);
    }

    /// <summary>
    /// "Loads" the Main Menu Scene
    /// </summary>
    public void LoadMainMenu()
    {
        DOTween.Clear(true);
        Time.timeScale = 1;
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
        buttonTapSource.Stop();
        buttonTapSource.PlayOneShot(buttonTapSource.clip = buttonTapClip);
    }
}
