﻿using System.Collections;
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
    readonly string USE_SPECIFIC_COLOR = "USE_SPECIFIC_COLOR";
    readonly string SPECIFIC_COLOR_INDEX = "SPECIFIC_COLOR_INDEX";

    public bool UseRandomColors { get; private set; } = true;
    public bool UseGrayscaleMode { get; private set; } = false;
    public bool UseSpecificColor { get; private set; } = false;
    public int SpecificColorIndex { get; private set; } = 0;


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

    }

    public void SetUseRandomColors(bool on)
    {
        UseRandomColors = on;
        PlayerPrefsX.SetBool(USE_RANDOM_COLORS, UseRandomColors);
        PlayerPrefs.Save();
    }

    public void SetUseGrayscaleOverlay(bool on)
    {
        UseGrayscaleMode = on;
        PlayerPrefsX.SetBool(USE_GRAYSCALE_MODE, UseGrayscaleMode);
        PlayerPrefs.Save();
    }

    public void SetSpecificColor(int index)
    {
        SpecificColorIndex = index;
        UseSpecificColor = true;

        PlayerPrefs.SetInt(SPECIFIC_COLOR_INDEX, SpecificColorIndex);
        PlayerPrefsX.SetBool(USE_SPECIFIC_COLOR, UseSpecificColor);
        PlayerPrefs.Save();
    }
}
