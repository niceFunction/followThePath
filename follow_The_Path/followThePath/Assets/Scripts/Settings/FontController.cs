using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontController : MonoBehaviour
{
    // Key used for PlayerPrefs, used to save the current status of the dyslexic font and it if its used or not
    readonly string USE_DYSLEXIC_FONT = "USE_DYSLEXIC_FONT";

    public delegate void ChangeFontHandler(TMP_FontAsset newFont, float scaleFont);
    public event ChangeFontHandler OnChangeFont;

    public static FontController Instance { get; private set; }

    // Get the current "active" font
    public TMP_FontAsset CurrentFont { get; private set; }
    // Get the current "active" fonts scale
    public float CurrentScale { get; private set; }
    // Should the font use the dyslexic font?
    public bool UseDyslexicFont { get; private set; } = false;

    [SerializeField] private FontSettings regular, dyslexic;

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
        UseDyslexicFont = PlayerPrefsX.GetBool(USE_DYSLEXIC_FONT);
    }

    /// <summary>
    /// Initializes everything in this controller.
    /// </summary>
    public void Initialize()
    {
        SetDyslexicFontMode(UseDyslexicFont);
    }

    /// <summary>
    /// Sets the current state of the dyslexic font
    /// </summary>
    /// <param name="on"></param>
    public void SetDyslexicFontMode(bool on)
    {
        UseDyslexicFont = on;
        PlayerPrefsX.SetBool(USE_DYSLEXIC_FONT, UseDyslexicFont);
        PlayerPrefs.Save();

        if (UseDyslexicFont)
        {
            // Íf the dyslexic font option is on, the current font & scale will be the dyslexic font
            CurrentFont = dyslexic.Font;
            CurrentScale = dyslexic.Scale;
        }
        else
        {
            // If the dyslexic font option isn't on, the current font & scale will be the regular font
            CurrentFont = regular.Font;
            CurrentScale = regular.Scale;
        }

        if (OnChangeFont != null) // 
        {
            // Inform text objects with ChangeFont class attached to update to the new font
            OnChangeFont.Invoke(CurrentFont, CurrentScale);
        }
    }

    [System.Serializable]
    private class FontSettings
    {
        [SerializeField, Space(5)]
        private TMP_FontAsset font;
        public TMP_FontAsset Font { get { return font; } }
        [SerializeField]
        [Range(0.01f, 1)]
        [Tooltip("Sets the scale on the regular font")]
        private float scale;
        public float Scale { get { return scale; } }
    }
}
