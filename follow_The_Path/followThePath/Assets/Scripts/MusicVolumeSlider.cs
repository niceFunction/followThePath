﻿using UnityEngine;
using UnityEngine.UI;

// TODO Specifically mentions MUSIC volume slider in summary, since this class specfically manages that.
/// <summary>
/// ManageSliderValue gets volume from AudioManager and puts slider at the correct position.
/// When slider is changed, it sends the new information to AudioManager.
/// </summary>
public class MusicVolumeSlider : MonoBehaviour
{
    //johnleonardfrench.com/articles/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/
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
    }
}
