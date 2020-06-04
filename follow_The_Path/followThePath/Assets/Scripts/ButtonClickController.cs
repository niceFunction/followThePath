using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// Controls when buttons are clicked
/// </summary>
public class ButtonClickController : MonoBehaviour
{

    [SerializeField, Tooltip("Adds enough time for the SFX to play before a scene opens"), Range(0f, 1f)]
    private float delayButtonSound = 0.2f;
    // Note to self: Added incase the value needs to be adjusted
    public float DelayButtonSound { get { return delayButtonSound; } }

    public static ButtonClickController Instance { get; private set; }

    private void Awake()
    {
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
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Calls on the "Begin" method in the "PlayButtonSFX" and plays it
    /// </summary>
    public void PlaySFXOnButton()
    {
        PlayButtonSFX.Instance.Begin();
    }
}
