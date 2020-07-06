using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace SamuelEinheri.UI
{
    /// <summary>
    /// DoButton, UI button that can be animated with DOTween
    /// </summary>
    public class DoButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, 
        IPointerClickHandler
    {
        // https://connect.unity.com/p/building-a-better-button-with-dotween
        // NOTE: Implement "OnPointerEnter" and "OnPointerExit" in "DoButton" and in "IAnimatable"
        // Custom Unity Events https://danielilett.com/2020-07-04-unity-tips-7-events/

        [SerializeField, Tooltip("Add Button that will be affected by 'animations', needs to have 'PulseEffect' class to work")]
        private Button getButton;
        public Button GetButton { get { return getButton; } }

        private Stack<IActionable> _actionStack = new Stack<IActionable>();
        private IActionable _actionable;
        public IActionable Actionable 
        { 
            get
            {
                if (_actionable != null) return _actionable;
                _actionable = GetComponent<IActionable>();
                return _actionable;
            }
        }

        private IAnimatable _animatable;
        public IAnimatable Animatable
        {
            get
            {
                if (_animatable != null) return _animatable;
                _animatable = GetComponent<IAnimatable>();
                return _animatable;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Animatable.OnDown(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Animatable.OnUp(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Animatable.OnEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Animatable.OnExit(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _actionStack.Push(Actionable);
        }

        public void Execute()
        {
            if (_actionStack.Count == 0) return;
            {
                _actionStack.Pop().Do(this);
            }
        }
    }
}
