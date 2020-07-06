using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;

namespace SamuelEinheri.UI
{
    public class HiLite : MonoBehaviour, IAnimatable
    {
        // NOTE: consider either: 
        // 1. Figure out a way to use DOScale on Unity Buttons
        // 2. Just use your own buttons and remove things you don't use

        [SerializeField, Range(0.5f, 1.5f), Tooltip("How much scaling will happen over time, \n" +
            "Scale will become smaller below 1 & bigger if above 1"), Header("Button Scale")]
        private float scaleAmount;

        [SerializeField, Range(0.1f, 1f), Tooltip("Duration over time scaling will happen")]
        private float scaleDuration;

        private Tween _tween;
        private static readonly Color32 dummyColor = new Color32(42, 42, 42, 42);
        private Color32 originalColor = dummyColor;
        private bool isOverButton;

        public void OnEnter(DoButton doButton)
        {
            isOverButton = true;

            if (originalColor.Equals(dummyColor)) originalColor = doButton.Background.color;

            if (_tween != null && _tween.IsActive()) _tween.Kill();
            _tween = doButton.Background.DOColor(doButton.NormalColor, 0.42f);
        }

        public void OnExit(DoButton doButton)
        {
            isOverButton = false;

            _tween.Kill();
            _tween = doButton.Background.DOColor(doButton.Background.color, 1f);
        }

        public void OnDown (DoButton doButton)
        {
            var growthVector = new Vector3(1 + scaleAmount * scaleDuration, 1 + scaleAmount * scaleDuration, 1);

            _tween.Kill();
            _tween = DOTween.Sequence()
                .Join(doButton.Background.transform.DOScale(scaleAmount, 0.42f))
                .Join(doButton.Text.transform.DOScale(scaleAmount, 0.42f))
                //.Join(doButton.Background.DOColor(doButton.PressedColor, 0.42f))
                .Join(doButton.getButton.image.DOColor(doButton.getButton.colors.pressedColor, 0.42f));
        }

        public void OnUp(DoButton doButton)
        {
            _tween.Kill();
            _tween = DOTween.Sequence()
                .Join(doButton.Background.transform.DOScale(Vector3.one, 0.42f))
                .Join(doButton.Text.transform.DOScale(Vector3.one, 0.42f))
                //.Join(doButton.Background.DOColor(DecideColor(doButton), 0.42f))
                .Join(doButton.getButton.image.DOColor(DecideColor(doButton), 0.42f))
                .OnComplete(doButton.Execute);
        }
        
        private Color32 DecideColor(DoButton doButton)
        {
            //return doButton.NormalColor;
            return doButton.getButton.colors.normalColor;
        }
    }
}
