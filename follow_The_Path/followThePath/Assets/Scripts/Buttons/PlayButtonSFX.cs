using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach class to button to play button SFX
/// </summary>
public class PlayButtonSFX : MonoBehaviour
{

    // Sound source
    private AudioSource buttonTapSource;
    public AudioSource ButtonTapSource { get { return buttonTapSource; } }

    [SerializeField, Tooltip("SFX that plays when a button has been pressed")]
    private AudioClip buttonTapClip;
    public AudioClip ButtonTapClip { get { return buttonTapClip; } }

    public static PlayButtonSFX Instance { get; private set; }

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

        buttonTapSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Begins playing the button sfx
    /// </summary>
    public void Begin()
    {
        Debug.Log("Button SFX Played");
        // Stops all clips
        ButtonTapSource.Stop();
        // Plays the audio clip
        ButtonTapSource.PlayOneShot(ButtonTapSource.clip = ButtonTapClip);
    }

    public void BeginPressedSFX()
    {
        ButtonClickController.Instance.BeginButtonSFX();
    }

}
