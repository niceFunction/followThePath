using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropdownItems : MonoBehaviour
{
    [System.Serializable]
    public struct DropdownGroup
    {
        [Tooltip("The text in the dropdown menu")]
        public TextMeshProUGUI DropdownText;
        [Tooltip("The arrow in the dropdown menu")]
        public Image DropdownArrowImage;
        [Tooltip("The caption image in the dropdown menu")]
        public Image DropdownCaptionImage;
        [Tooltip("The amount of time it takes for the tween to happen"), Range(0.01f, 2f)]
        public float TweenTime;
        [Tooltip("The alpha the dropdown items will have"), Range(0.0f, 1f)]
        public float Alpha;

    }
}
