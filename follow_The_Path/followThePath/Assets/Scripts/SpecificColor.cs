using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Class that specifies a specific chosen color
/// </summary>
public class SpecificColor : MonoBehaviour
{
    // TODO actually make ColorManager pull this list of colornames and apply to the drop down
    public readonly List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };

    // TODO define the color list (Color32 color and string name) elsewhere, with color and name, and use that for the color settings (dropdown, random, etc)

    public static SpecificColor Instance { get; private set; }

    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        if (index == 0)
        {
            // Set colors to RED
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[0];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[0];
        }
        else if (index == 1)
        {
            // Set colors to ORANGE
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[1];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[1];
        }
        else if (index == 2)
        {
            // Set colors to YELLOW
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[2];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[2];
        }
        else if (index == 3)
        {
            // Set colors to GREEN
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[3];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[3];
        }
        else if (index == 4)
        {
            // Set colors to BLUE
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[4];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[4];
        }
        else if (index == 5)
        {
            // Set colors to INDIGO
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[5];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[5];
        }
        else if (index == 6)
        {
            // Set colors to VIOLET
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.TileColorList[6];
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.FloorColorList[6];
        }
    }
}
