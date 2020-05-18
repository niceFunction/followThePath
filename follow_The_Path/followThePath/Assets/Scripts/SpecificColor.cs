using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpecificColor : MonoBehaviour
{
    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        // TODO object A should not use object B to set things in object C.
        ColorController.Instance.TileMaterial.color = ColorController.Instance.Colors[index].TileColor;
        ColorController.Instance.FloorMaterial.color = ColorController.Instance.Colors[index].FloorColor;
    }
}