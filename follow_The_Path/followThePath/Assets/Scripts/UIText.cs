using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIText : MonoBehaviour
{
    private static List<UIText> uiTexts = new List<UIText>(); // This list contains all active
    //private Text textObject;

    public static void UpdateFonts()
    {
        foreach (UIText t in uiTexts)
        {
            t.UpdateFont();
        }
    }

    void Start()
    {
        //textObject = this.GetComponent<Text>(); // Store the Text object for using later
                                                // TODO include additional code from Start() here, if you reuse an old object
    }
    void OnEnable() // This should run every time this object is enabled.
    {
        //Debug.Log("UIText enabled!"); //Uncomment this in case things aren't working OK, help you debug
        UpdateFont(); // Make sure we use the current font
        uiTexts.Add(this); // Add this instance to the list of uiTexts
    }
    void OnDisable() // This should run every time this object is disabled.
    {
        //Debug.Log("UIText disabled!"); //Uncomment this in case things aren't working OK, help you debug
        uiTexts.Remove(this); // Remove this instance from our list of uiTexts
    }

    private void UpdateFont()
    {
        // TODO add logic here to set font of textObject to whatever it should be. 
        // Example: textObject.font = FontManager.CurrentFont;
    }
}
