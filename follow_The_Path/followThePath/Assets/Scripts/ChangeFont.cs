using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 Remove this if this doesn't compile and you can't fix it. 
This will just prevent you from putting this object on other 
things that don't have a UI.Text
*/
[RequireComponent(typeof(TextMeshProUGUI))]
/// <summary>
/// Changes font style from regular to dyslexic
/// </summary>
public class ChangeFont : MonoBehaviour
{
    private TextMeshProUGUI textObject;

    
    [Tooltip("Font starting size")]
    // Size is "stored" at the start, eliminating the need to manually set the original font size yourself
    public float originalFontSize;

    void Start()
    {
        if (textObject == null)
        {
            textObject = this.GetComponent<TextMeshProUGUI>();
            // Is this the correct way of doing it or should I exchange "textObject" with "this"?
            originalFontSize = textObject.GetComponent<TextMeshProUGUI>().fontSize;
        }

        UpdateFont(FontController.Instance.CurrentFont, FontController.Instance.CurrentScale);
        Accessibility.Instance.onChangeFont += this.UpdateFont;
    }

    void OnDestroy()
    {
        // Remove listener when destroyed
        Accessibility.Instance.onChangeFont -= this.UpdateFont;
    }

    private void UpdateFont(TMP_FontAsset newFont, float scaleFont)
    {
        textObject.font = newFont;
        textObject.fontSize = originalFontSize * scaleFont;
    }
}