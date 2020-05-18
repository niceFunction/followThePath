using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweens : MonoBehaviour
{
    [System.Serializable]
    public struct UIGroup
    {
        [Tooltip("Name of the Object to be 'tweened'")]
        public string TweenName;
        [Tooltip("The RectTransform of the object")]
        public RectTransform TweenTarget;
        [Tooltip("The amount of time it takes for the tween to happen"),Range(0.01f, 2f)]
        public float TweenTime;
        [Tooltip("The alpha the background image will have"), Range(0.0f, 1f)]
        public float Alpha;
        [Tooltip("The X-position the object will have"), Range(-5000, 5000)]
        public int XPosition;
        [Tooltip("The Y-position the object will have"), Range(-5000, 5000)]
        public int YPosition;
        [Tooltip("Scale of object"), Range(0, 1)]
        public float Scale;
    }

    [System.Serializable]
    public struct MenuTween
    {
        [Tooltip("The RectTransform of the Main Menu object")]
        public RectTransform TweenTarget;

        [Tooltip("The amount of time for the tween of the Menu to happen"), Range(0.01f, 2f)]
        public float TweenTime;

        [Tooltip("The final alpha the background image will have for the Menu"), Range(0.0f, 1f)]
        public float Alpha;

        [Tooltip("The X-position the Menu will have"), Range(-5000, 5000)]
        public int XPosition;

        [Tooltip("The Y-position the Menu will have"), Range(-5000, 5000)]
        public int YPosition;
    }

    [System.Serializable]
    public struct MainMenu
    {
        [Tooltip("The RectTransform of the Main Menu object")]
        public RectTransform TweenTarget;

        [Tooltip("The amount of time for the tween of the Main Menu to happen"), Range(0.01f, 2f)]
        public float TweenTime;

        [Tooltip("The final alpha the background image will have for the Main Menu"), Range(0.0f, 1f)]
        public float Alpha;

        [Tooltip("The X-position the Main Menu will have"), Range(-5000, 5000)]
        public int XPosition;

        [Tooltip("The Y-position the Main Menu will have"), Range(-5000, 5000)]
        public int YPosition;
    }

    [System.Serializable]
    public struct HowToPlayMenu
    {
        [Tooltip("The RectTransform of the How To Play Menu object")]
        public RectTransform TweenTarget;

        [Tooltip("The amount of time for the tween of the How To Play Menu to happen"), Range(0.01f, 2f)]
        public float TweenTime;

        [Tooltip("The final alpha the background image will have for the How To Play Menu"), Range(0.0f, 1f)]
        public float Alpha;

        [Tooltip("The X-position the How To Play Menu will have"), Range(-5000, 5000)]
        public int XPosition;

        [Tooltip("The Y-position the How To Play Menu will have"), Range(-5000, 5000)]
        public int YPosition;
    }

    [System.Serializable]
    public struct SettingsMenu
    {
        [Tooltip("The RectTransform of the Settings Menu object")]
        public RectTransform TweenTarget;

        [Tooltip("The amount of time for the tween of the Settings Menu to happen"), Range(0.01f, 2f)]
        public float TweenTime;

        [Tooltip("The final alpha the background image will have for the Settings Menu"), Range(0.0f, 1f)]
        public float Alpha;

        [Tooltip("The X-position the Settings Menu will have"), Range(-5000, 5000)]
        public int XPosition;

        [Tooltip("The Y-position the Settings Menu will have"), Range(-5000, 5000)]
        public int YPosition;
    }
}
