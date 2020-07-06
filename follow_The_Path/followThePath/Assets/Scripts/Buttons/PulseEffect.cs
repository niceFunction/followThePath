using SamuelEinheri.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;

namespace SamuelEinheri.UI
{
    // NOTE: UI button effect inspiration (saved for now)
    // https://connect.unity.com/p/building-a-better-button-with-dotween


    public class PulseEffect : MonoBehaviour, IAnimatable
    {
        [SerializeField, Range(0.5f, 1.5f), Tooltip("How much scaling will happen over time, \n" +
            "Scale will become smaller below 1 & bigger if above 1"), Header("Button Scale")]
        private float scaleAmount;

        private Tween _tween;
        private static readonly Color32 dummyColor = new Color32(42, 42, 42, 42);
        private Color32 originalColor = dummyColor;
        private bool isOverButton;

        public void OnEnter(DoButton doButton)
        {
            isOverButton = true;

            if (originalColor.Equals(dummyColor)) originalColor = doButton.GetButton.image.color;

            if (_tween != null && _tween.IsActive()) _tween.Kill();
            _tween = doButton.GetButton.image.DOColor(doButton.GetButton.colors.normalColor, 0.42f);
        }

        public void OnExit(DoButton doButton)
        {
            isOverButton = false;

            _tween.Kill();
            _tween = doButton.GetButton.image.DOColor(doButton.GetButton.image.color, 1f);
        }

        public void OnDown(DoButton doButton)
        {
            var growthVector = new Vector3(1 + scaleAmount * 0.1f, 1 + scaleAmount * 0.1f, 1);

            _tween.Kill();
            _tween = DOTween.Sequence()
                .Join(doButton.GetButton.transform.DOScale(scaleAmount, 0.42f))
                .Join(doButton.GetButton.image.DOColor(doButton.GetButton.colors.pressedColor, 0.42f));
        }

        public void OnUp(DoButton doButton)
        {
            _tween.Kill();
            _tween = DOTween.Sequence()
                .Join(doButton.GetButton.transform.DOScale(Vector3.one, 0.42f))
                .Join(doButton.GetButton.image.DOColor(DecideColor(doButton), 0.42f))
                .OnComplete(doButton.Execute);
        }

        private Color DecideColor(DoButton doButton)
        {
            return doButton.GetButton.colors.normalColor;
        }

        /* From example (saved for now incase problems happens
            private Color32 DecideColor()
            {
                return _isOverButton ? HiLiteColor : _originalcolor;
            }
        */
    }
}

