using UnityEngine;

public class GrayscaleGUI : MonoBehaviour
{
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
        if (newMode == ColorController.Modes.GRAYSCALE)
        {
            statusText.text = "ON";
        }
        else
        {
            statusText.text = "OFF";
        }
    }


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
