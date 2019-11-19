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

    // Start is called before the first frame update
    void Start()
    {
        tileMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ColorChange()
    {

        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);

        if (tileColorIndex == 0)
        {
            // Set Tile color to RED
            tileMaterial.SetColor("_Tint", tileColorList[0]);
        }
        else if (tileColorIndex == 1)
        {
            // Set Tile color to ORANGE
            tileMaterial.SetColor("_Tint", tileColorList[1]);
        }
        else if (tileColorIndex == 2)
        {
            // Set Tile color to YELLOW
            tileMaterial.SetColor("_Tint", tileColorList[2]);
        }
        else if (tileColorIndex == 3)
        {
            // Set Tile color to GREEN
            tileMaterial.SetColor("_Tint", tileColorList[3]);
        }
        else if (tileColorIndex == 4)
        {
            // Set Tile color to BLUE
            tileMaterial.SetColor("_Tint", tileColorList[4]);
        }
        else if (tileColorIndex == 5)
        {
            // Set Tile color to INDIGO
            tileMaterial.SetColor("_Tint", tileColorList[5]);
        }
        else
        {
            // Set Tile color to VIOLET
            tileMaterial.SetColor("_Tint", tileColorList[6]);
        }
    }
}
