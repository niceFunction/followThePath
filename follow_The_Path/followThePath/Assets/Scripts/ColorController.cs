using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To control colors in game.
/// </summary>
public class ColorController : MonoBehaviour
{
    [SerializeField] private RandomColor randomColor;
    [SerializeField] private SpecificColor specificColor;

    public static ColorController Instance { get; private set; }

    readonly string USE_RANDOM_COLORS = "USE_RANDOM_COLORS";
    readonly string USE_GRAYSCALE_MODE = "USE_GRAYSCALE_MODE";
    readonly string USE_SPECIFIC_COLOR = "USE_SPECIFIC_COLOR";
    readonly string SPECIFIC_COLOR_INDEX = "SPECIFIC_COLOR_INDEX";
    readonly string COLOR_MODE = "COLOR_MODE";

    public bool UseRandomColors { get; private set; } = true;
    public bool UseGrayscaleMode { get; private set; } = false;
    public bool UseSpecificColor { get; private set; } = false;
    public int SpecificColorIndex { get; private set; } = 0;


    public enum ColorModes { RANDOM = 0, SPECIFIC = 1, GRAYSCALE = 2 }
    public ColorModes ColorMode;

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
        ColorMode = (ColorModes)PlayerPrefs.GetInt(COLOR_MODE, 0);
        UseRandomColors = PlayerPrefsX.GetBool(USE_RANDOM_COLORS, UseRandomColors);
        UseGrayscaleMode = PlayerPrefsX.GetBool(USE_GRAYSCALE_MODE, UseGrayscaleMode);
        UseSpecificColor = PlayerPrefsX.GetBool(USE_SPECIFIC_COLOR, UseSpecificColor);
        SpecificColorIndex = PlayerPrefs.GetInt(SPECIFIC_COLOR_INDEX, 0);
    }

    /// <summary>
    /// Initializes everything in this controller.
    /// </summary>
    public void Initialize()
    {
        if (UseRandomColors)
        {
            randomColor.StartRandomColor();
        }
    }

    public void SetUseGrayscaleOverlay(bool on)
    {
        UseGrayscaleMode = on;
        SetColorMode(ColorModes.GRAYSCALE);
        PlayerPrefsX.SetBool(USE_GRAYSCALE_MODE, UseGrayscaleMode);
        PlayerPrefs.Save();
    }

    public void SetSpecificColor(int index)
    {
        Debug.Log("Set specific color");
        SpecificColorIndex = index;
        UseSpecificColor = true;

        SetColorMode(ColorModes.SPECIFIC);
        PlayerPrefs.SetInt(SPECIFIC_COLOR_INDEX, SpecificColorIndex);
        PlayerPrefsX.SetBool(USE_SPECIFIC_COLOR, UseSpecificColor);
        PlayerPrefs.Save();

        specificColor.ParticularColor(index);
    }

    public void StopRandomColor()
    {
        StopCoroutine(randomColor.InitiateRandomColors);
    }

    public void SetRandomColorMode(bool on)
    {
        UseRandomColors = on;
        SetColorMode(on ? ColorModes.RANDOM : ColorModes.SPECIFIC);
        PlayerPrefsX.SetBool(USE_RANDOM_COLORS, UseRandomColors);
        PlayerPrefs.Save();

        if (on)
        {
            randomColor.StartRandomColor();
        }
        else
        {
            randomColor.StopRandomColor();
        }
    }

    void SetColorMode(ColorModes mode)
    {
        Debug.Log(mode);
        ColorMode = mode;
        PlayerPrefs.SetInt(COLOR_MODE, (int)ColorMode);
    }
}
