using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager class used to change the color/emission of prefabs, specifically Tiles and Floors.
/// </summary>
public class ColorManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Create a list of Colors and choose Colors")]
    private Color[] colorList;

    [Tooltip("Used to change color (Tint) on the Tiles")]
    public Material tileMaterial;
    [Tooltip("Used to change the color of the Emission on the Floor")]
    public Material floorMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
