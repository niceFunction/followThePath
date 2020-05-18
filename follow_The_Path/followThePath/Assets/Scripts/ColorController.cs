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
    [SerializeField] private ColorList colorList;

    public static ColorController Instance { get; private set; }

    readonly string SPECIFIC_COLOR_INDEX = "SPECIFIC_COLOR_INDEX";
    readonly string COLOR_MODE = "COLOR_MODE";

    public bool UseRandomColors { get { return ColorMode == ColorModes.RANDOM; } }
    public bool UseGrayscaleMode { get { return ColorMode == ColorModes.GRAYSCALE; } }
    public bool UseSpecificColor { get { return ColorMode == ColorModes.SPECIFIC; } }
    public int SpecificColorIndex { get; private set; } = 0;
    public Colors.ColorGroup[] Colors { get { return colorList.Colors; } }


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

    public void SetUseGrayscaleOverlay()
    {
        SetColorMode(ColorModes.GRAYSCALE);
    }

    public void SetSpecificColor(int index)
    {
        Debug.Log("Set specific color");
        SpecificColorIndex = index;

        SetColorMode(ColorModes.SPECIFIC);
        PlayerPrefs.SetInt(SPECIFIC_COLOR_INDEX, SpecificColorIndex);
        PlayerPrefs.Save();

        specificColor.ParticularColor(index);
    }

    public void StopRandomColor()
    {
        StopCoroutine(randomColor.InitiateRandomColors);
    }

    public void SetRandomColorMode(bool on)
    {
        SetColorMode(on ? ColorModes.RANDOM : ColorModes.SPECIFIC);
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
        PlayerPrefs.Save();
    }
}
