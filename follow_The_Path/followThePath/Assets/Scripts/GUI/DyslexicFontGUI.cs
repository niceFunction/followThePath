using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DyslexicFontGUI : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMPro.TextMeshProUGUI statusText;

    private void Start()
    {
        FontController.Instance.OnChangeFont += OnChangeFont;
        // A little ugly, but we will set the values correctly
        OnChangeFont(null, 0f);        
    }
    private void OnDestroy()
    {
        FontController.Instance.OnChangeFont -= OnChangeFont;
    }

    private void OnChangeFont(TMP_FontAsset newFont, float scaleFont)
    {
        if (FontController.Instance.UseDyslexicFont)
        {
            toggle.isOn = true;
            statusText.text = "ON";
        }
        else
        {
            toggle.isOn = false;
            statusText.text = "OFF";
        }
    }

    /// <summary>
    /// Called from Unity GUI
    /// </summary>
    /// <param name="on"></param>
    public void SetDyslexicFont(bool on)
    {
        FontController.Instance.SetDyslexicFontMode(on);
    }
}