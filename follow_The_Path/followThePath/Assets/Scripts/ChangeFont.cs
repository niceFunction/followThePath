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
public class ChangeFont : MonoBehaviour
{
    private static List<ChangeFont> changeFonts = new List<ChangeFont>();
    private TextMeshProUGUI textObject;
    public ColorManager colorManager;

    public static void UpdateFonts()
    {
        foreach(ChangeFont c in changeFonts)
        {
            c.UpdateFont();
        }
    }

    void Start()
    {
        textObject = this.GetComponent<TextMeshProUGUI>();

        // TODO include additional code from Start() here, if you reuse an old object
    }

    private void Update()
    {

    }

    void OnEnable() // This should run every time this object is enabled.
    {
        Debug.Log("ChangeFont enabled!"); // Uncomment to debug if things aren't working as intended.
        UpdateFont();
        changeFonts.Add(this);
    }

    void OnDisable() // This should run every time this object is disabled.
    {
        Debug.Log("ChangeFont disabled!"); // Uncomment to debug if things aren't working as intended.
        changeFonts.Remove(this); // Remove this instance from our list of changeFonts
    }

    private void UpdateFont()
    {

        textObject.font = colorManager.currentFont;

    }
    #region Old Code
    /*
    //public TextMeshProUGUI textObject;

    [HideInInspector]
    public GameObject textObject;

    [Space(10)]
    public TMP_FontAsset regularFont;
    public TMP_FontAsset dyslexicFont;

    // https://forum.unity.com/threads/trouble-programatically-changing-text-mesh-pro-font.470047/
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
       textObject = GameObject.FindGameObjectWithTag("UIText");
        
    }

    private void Update()
    {

    }

    public void ToDyslexic()
    {

        textObject.GetComponent<TextMeshProUGUI>().font = dyslexicFont;
        // Check if you need "font material" both here and in "ToRegular()"
    }

    public void ToRegular()
    {
        textObject.GetComponent<TextMeshProUGUI>().font = regularFont;
        //textObject.font = regularFont;
    }*/
    #endregion
}