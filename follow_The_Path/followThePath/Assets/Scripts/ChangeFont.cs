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

        UpdateFont(ColorManager.Instance.currentFont, ColorManager.Instance.FontScale);
        ColorManager.Instance.onChangeFont += this.UpdateFont;
    }

    void OnDestroy()
    {
        // Remove listener when destroyed
        ColorManager.Instance.onChangeFont -= this.UpdateFont;
    }

    private void UpdateFont(TMP_FontAsset newFont, float scaleFont)
    {
        textObject.font = newFont;
        textObject.fontSize = scaleFont;

        //textObject.fontSize = originalFontSize * scaleFont;

        /*
        if (ColorManager.Instance.DyslexicFontToggleOn)
        {
            textObject.fontSize = originalFontSize * scaleFont;
        }
        else
        {
            textObject.fontSize = originalFontSize;
        }
       */

        //textObject.fontSize = scaleFont;
        /* TODO the below size adjustment can be changed into:
         *  1. Store the original font value for attached gui text object on start
         *  
         *  2. ColorManager can have a float which stores the relative size the dyslexic font should be scaled
         *  
         *  3. When font changes, also send a float value for scale (1 for regular font, 
         *     and the dyslexic value for dyslexic font)
         *     
         *  4. This object can then set textObject.fontSize = originalFontSize * scale
         *     You won't have to set font size on each and every object
         *     and you won't have to do any additional work on all objects if you add more fonts later.
         */
        /*
       if (ColorManager.Instance.DyslexicFontToggleOn)
       {
           textObject.fontSize = originalFontSize;
       }
       else
       {
           textObject.fontSize = originalFontSize;
       }
       */
    }
}