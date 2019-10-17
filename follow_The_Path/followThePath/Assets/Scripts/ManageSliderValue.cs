using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ManageSliderValue : MonoBehaviour
{
    private AudioManager audioManager;

    private Slider musicSlider;


    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = AudioManager.instance.GetMusicVolume();   
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
