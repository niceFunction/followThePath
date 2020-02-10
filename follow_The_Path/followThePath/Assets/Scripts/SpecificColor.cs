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
    /*
    // colorDropDown and randomizeColorsToggle are used for specifying colors
    [Tooltip("When colors in the level isn't active, user can specifically set level colors")]
    [SerializeField]
    private TMP_Dropdown colorDropdown;
    public TMP_Dropdown ColorDropdown { get { return colorDropdown; } }
    */

    // Variables used to set specific colors
    List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };

    public static SpecificColor Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Populates the dropdown UI menu with a list of strings
    /// </summary>
    public void PopulateColors()
    {
        ColorManager.Instance.ColorDropdown.AddOptions(colorNames);
    }

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
        //Debug.Log("Specific color index is: " + specificIndex);
    }
}
