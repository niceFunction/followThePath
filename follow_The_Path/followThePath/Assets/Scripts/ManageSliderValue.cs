using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
        
    }
}
