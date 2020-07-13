using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameOverItems : MonoBehaviour
{
    [System.Serializable]
    public struct GameOverGroup
    {
        [Tooltip("Game Over Menu object"), Header("GameObject")]
        public GameObject GameOverMenuObject;

        [Tooltip("Game Over Menu transform (MAY NOT BE NEEDED)")]
        public Transform GameOverTransform;

        [Tooltip("The background on Game Over"), Header("Background")]
        public Image Background;

        [Tooltip("The backgrounds alpha value"), Range(0.0f, 1f)]
        public float Alpha;

        [Tooltip("GameObject that shows up & starts counting down"), Header("Game Over State")]
        public GameObject GameOverTimerObject;

        [Tooltip("Minimum amount of speed to trigger the BackgroundTimer"), Range(0.01f, 5.0f)]
        public float MinimumSpeed;

        [Tooltip("Amount of time needed to trigger the Game Over timer"), Range(1, 60)]
        public float BackgroundTimer;

        [Tooltip("Amount of time until 'Game Over' (will show up on screen)"), Range(1, 60)]
        public float GameOverTimer;
    }
}
