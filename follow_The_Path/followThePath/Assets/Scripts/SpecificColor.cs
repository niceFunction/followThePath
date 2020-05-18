using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpecificColor : MonoBehaviour
{
    private void Start()
    {
        AddColorNamesToDropdown();
        GetDropdownValue();
    }

    /// <summary>
    /// Populates the "SetSpecificColor" dropdown with the names of colors from ColorList
    /// </summary>
    private void AddColorNamesToDropdown() // For reference: This could be any items that uses List
    {
        // TODO object A should not use object B to set things in object C.
        UxManager.Instance.ColorDropdown.ClearOptions();

        // Intialize list of new options
        List<TMP_Dropdown.OptionData> dropdownData = new List<TMP_Dropdown.OptionData>();

        // Loop thtough all colors and add to new list
        for (int i = 0; i < ColorController.Instance.Colors.Length; i++)
        {
            // Retrive one entry from the Colorlist
            Colors.ColorGroup c = ColorController.Instance.Colors[i];

            // A new OptionData to the new data list
            dropdownData.Add(new TMP_Dropdown.OptionData(c.Name, c.ColorSprite));
        }

        // TODO object A should not use object B to set things in object C.
        UxManager.Instance.ColorDropdown.AddOptions(dropdownData);
    }
    
    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        // TODO object A should not use object B to set things in object C.
        UxManager.Instance.TileMaterial.color = ColorController.Instance.Colors[index].TileColor;
        UxManager.Instance.FloorMaterial.color = ColorController.Instance.Colors[index].FloorColor;
    }


    void GetDropdownValue()
    {
        // TODO object A should not use object B to set things in object C.
        UxManager.Instance.ColorDropdown.value = ColorController.Instance.SpecificColorIndex;
    }

}