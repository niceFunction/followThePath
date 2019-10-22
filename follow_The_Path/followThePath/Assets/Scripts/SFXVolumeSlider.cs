﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO remove this class, it is replaced by the more general VolumeSlider
public class SFXVolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
    }

    public void SFXChangeVolume()
    {
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
        PlayerPrefs.Save();
    }

}
