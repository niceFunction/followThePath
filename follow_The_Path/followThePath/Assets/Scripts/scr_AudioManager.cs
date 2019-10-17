using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class scr_AudioManager : MonoBehaviour
{

    [Tooltip("Manages sound/volume")]
    public AudioMixer gameMixer;

    public Sound[] sounds;

    public static scr_AudioManager instance;
    //public Slider musicSlider;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }
    }

    void Start()
    {
        
        //musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        

        PlaySound("MainTheme_01");
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void SetMusicVol (float sliderValue)
    {
        gameMixer.SetFloat("musicVolume", Mathf.Log10(sliderValue) * 20);
        //PlayerPrefs.SetFloat("musicVol", sliderValue);
        Debug.Log(sliderValue);
 
    }
}
