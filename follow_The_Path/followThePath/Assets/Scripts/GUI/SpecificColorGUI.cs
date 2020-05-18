using System;
using UnityEngine;
using TMPro;

public class SpecificColorGUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown colorDropdown;

    private void Start()
    {
        ColorController.Instance.OnModeChange += ChangeColorMode;

        // Fake color mode change to get the correct start value
        ChangeColorMode(ColorController.Instance.ColorMode);
    }
    private void OnDestroy()
    {
        ColorController.Instance.OnModeChange -= ChangeColorMode;
    }

    private void ChangeColorMode(ColorController.Modes newMode)
    {
        // TODO fade in/out dropdown list 
        if (newMode == ColorController.Modes.SPECIFIC)
        {
            colorDropdown.interactable = true;
        }
        else
        {
            colorDropdown.interactable = false;
        }
    }

    public void SetSpecificColor(int index)
    {
        ColorController.Instance.SetSpecificColor(index);
    }
}
