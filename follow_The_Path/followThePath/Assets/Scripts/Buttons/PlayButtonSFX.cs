using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach class to button to play button SFX
/// </summary>
public class PlayButtonSFX : MonoBehaviour
{
    /// <summary>
    /// Plays the button SFX from "ButtonClickController"
    /// </summary>
    public void BeginPressedSFX()
    {
        ButtonClickController.Instance.BeginButtonSFX();
    }

}
