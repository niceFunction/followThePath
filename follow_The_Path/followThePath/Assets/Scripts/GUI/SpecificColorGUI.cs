using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;

public class SpecificColorGUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown colorDropdown;


    [SerializeField, Header("Dropdown menu items"), Tooltip("Objects found in the dropdown menu")]
    private UiItems.DropdownGroup dropdownItemGroup;

    private void Start()
    {
        ColorController.Instance.OnModeChange += OnChangeColorMode;

        // Fake color mode change to get the correct start value
        OnChangeColorMode(ColorController.Instance.ColorMode);

        InitializeDropdown();
    }
    private void OnDestroy()
    {
        ColorController.Instance.OnModeChange -= OnChangeColorMode;
    }

    /// <summary>
    /// Populates the "SetSpecificColor" dropdown with the names of colors from ColorList
    /// </summary>
    private void InitializeDropdown() // For reference: This could be any items that uses List
    {
        colorDropdown.ClearOptions();

        // Intialize list of new options
        List<TMP_Dropdown.OptionData> dropdownData = new List<TMP_Dropdown.OptionData>();

        // Loop through all colors and add to new list
        for (int i = 0; i < ColorController.Instance.Colors.Length; i++)
        {
            // Retrive one entry from the Colorlist
            Colors.ColorGroup c = ColorController.Instance.Colors[i];

            // A new OptionData to the new data list
            dropdownData.Add(new TMP_Dropdown.OptionData(c.Name, c.ColorSprite));
        }

        colorDropdown.AddOptions(dropdownData);

        colorDropdown.value = ColorController.Instance.SpecificColorIndex;
    }

    private void OnChangeColorMode(ColorController.Modes newMode)
    {
        // TODO fade in/out dropdown list 
        if (newMode == ColorController.Modes.SPECIFIC)
        {
            FadeBackDropdownObjects();
            colorDropdown.interactable = true;
        }
        else
        {
            FadeDropdownObjects();
            colorDropdown.interactable = false;
        }
    }

    /// <summary>
    /// Called from Unity GUI
    /// </summary>
    /// <param name="on"></param>
    public void SetSpecificColor(int index)
    {
        ColorController.Instance.SetSpecificColor(index);
    }

    /// <summary>
    /// Used to make certain objects inside the dropdown menu transparent to indicate the object isn't interactable
    /// </summary>
    private void FadeDropdownObjects()
    {
        //TODO Personal reminder: rename dropdownItemGroup to something like "specificColor"?
        dropdownItemGroup.DropdownText.DOFade(dropdownItemGroup.Alpha, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownArrowImage.DOFade(dropdownItemGroup.Alpha, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownCaptionImage.DOFade(dropdownItemGroup.Alpha, dropdownItemGroup.TweenTime);
    }

    /// <summary>
    ///  Used to make certain objects inside the dropdown menu transparent to indicate the object can be interacted with again
    /// </summary>
    private void FadeBackDropdownObjects()
    {
        dropdownItemGroup.DropdownText.DOFade(1, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownArrowImage.DOFade(1, dropdownItemGroup.TweenTime);
        dropdownItemGroup.DropdownCaptionImage.DOFade(1, dropdownItemGroup.TweenTime);
    }
}
