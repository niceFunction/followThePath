using UnityEngine;
using UnityEngine.UI;

public class RandomColorGUI : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMPro.TextMeshProUGUI statusText;

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
        if (newMode == ColorController.Modes.RANDOM)
        {
            statusText.text = "ON";
            toggle.isOn = true;
        }
        else
        {
            statusText.text = "OFF";
            toggle.isOn = false;
        }


        if (newMode == ColorController.Modes.GRAYSCALE)
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }
    }


    public void SetRandomColorMode(bool on)
    {
        if (ColorController.Instance.ColorMode == ColorController.Modes.GRAYSCALE)
            return;

        if (on)
        {
            ColorController.Instance.SetColorMode(ColorController.Modes.RANDOM);
        }
        else
        {
            ColorController.Instance.SetColorMode(ColorController.Modes.SPECIFIC);
        }
    }
}