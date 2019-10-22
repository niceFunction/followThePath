using UnityEngine.Audio;
using System;
using UnityEngine;

/// <summary>
/// AudioManager is responsible for all related to audio
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Each entry in MixerGroup correspond to one exposed volume parameter in the mixer.
    /// Add a new value to this enum for each new volume paramter you expose - with the exact same name!
    /// </summary>
    public enum MixerVolume { masterVolume, musicVolume, sfxVolume }

    [Tooltip("Manages sound/volume")]
    [SerializeField]
    private AudioMixer gameMixer;

    [SerializeField]
    private Sound[] sounds;

    public static AudioManager Instance { get; private set; }

    private float MusicVolume; // TODO delete this, variable no longer used. Value is read from PlayerPrefs
    private float SFXVolume; // TODO delete this, variable no longer used. Value is read from PlayerPrefs
    private Ball Ball;
    // private float nominalSpeed = 1f;

    private float GameMixerVolume; // Delete unused reference

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
        LoadVolume(MixerVolume.musicVolume);
        LoadVolume(MixerVolume.sfxVolume);
        PlaySound("MainTheme_01");
    }

    /// <summary>
    /// Loads the specified volume from PlayerPrefs and applies it to the GameMixer
    /// </summary>
    /// <param name="parameter">Specific parameter to fetch</param>
    private void LoadVolume(MixerVolume parameter)
    {
        UpdateVolume(parameter, GetLogVolume(PlayerPrefs.GetFloat(parameter.ToString(), 1.0f)));
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
        // TODO Remove this method, it is replaced by GetVolume(MixerVolume)
        return MusicVolume;
    }

    /// <summary>
    /// Returns the set volume on the game mixer for the specified parameters.
    /// </summary>
    /// <param name="mixerParameter">Exposed parameter to read</param>
    /// <returns></returns>
    public float GetVolume(MixerVolume mixerParameter)
    {
        return PlayerPrefs.GetFloat(mixerParameter.ToString(), 1.0f);
    }

    /// <summary>
    /// Sets the current music volume.
    /// </summary>
    /// <param name="volume">The volume music should have, from 0.0 to 1.0</param>
    public void SetMusicVolume (float volume)
    {
        // TODO remove this method, it is replaced by SetVolume(MixerVolume, float)
        MusicVolume = volume;
        gameMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", MusicVolume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Sets the volume for the specified mixer group.
    /// </summary>
    /// <param name="mixerGroup">Mixer group to update volume for.</param>
    /// <param name="volume">Volume to set, from 0-1 (representing 0% and 100%)</param>
    public void SetVolume(MixerVolume mixerParameter, float volume)
    {
        // Save to player prefs
        PlayerPrefs.SetFloat(mixerParameter.ToString(), volume);
        PlayerPrefs.Save();

        // Get adjusted volume
        float adjustedVolume = GetLogVolume(volume);

        // Update the actual volume
        UpdateVolume(mixerParameter, adjustedVolume);
    }

    /// <summary>
    /// Actually updates the volume on the game mixer.
    /// </summary>
    /// <param name="mixerParameter">The exposed paramter to update</param>
    /// <param name="adjustedVolume">The new value</param>
    private void UpdateVolume(MixerVolume mixerParameter, float adjustedVolume)
    {
        gameMixer.SetFloat(mixerParameter.ToString(), adjustedVolume);
    }

    /// <summary>
    /// Simply calculates the adjusted volume to set on the mixer group.
    /// Because 0-1 which slider values give is not good enough, and should represent 0% to 100%.
    /// This method calculates the adjusted volume instead.
    /// </summary>
    /// <param name="volume">Actual volume to set.</param>
    /// <returns></returns>
    private float GetLogVolume(float volume)
    {
        return Mathf.Log10(volume) * 20;
    }

    public float GetSFXVolume ()
    {
        // TODO Remove this method, it is replaced by GetVolume(MixerVolume)
        return SFXVolume;
    }
    
    public void SetSFXVolume (float volume)
    {
        // TODO remove this method, it is replaced by SetVolume(MixerVolume, float)
        SFXVolume = volume;
        // Adjust volume
        // "something here".SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", SFXVolume);
        PlayerPrefs.Save();
    }
}
