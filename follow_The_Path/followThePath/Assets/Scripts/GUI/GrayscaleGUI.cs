using UnityEngine;
using UnityEngine.UI;

public class GrayscaleGUI : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMPro.TextMeshProUGUI statusText;

    private void Start()
    {
        ColorController.Instance.OnModeChange += OnChangeColorMode;

        // Fake color mode change to get the correct start value
        OnChangeColorMode(ColorController.Instance.ColorMode);
    }
    private void OnDestroy()
    {
        ColorController.Instance.OnModeChange -= OnChangeColorMode;
    }

    /// <summary>
    /// What happens when GRAYSCALE mode is on or not
    /// </summary>
    /// <param name="newMode"></param>
    private void OnChangeColorMode(ColorController.Modes newMode)
    {
        if (newMode == ColorController.Modes.GRAYSCALE)
        {
            statusText.text = "ON";
            toggle.isOn = true;
        }
        else
        {
            statusText.text = "OFF";
            toggle.isOn = false;
        }
    }

    /// <summary>
    /// Called from Unity GUI
    /// </summary>
    /// <param name="on"></param>
    public void SetGrayscale(bool on)
    {
        if (on)
        {
            ColorController.Instance.SetColorMode(ColorController.Modes.GRAYSCALE);
        }
        else
        {
            ColorController.Instance.SetColorMode(ColorController.Modes.RANDOM);
        }
    }
}
