﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// Manages the buttons and when the button sound should be played
/// </summary>
public class ButtonManager : MonoBehaviour
{

    private AudioSource tapSource;
    public AudioSource TapSource { get { return tapSource; } }

    [SerializeField, Tooltip("SFX to be played when a  button has been pressed")]
    private AudioClip tapClip;
    public AudioClip TapClip { get { return tapClip; } }

    [SerializeField, Tooltip("Adds enough time for the SFX to play before a scene opens"), Range(0f, 1f)]
    private float delayButtonSound = 0.2f;
    // Note to self: Added incase the value needs to be adjusted
    public float DelayButtonSound { get { return delayButtonSound; } }

    public static ButtonManager Instance { get; private set; }

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

        tapSource = GetComponent<AudioSource>();
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
    /// Plays the SFX on button presses
    /// </summary>
    public void PlayButtonSFX()
    {
        TapSource.Stop();
        TapSource.PlayOneShot(TapSource.clip = TapClip);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

}
