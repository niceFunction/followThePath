using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameOver : MonoBehaviour
{
    //TODO GameOver 1: look into breaking things out from "GameManager" that's related to "Game Over"
    //TODO GameOver 2: And call(?) those variables in "OnGameOver" from "GameManger" instead (maybe?)

    [SerializeField, Tooltip("Game Over Menu transform"), Header("Visual")]
    private Transform gameOverTransform;
    public Transform GameOverTransform { get { return gameOverTransform; } }

    [SerializeField, Tooltip("The black & semi-transparent background used in GameOver/Paused")]
    private Image backgroundImage;
    public Image BackgroundImage { get { return backgroundImage; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
