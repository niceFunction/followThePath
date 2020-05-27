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
    [SerializeField] private Grayscale grayscale;

    // Get a list of pre-defined colors
    [SerializeField] private ColorList colorList;
    // Get the materials used on the Tiles & Floors
    [SerializeField] private Material tileMaterial, floorMaterial;
    public static ColorController Instance { get; private set; }

    // A key used to save the current index in the list of pre-defined colors
    readonly string SPECIFIC_COLOR_INDEX = "SPECIFIC_COLOR_INDEX";
    // A key used to save what color mode should be active
    readonly string COLOR_MODE = "COLOR_MODE";

    public bool UseRandomColors { get { return ColorMode == Modes.RANDOM; } }
    public bool UseGrayscaleMode { get { return ColorMode == Modes.GRAYSCALE; } }
    public bool UseSpecificColor { get { return ColorMode == Modes.SPECIFIC; } }
    // All colors in the Colorlist are individual index, starting from 0 and ending at 6
    public int SpecificColorIndex { get; private set; } = 0;

    public Material TileMaterial { get { return tileMaterial; } }
    public Material FloorMaterial { get { return floorMaterial; } }
    public Colors.ColorGroup[] Colors { get { return colorList.Colors; } }

    // What mode is currently active?
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
    }

    private void Start()
    {
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
        grayscale.Stop();
        randomColor.Stop();
        specificColor.Stop();

        GetCurrentMode().Begin();
    }


    private IColorMode GetCurrentMode()
    {
        if (ColorMode == Modes.GRAYSCALE)
        {
            return grayscale;
        }
        else if (ColorMode == Modes.RANDOM)
        {
            return randomColor;
        }
        else if (ColorMode == Modes.SPECIFIC)
        {
            return specificColor;
        }
        else
        {
            Debug.LogError("Unknown color mode " + ColorMode);
            return null;
        }
    }

    public void SetColorMode(Modes newMode)
    {
        // Sets "newMode" to whatever new mode is active
        if (newMode == ColorMode)
            return;

        Debug.Log("From " + ColorMode + " to " + newMode);

        // Stop the current mode, before switching
        GetCurrentMode().Stop();
        
        ColorMode = newMode;

        // Start the new mode
        GetCurrentMode().Begin();

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

        specificColor.Begin();
        //specificColor.ParticularColor(index);
    }
}
