using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleCamera : MonoBehaviour
{
    public Material grayscaleMaterial;

    /// <summary>
    /// Renders a material over the players camera
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, grayscaleMaterial);
    }

    private void Start()
    {
        ColorController.Instance.OnModeChange += OnModeChange;
        OnModeChange(ColorController.Instance.ColorMode);
    }

    /// <summary>
    /// Destroys the object if it has been unsubscribed
    /// </summary>
    private void OnDestroy()
    {
        ColorController.Instance.OnModeChange -= OnModeChange;
    }

    /// <summary>
    /// Sets player camera to GRAYSCALE if called
    /// </summary>
    /// <param name="newMode"></param>
    private void OnModeChange(ColorController.Modes newMode)
    {
        Debug.Log(newMode);

        if (newMode == ColorController.Modes.GRAYSCALE)
        {
            // If "newMode" has been set to GRAYSCALE, enable it
            this.enabled = true;
        }
        else
        {
            // If "newMode" has been set to something else, disable it
            this.enabled = false;
        }
    }
}
