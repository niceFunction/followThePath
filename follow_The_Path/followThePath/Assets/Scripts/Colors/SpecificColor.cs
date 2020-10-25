using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpecificColor : MonoBehaviour, IColorMode
{
    public void Begin()
    {
        ColorController.Instance.TileMaterial.color = ColorController.Instance.Colors[ColorController.Instance.SpecificColorIndex].TileColor;
        ColorController.Instance.FloorMaterial.color = ColorController.Instance.Colors[ColorController.Instance.SpecificColorIndex].FloorColor;
    }

    public void Stop()
    {
        // No action necessary, no process is running
    }
}