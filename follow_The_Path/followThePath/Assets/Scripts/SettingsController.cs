using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public static SettingsController Instance { get; private set; }

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

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColorMode()
    {
        /*
        if (UxManager.Instance.RandomColorsToggle.isOn)
        {
            RandomColor.Instance.StartRandomColor();
        }
        else
        {
            RandomColor.Instance.StopRandomColor();
        }
        */
    }

    public void UpdateGrayscaleMode()
    {
        Accessibility.Instance.GrayscaleOverlay();
    }

    public void UpdateGameFont()
    {
        //Accessibility.Instance.DyslexicFontMode(true);
    }

}
