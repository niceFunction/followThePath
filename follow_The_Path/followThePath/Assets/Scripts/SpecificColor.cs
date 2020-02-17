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
    public List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };

    private List<string> storeColorNames = new List<string>();

    private void Start()
    {
        for (int i = 0; i < ColorManager.Instance.ColorList.Length; i++)
        {
            ColorManager.Instance.ColorDropdown.ClearOptions();
            storeColorNames.Add(ColorManager.Instance.ColorList[i].Name);
            ColorManager.Instance.ColorDropdown.AddOptions(storeColorNames);
        }
    }

    public static SpecificColor Instance { get; private set; }

    private void Awake()
    {

    }

    /// <summary>
    /// Populates the "SetSpecificColor" dropdown with the names of colors from ColorList
    /// </summary>
    /* Unnecessary?
    private void AddColorNamesToDropdown() // For reference: This could be any items that uses List
    {
        for (int i = 0; i < ColorManager.Instance.ColorList.Length; i++)
        {
            ColorManager.Instance.ColorDropdown.ClearOptions();
            storeColorNames.Add(ColorManager.Instance.ColorList[i].Name);
            ColorManager.Instance.ColorDropdown.AddOptions(storeColorNames);
        }
    }
    */

    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        if (index == 0)
        {
            // Set colors to RED
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[0].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[0].FloorColor;
        }
        else if (index == 1)
        {
            // Set colors to ORANGE
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[1].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[1].FloorColor;
        }
        else if (index == 2)
        {
            // Set colors to YELLOW
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[2].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[2].FloorColor;
        }
        else if (index == 3)
        {
            // Set colors to GREEN
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[3].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[3].FloorColor;
        }
        else if (index == 4)
        {
            // Set colors to BLUE
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[4].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[4].FloorColor;
        }
        else if (index == 5)
        {
            // Set colors to INDIGO
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[5].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[5].FloorColor;
        }
        else if (index == 6)
        {
            // Set colors to VIOLET
            ColorManager.Instance.TileMaterial.color = ColorManager.Instance.ColorList[6].TileColor;
            ColorManager.Instance.FloorMaterial.color = ColorManager.Instance.ColorList[6].FloorColor;
        }
    }
}