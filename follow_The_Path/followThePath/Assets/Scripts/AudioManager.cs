using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// AudioManager is responsible for all related to audio
/// </summary>
public class AudioManager : MonoBehaviour
{

    [Tooltip("Manages sound/volume")]
    public AudioMixer gameMixer;

    public Sound[] sounds;

    public static AudioManager instance;

    private float MusicVolume;

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

    public float GetMusicVolume ()
    {
        return MusicVolume;
    }

    public void SetMusicVolume (float volume)
    {

        MusicVolume = volume;
        gameMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        //PlayerPrefs.SetFloat("musicVol", sliderValue);
        //Debug.Log(volume);
        //Debug.Log("Music volume: " + volume);
 
    }
}
