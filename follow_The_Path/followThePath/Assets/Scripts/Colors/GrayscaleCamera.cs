using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleCamera : MonoBehaviour
{
    public Material grayscaleMaterial;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, grayscaleMaterial);
    }

    private void Start()
    {
        ColorController.Instance.OnModeChange += OnModeChange;
        OnModeChange(ColorController.Instance.ColorMode);
    }

    private void OnDestroy()
    {
        ColorController.Instance.OnModeChange -= OnModeChange;
    }

    private void OnModeChange(ColorController.Modes newMode)
    {
        Debug.Log(newMode);
        if (newMode == ColorController.Modes.GRAYSCALE)
        {
            this.enabled = true;
        }
        else
        {
            this.enabled = false;
        }
    }
}
