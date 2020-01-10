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
    private static List<ChangeFont> changeFonts = new List<ChangeFont>();
    private TextMeshProUGUI textObject;
    public ColorManager colorManager;

    [Range(0.1f, 200f)]
    [Tooltip("The regular size of the font")]
    public float regularFontSize;
    [Range(1f, 200f)]
    [Tooltip("The size of the dyslexic font")]
    public float dyslexicFontSize;

    // Updates all UI/text elements where this script is attached to
    public static void UpdateFonts()
    {
        foreach(ChangeFont c in changeFonts)
        {
            c.UpdateFont();
        }
    }

    void Start()
    {

        // TODO include additional code from Start() here, if you reuse an old object
    }

    private void Update()
    {

    }

    void OnEnable() // This should run every time this object is enabled.
    {
        // At start, sets the font to regular font and not an unrelated font

        //Debug.Log("ChangeFont enabled!"); // Uncomment to debug if things aren't working as intended.
        if (textObject == null)
        {
            textObject = this.GetComponent<TextMeshProUGUI>();
        }
        UpdateFont();
        changeFonts.Add(this);
    }

    void OnDisable() // This should run every time this object is disabled.
    {
        //Debug.Log("ChangeFont disabled!"); // Uncomment to debug if things aren't working as intended.
        changeFonts.Remove(this); // Remove this instance from our list of changeFonts
    }

    private void UpdateFont()
    {

        textObject.font = colorManager.currentFont;
        ///<summary>
        /// This if-statement is used to individually adjust the size of the font.
        /// This is because the dyslexic font is larger compared to the regular
        /// font style.
        /// </summary>
        if (colorManager.dyslexicFontToggle.isOn == false)
        {
            textObject.fontSize = regularFontSize;
        }
        else if (colorManager.dyslexicFontToggle.isOn == true)
        {
            textObject.fontSize = dyslexicFontSize;
        }

    }
}