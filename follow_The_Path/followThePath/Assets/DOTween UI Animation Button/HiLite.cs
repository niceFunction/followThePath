using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace SamuelEinheri.UI
{
    public class HiLite : MonoBehaviour
    {
        public Color32 HiLiteColorPrimary;
        public Color32 HiLiteColorSecondary;

        [SerializeField, Range(0.5f, 1.5f)]
        private float growth;

        private Tween _tween;
        private static readonly Color32 dummyColor = new Color32(42, 42, 42, 42);
        private Color32 originalColor = dummyColor;
        private bool isOverButton;

        public void OnEnter(DoButton doButton)
        {
            isOverButton = true;

            if (originalColor.Equals(dummyColor)) originalColor = doButton.Background.color;

            if (_tween != null && _tween.IsActive()) _tween.Kill();
            _tween = doButton.Background.DOColor(HiLiteColorPrimary, 0.42f);
        }

        public void OnExit(DoButton doButton)
        {
            isOverButton = false;

            _tween.Kill();
            _tween = doButton.Background.DOColor(originalColor, 0.42f);
        }

        public void OnDown (DoButton doButton)
        {
            var growthVector = new Vector3(1 + growth * 0.1f, 1 + growth * 0.1f, 1);

            _tween.Kill();
            _tween = DOTween.Sequence()
                .Join(doButton.Background.transform.DOScale(growth, 0.42f))
                .Join(doButton.Background.DOColor(HiLiteColorSecondary, 0.42f));
        }

        public void OnUp(DoButton doButton)
        {
            _tween.Kill();
            _tween = DOTween.Sequence()
                .Join(doButton.Background.transform.DOScale(Vector3.one, 0.42f))
                .Join(doButton.Background.DOColor(DecideColor(), 0.42f))
                .OnComplete(doButton.Execute);
        }
        
        private Color32 DecideColor()
        {
            return isOverButton ? HiLiteColorPrimary : originalColor;
        }
    }
}
