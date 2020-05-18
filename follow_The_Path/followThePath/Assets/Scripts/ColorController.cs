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

    public bool UseRandomColors { get { return ColorMode == Modes.RANDOM; } }
    public bool UseGrayscaleMode { get { return ColorMode == Modes.GRAYSCALE; } }
    public bool UseSpecificColor { get { return ColorMode == Modes.SPECIFIC; } }
    public int SpecificColorIndex { get; private set; } = 0;
    public Colors.ColorGroup[] Colors { get { return colorList.Colors; } }

    public delegate void ColorModeHandler(Modes newMode);
    public event ColorModeHandler OnModeChange;

    public enum Modes { RANDOM = 0, SPECIFIC = 1, GRAYSCALE = 2 }
    public Modes ColorMode;

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
        ColorMode = (Modes)PlayerPrefs.GetInt(COLOR_MODE, 0);
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

    public void SetColorMode(Modes newMode)
    {
        if (newMode == ColorMode)
            return;

        /*
         * TODO rewrite RandomColor, SpecificColor, and Grayscale into
         * using an interface with a Start and Stop.
         * Then we can handle them easily.
         */

        Debug.Log("From " + ColorMode + " to " + newMode);
        ColorMode = newMode;
        PlayerPrefs.SetInt(COLOR_MODE, (int)ColorMode);
        PlayerPrefs.Save();

        if(OnModeChange != null)
        {
            OnModeChange.Invoke(ColorMode);
        }
    }

    public void SetSpecificColor(int index)
    {
        Debug.Log("Set specific color");

      //  SetColorMode(Modes.SPECIFIC);

        SpecificColorIndex = index;

        PlayerPrefs.SetInt(SPECIFIC_COLOR_INDEX, SpecificColorIndex);
        PlayerPrefs.Save();


        specificColor.ParticularColor(index);
    }
}
