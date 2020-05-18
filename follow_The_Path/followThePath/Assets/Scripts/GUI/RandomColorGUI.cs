using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorGUI : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMPro.TextMeshProUGUI statusText;

    [SerializeField] private UiItems.ToggleGroup tweenObjects;

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

    private void OnChangeColorMode(ColorController.Modes newMode)
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
            FadeRandomColorToggleObject();
            toggle.interactable = false;
        }
        else
        {
            FadeBackRandomColorToggleObject();
            toggle.interactable = true;
        }
    }

    /// <summary>
    /// Fades the toggle object for "Random Level Color" away to indicate the object can't be interacted with
    /// </summary>
    public void FadeRandomColorToggleObject()
    {
        //TODO Personal reminder: rename FadeRandomColorToggleObject to something easier to remember?
        tweenObjects.ToggleActiveText.DOFade(tweenObjects.Alpha, tweenObjects.TweenTime);
        tweenObjects.ToggleBackgroundImage.DOFade(tweenObjects.Alpha, tweenObjects.TweenTime);
    }

    /// <summary>
    /// Fades the toggle object for "Random Level Color" back to indicate the object can be interacted with
    /// </summary>
    public void FadeBackRandomColorToggleObject()
    {
        tweenObjects.ToggleActiveText.DOFade(1, tweenObjects.TweenTime);
        tweenObjects.ToggleBackgroundImage.DOFade(1, tweenObjects.TweenTime);
    }

    /// <summary>
    /// Called from Unity GUI
    /// </summary>
    /// <param name="on"></param>
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