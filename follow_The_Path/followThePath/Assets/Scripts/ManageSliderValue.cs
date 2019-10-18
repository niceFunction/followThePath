using UnityEngine;
using UnityEngine.UI;

// TODO Specifically mentions MUSIC volume slider in summary, since this class specfically manages that.
/// <summary>
/// ManageSliderValue gets volume from AudioManager and puts slider at the correct position.
/// When slider is changed, it sends the new information to AudioManager.
/// </summary>
public class ManageSliderValue : MonoBehaviour // TODO since this class manages the music volume slider, it should be renamed to fit that.
{
    private AudioManager audioManager; // TODO remove this, it is unused and unecessary. AudioManger is accessed through the static variable "instance" in AudioManager.

    [SerializeField]
    private Slider musicSlider;


    // Start is called before the first frame update
    void Start()
    {
        /* 
         This "remembers" the positioning of the slider, but the
         slider still loses the "onValueChanged" reference.
        */
        //musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        musicSlider.value = AudioManager.instance.GetMusicVolume();   
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(musicSlider);
    }
}
