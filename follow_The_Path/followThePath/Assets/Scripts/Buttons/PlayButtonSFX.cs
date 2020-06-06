using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach class to button to play button SFX
/// </summary>
public class PlayButtonSFX : MonoBehaviour
{
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


    }


    /// <summary>
    /// Plays the button SFX from "ButtonClickController"
    /// </summary>
    public void BeginPressedSFX()
    {
        ButtonClickController.Instance.BeginButtonSFX();
    }

}
