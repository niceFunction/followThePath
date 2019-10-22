using UnityEngine.Audio;
using System;
using UnityEngine;

/// <summary>
/// AudioManager is responsible for all related to audio
/// </summary>
public class AudioManager : MonoBehaviour
{
    [Tooltip("Manages sound/volume")]
    [SerializeField]
    private AudioMixer gameMixer;

    [SerializeField]
    private Sound[] sounds;

    public static AudioManager Instance { get; private set; }

    private float MusicVolume;
    private float SFXVolume;
    private Ball Ball;
    // private float nominalSpeed = 1f;

    private float GameMixerVolume;

    // Start is called before the first frame update
    void Awake()
    {
        #region Sound Array
        if (Instance == null)
        {
            Instance = this;
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
        #endregion
    }

    void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat("musicVolume", MusicVolume);
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

    public void PlayBallSound ()
    {
        //Ball.RB.velocity.magnitude / nominalSpeed;
    }

    /// <summary>
    /// Returns the current music volume.
    /// </summary>
    /// <returns></returns>
    public float GetMusicVolume ()
    {
        return MusicVolume;
    }

    /// <summary>
    /// Sets the current music volume.
    /// </summary>
    /// <param name="volume">The volume music should have, from 0.0 to 1.0</param>
    public void SetMusicVolume (float volume)
    {
        MusicVolume = volume;
        gameMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", MusicVolume);
        PlayerPrefs.Save();
    }

    public float GetSFXVolume ()
    {
        return SFXVolume;
    }
    
    public void SetSFXVolume (float volume)
    {
        SFXVolume = volume;
        // Adjust volume
        // "something here".SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", SFXVolume);
        PlayerPrefs.Save();
    }
}
