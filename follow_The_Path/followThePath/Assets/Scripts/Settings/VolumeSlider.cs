using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Connects a GUI Slider to the AudioManager.
/// Sets the value of the slider on start, and passed changes to AudioManager.
/// </summary>
[RequireComponent(typeof(Slider))] // This component requires a Slider on the same game object
[DisallowMultipleComponent] // This component must not exist twice on the same game object.
public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    [SerializeField, Tooltip("Which exposed parameter does this slider adjust?")]
    AudioManager.MixerVolume parameter;

    /// <summary>
    /// Set the correct volume value on the slider.
    /// </summary>
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioManager.Instance.GetVolume(parameter);
    }
    
    public void ChangeVolume()
    {
        AudioManager.Instance.SetVolume(parameter, slider.value);
    }
}
