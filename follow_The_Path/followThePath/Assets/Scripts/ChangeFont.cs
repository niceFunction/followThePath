using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeFont : MonoBehaviour
{
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
    }
}