using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager class used to change the color of prefabs, specifically Tiles and Floors.
/// </summary>
public class ColorManager : MonoBehaviour
{

    [Tooltip("Used to change color (Tint) on the Tiles")]
    public Material tileMaterial;
    [Tooltip("Used to change the color of the Floor")]
    public Material floorMaterial;

    [Tooltip("How fast will the Color chnage into a new Color?")]
    public float changeSpeed = 1.0f;

    [SerializeField]
    [Tooltip("Create a list of Colors and choose Colors for Tiles")]
    private Color[] tileColorList;
    [SerializeField]
    [Tooltip("Create a list of Colors and choose Colors for Floors")]
    private Color[] floorColorList;

    private float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        tileMaterial.color = GetComponent<Material>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ColorChange()
    {
        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
    }
}
