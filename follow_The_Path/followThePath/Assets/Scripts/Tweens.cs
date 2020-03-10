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
    }
}
