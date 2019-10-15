using UnityEngine.Audio;
using System;
using UnityEngine;

public class scr_AudioManager : MonoBehaviour
{
    [Tooltip("Manages sound/volume")]
    public AudioMixer gameMixer;

    public Sound[] sounds;

    public static scr_AudioManager instance;

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
        // Play Main Theme here?
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

    public void SetMusicVol (float musicVol)
    {
        //TODO: musicVol_1: While volume can be set, slider isn't saved in the set position when returning to menu
        //TODO: musicVol_2: When returning to settings, the slider is "full" and the music is still low.
        gameMixer.SetFloat("musicVolume", 20f * Mathf.Log10(musicVol));
        Debug.Log(musicVol);
    }
}
