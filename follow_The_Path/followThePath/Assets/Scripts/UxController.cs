using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UxController : MonoBehaviour
{
    /*
     DELEGATES & EVENTS
     The utility of Delegates and Events in Unity
     http://www.unitygeek.com/delegates-events-unity/

    Delegates and Events in Unity
    http://www.unitygeek.com/delegates-events-unity/

    Events
    https://learn.unity.com/tutorial/events-uh

    How to use C# Events in Unity
    https://www.gamasutra.com/blogs/VivekTank/20180703/321126/How_to_use_C_Events_in_Unity.php

    Event and Unity
    https://www.indiedb.com/members/damagefilter/blogs/event-and-unity
    */
    public delegate void RandomColorHandler();
    public static event RandomColorHandler onRandomColor;

    public delegate void GrayscaleHandler(Toggle grayscaleToggle, string grayscaleStatus);
    public event GrayscaleHandler onGrayscaleMode;

    public delegate void DyslexicModeHandler();
    public static event DyslexicModeHandler onDyslexicMode;


    private Toggle grayscaleModeToggle;

    private TextMeshProUGUI grayscaleModeStatus;

    public static UxController Instance { get; private set; }


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
        //UxManager.Instance.on
        // START HERE
        UpdateGrayscale(UxManager.Instance.GrayscaleToggle, UxManager.Instance.GrayscaleStatus);
        UxManager.Instance.onGrayscaleMode += this.UpdateGrayscale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateGrayscale(Toggle grayscaleToggle, TextMeshProUGUI grayscaleStatus)
    {
        //Accessibility.Instance.GrayscaleOverlay
        grayscaleModeToggle.isOn = grayscaleToggle;
        grayscaleModeStatus = grayscaleStatus;
    }

    public void UpdateDyslexic()
    {

    }
}
