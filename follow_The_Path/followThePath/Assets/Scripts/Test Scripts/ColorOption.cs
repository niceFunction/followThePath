using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SamuelEinheri
{
    [System.Serializable]
    public class ColorOption
    {
        [Tooltip("Name of the object")]
        public string colorName;
        [Tooltip("Material to be changed")]
        public Material material;
        [SerializeField]
        [Tooltip("List of colors the material will change into")]
        private Color[] colorList;
    }
}
