using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleCamera : MonoBehaviour
{

    public Material grayscaleMaterial;

    public void Begin()
    {
        this.enabled = true;
    }

    public void Stop()
    {
        this.enabled = false;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, grayscaleMaterial);
    }
}
