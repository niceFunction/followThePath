using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To control colors in game.
/// </summary>
public class ColorController : MonoBehaviour
{
    public static ColorController Instance { get; private set; }

    readonly string USE_RANDOM_COLORS = "USE_RANDOM_COLORS";
    readonly string USE_GRAYSCALE_MODE = "USE_GRAYSCALE_MODE";

    public bool UseRandomColors { get; private set; } = true;
    public bool UseGrayscaleMode { get; private set; } = false;


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

        LoadPlayerPrefs();
        Initialize();
    }

    /// <summary>
    /// Loads saved Color player prefs.
    /// </summary>
    private void LoadPlayerPrefs()
    {
        UseRandomColors = PlayerPrefsX.GetBool(USE_RANDOM_COLORS);
        UseGrayscaleMode = PlayerPrefsX.GetBool(USE_GRAYSCALE_MODE);
    }

    /// <summary>
    /// Initializes everything in this controller.
    /// </summary>
    public void Initialize()
    {

    }

    public void SetUseRandomColors(bool on)
    {
        this.UseRandomColors = on;
        PlayerPrefsX.SetBool(USE_RANDOM_COLORS, UseRandomColors);
        PlayerPrefs.Save();
    }

    public void SetUseGrayscaleOverlay(bool on)
    {
        this.UseGrayscaleMode = on;
        PlayerPrefsX.SetBool(USE_GRAYSCALE_MODE, UseGrayscaleMode);
        PlayerPrefs.Save();
    }
}
