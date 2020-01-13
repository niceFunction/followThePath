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
public class ChangeTheFont : MonoBehaviour
{
    private static List<ChangeTheFont> changeTheFonts = new List<ChangeTheFont>(); // TODO Remove this (changeFonts)
    private TextMeshProUGUI textObject;
    public ColManager colManager; // TODO Remove this (colorManager)

    [Range(0.1f, 200f)]
    [Tooltip("The regular size of the font")]
    public float regularFontSize;
    [Range(1f, 200f)]
    [Tooltip("The size of the dyslexic font")]
    public float dyslexicFontSize;

    #region Remove this (UpdateFonts)
    // TODO Remove this method/foreach loop (UpdateFonts)
    // Updates all UI/text elements where this script is attached to
    public static void UpdateFonts()
    {
        foreach (ChangeTheFont c in changeTheFonts)
        {
            c.UpdateFont();
        }
    }
    #endregion


    void Start()
    {
        #region Remove this
        // TODO Remove this within the region
        // TODO include additional code from Start() here, if you reuse an old object
    }

    private void Update()
    {

    }

    void OnEnable() // This should run every time this object is enabled.
    {
        // At start, sets the font to regular font and not an unrelated font

        //Debug.Log("ChangeFont enabled!"); // Uncomment to debug if things aren't working as intended.
        #endregion
        if (textObject == null)
        {
            textObject = this.GetComponent<TextMeshProUGUI>();
        }
        UpdateFont(); // TODO Remove this
        changeTheFonts.Add(this); // TODO Remove this
    }

    void OnDisable() // This should run every time this object is disabled.
    {
        //Debug.Log("ChangeFont disabled!"); // Uncomment to debug if things aren't working as intended.
        changeTheFonts.Remove(this); // Remove this instance from our list of changeFonts
    }

    private void UpdateFont() // TODO Add "TMP_FontAsset newFont" into this method
    {
        #region Remove this
        // TODO Remove this (statement and summary)
        textObject.font = colManager.currentFont;
        ///<summary>
        /// This if-statement is used to individually adjust the size of the font.
        /// This is because the dyslexic font is larger compared to the regular
        /// font style.
        /// </summary>
        #endregion
        if (colManager.dyslexicFontToggle.isOn == false) // TODO change this to "ColorManager.Instance.dyslexicFontToggle.isOn"
        {
            /* TODO the below size adjustment can be changed into:
             *  1. Store the original font value for atteched gui text object on start
             *  2. ColorManager can have a float which stores the relative size the dyslexic font should be scaled
             *  3. When font changes, also send a float value for scale (1 for regular font, and the dyslexic value for dyslexic font)
             *  4. This object can then set textObject.fontSize = originalFontSize * scale
             * You won't have to set font size on each and every object
             * and you won't have to do any additional work on all objects if you add more fonts later.
             */

            textObject.fontSize = regularFontSize;
        }
        else if (colManager.dyslexicFontToggle.isOn == true) // TODO Remove if statement part but keep else
        {
            textObject.fontSize = dyslexicFontSize;
        }

    }
}
