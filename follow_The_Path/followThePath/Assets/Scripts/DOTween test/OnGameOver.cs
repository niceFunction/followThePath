using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameOver : MonoBehaviour
{
    //TODO GameOver 1: look into breaking things out from "GameManager" that's related to "Game Over"
    //TODO GameOver 2: And call(?) those variables in "OnGameOver" from "GameManger" instead (maybe?)

    [SerializeField, Tooltip("Game Over Menu transform (MAY NOT BE NEEDED)"), Header("Visual")]
    private Transform gameOverTransform;
    public Transform GameOverTransform { get { return gameOverTransform; } }

    [SerializeField, Tooltip("The black & semi-transparent background used in GameOver/Paused")]
    private Image backgroundImage;
    public Image BackgroundImage { get { return backgroundImage; } }

    [SerializeField, Tooltip("Game Over Menu object"), Header("GameObjects")]
    private GameObject gameOverMenuObject;
    public GameObject GameOverMenuObject { get { return gameOverMenuObject; } }

    [SerializeField, Tooltip("GameObject that starts counting down")]
    private GameObject gameOverTimerObject;
    public GameObject GameOverTimerObject { get { return gameOverTimerObject; } }

    [SerializeField, Tooltip("Amount of time needed to trigger the Game Over timer"), Range(1, 60), Header("Timers")]
    private float backgroundTimer = 5.0f;
    public float BackgroundTimer { get { return backgroundTimer; } }
    
    [SerializeField, Tooltip("Sets the 'setBackgroundTimer' to 'backgroundTimer', (USED FOR TESTING)")]
    private float setBackgroundTimer;
    public float SetBackgroundTimer { get { return setBackgroundTimer; } }

    [SerializeField, Tooltip("Amount of time until 'Game Over' (will show up on screen)"), Range(1, 60)]
    private float gameOverTimer = 5.0f;
    public float GameOverTimer { get { return gameOverTimer; } }
    // Resets the 'Game Over' timer
    private float resetGameOverTimer;
    public float ResetGameOverTimer { get { return resetGameOverTimer; } }

    [SerializeField, Tooltip("Minimum amount of speed to trigger the backgroundTimer"), Range(0.01f, 5.0f), Header("Minimum Speed")]
    private float minimumSpeed = 1.0f;
    public float MinimumSpeed { get { return minimumSpeed; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
