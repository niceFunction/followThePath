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
    private List<string> storeColorNames = new List<string>();

    readonly string USE_SPECIFIC_COLOR;
    bool useSpecificColor;

    public static SpecificColor Instance { get; private set; }

    private void Start()
    {

        AddColorNamesToDropdown();
        PlayerPrefs.GetInt(USE_SPECIFIC_COLOR);
    }

    private void Awake()
    {

    }

    /// <summary>
    /// Populates the "SetSpecificColor" dropdown with the names of colors from ColorList
    /// </summary>
    private void AddColorNamesToDropdown() // For reference: This could be any items that uses List
    {
        for (int i = 0; i < UxManager.Instance.ColorList.Length; i++)
        {
            UxManager.Instance.ColorDropdown.ClearOptions();
            storeColorNames.Add(UxManager.Instance.ColorList[i].Name);
            UxManager.Instance.ColorDropdown.AddOptions(storeColorNames);
        }
    }    

    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        //TODO: when specifying colors is inactive, replace the "SpecificColorsDropdown" strings with a string that says "Select a Color" or something
        if (index == 0)
        {
            // Set colors to RED
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[0].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[0].FloorColor;
        }
        else if (index == 1)
        {
            // Set colors to ORANGE
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[1].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[1].FloorColor;
        }
        else if (index == 2)
        {
            // Set colors to YELLOW
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[2].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[2].FloorColor;
        }
        else if (index == 3)
        {
            // Set colors to GREEN
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[3].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[3].FloorColor;
        }
        else if (index == 4)
        {
            // Set colors to BLUE
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[4].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[4].FloorColor;
        }
        else if (index == 5)
        {
            // Set colors to INDIGO
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[5].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[5].FloorColor;
        }
        else if (index == 6)
        {
            // Set colors to VIOLET
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[6].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[6].FloorColor;
        }

        PlayerPrefs.SetInt(USE_SPECIFIC_COLOR, index);
    }
}