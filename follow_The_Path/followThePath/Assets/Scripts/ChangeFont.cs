using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeFont : MonoBehaviour
{
    // regularFont of the type TextMeshPro
    // dyslexicFont of the type TextMeshPro
    // currentFont of the type TextMeshPro
    private ColorManager colorManager;

    //[SerializeField]
    public TextMeshProUGUI textObject;

    [Space(10)]
    public TMP_FontAsset regularFont;
    public TMP_FontAsset dyslexicFont;

    // https://forum.unity.com/threads/trouble-programatically-changing-text-mesh-pro-font.470047/
    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetFont()
    {
        if (colorManager.dyslexicFontToggle.isOn == true)
        {
            textObject.font = dyslexicFont;
        }
        else if (colorManager.dyslexicFontToggle.isOn == false)
        {
            textObject.font = regularFont;
        }
    }

    public void ToDyslexic()
    {
        textObject.font = dyslexicFont;
        // Check if you need "font material" both here and in "ToRegular()"
    }

    public void ToRegular()
    {
        textObject.font = regularFont;
    }
}
