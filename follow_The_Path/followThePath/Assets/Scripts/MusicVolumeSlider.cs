using UnityEngine;
using UnityEngine.UI;

// TODO remove this class, it is replaced by the more general VolumeSlider
/// <summary>
/// ManageSliderValue gets volume from AudioManager and puts slider at the correct position.
/// When slider is changed, it sends the new information to AudioManager.
/// </summary>
public class MusicVolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }

    public void MusicChangeVolume()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        PlayerPrefs.Save();
    }
}
