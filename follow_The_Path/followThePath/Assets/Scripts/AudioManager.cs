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

    /// <summary>
    /// Variables used to test if the Ball is moving
    /// </summary>

    [Header("Audio Manager")]
    [Tooltip("Manages sound/volume")]
    [SerializeField]
    private AudioMixer gameMixer;

    [SerializeField]
    private Sound[] sounds;

    public static AudioManager Instance { get; private set; }
    #region Variables used to test sound when the Ball is moving
    /* THIS DID SOMETHING
     * https://answers.unity.com/questions/1116974/roll-a-ball-rolling-sound.html
     * https://answers.unity.com/questions/644841/nullreferenceexception-object-reference-not-set-to-83.html
     * https://answers.unity.com/questions/60764/sound-volume-based-on-rigidbody-velocity-before-co.html
        VARIABLES
        private Ball ball;
        public GameObject ballObject;
        bool didItPlay = false;

        IN START()
        ball = GetComponent<Ball>();

        IN UPDATE()
        if (ballObject.GetComponent<Ball>().RB.velocity.magnitude > 1f && !didItPlay)
        {
            PlaySound("Ball_Roll");
            didItPlay = true;
        }

    */
    #endregion
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
}