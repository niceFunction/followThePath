using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SamuelEinheri
{
    [System.Serializable]
    public class ToggleOption
    {
        [Tooltip("Name of the object")]
        public string toggleName;

        [SerializeField]
        [Tooltip("Current status of Toggle option")]
        private TextMeshProUGUI statusText;
        [Tooltip("Toggle item on or off")]
        public Toggle toggleObject;
    }
}

