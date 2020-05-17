﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpecificColor : MonoBehaviour
{

    public static SpecificColor Instance { get; private set; }

    private void Start()
    {
        AddColorNamesToDropdown();
        GetDropdownValue();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// Populates the "SetSpecificColor" dropdown with the names of colors from ColorList
    /// </summary>
    private void AddColorNamesToDropdown() // For reference: This could be any items that uses List
    {
        // Clear current options
        UxManager.Instance.ColorDropdown.ClearOptions();

        // Intialize list of new options
        List<TMP_Dropdown.OptionData> dropdownData = new List<TMP_Dropdown.OptionData>();

        // Loop thtough all colors and add to new list
        for (int i = 0; i < UxManager.Instance.ColorList.Length; i++)
        {
            // Retrive one entry from the Colorlist
            Colors.ColorGroup c = UxManager.Instance.ColorList[i];

            // A new OptionData to the new data list
            dropdownData.Add(new TMP_Dropdown.OptionData(c.Name, c.ColorSprite));
        }

        // Set new list as current options
        UxManager.Instance.ColorDropdown.AddOptions(dropdownData);
    }
    
    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        ColorController.Instance.SetSpecificColor(index);

        // THIS COLOR IS NEVER SAVED
        UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[index].TileColor;
        UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[index].FloorColor;
    }


    void GetDropdownValue()
    {
        UxManager.Instance.ColorDropdown.value = ColorController.Instance.SpecificColorIndex;
    }

}