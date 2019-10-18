using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// ManageSliderValue gets volume from AudioManager and puts slider at the correct position.
/// When slider is changed, it sends the new information to AudioManager.
/// </summary>
public class ManageSliderValue : MonoBehaviour
{
    private AudioManager audioManager;

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
