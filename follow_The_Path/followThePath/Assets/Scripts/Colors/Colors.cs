using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{
    [System.Serializable]
    public struct ColorGroup
    {
        public string Name;
        public Color TileColor;
        public Color FloorColor;
        public Sprite ColorSprite;
    }
}
