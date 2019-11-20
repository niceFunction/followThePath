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
        //tileMaterial = GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    void ColorChange()
    {

        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
        int floorColorIndex = Random.Range(0, floorColorList.Length);

        if (tileColorIndex == 0 && floorColorIndex == 0)
        {
            // Set Tile color to RED
            //tileMaterial.SetColor("_Tint", tileColorList[0]);
            tileMaterial.color = tileColorList[0];
            // Set Floor color to RED
            floorMaterial.color = floorColorList[0];
        }
        else if (tileColorIndex == 1 && floorColorIndex == 1)
        {
            // Set Tile color to ORANGE
            //tileMaterial.SetColor("_Tint", tileColorList[1]);
            tileMaterial.color = tileColorList[1];
            // Set Floor color to ORANGE
            floorMaterial.color = floorColorList[1];
        }
        else if (tileColorIndex == 2 && floorColorIndex == 2)
        {
            // Set Tile color to YELLOW
            //tileMaterial.SetColor("_Tint", tileColorList[2]);
            tileMaterial.color = tileColorList[2];
            // Set Floor color to YELLOW
            floorMaterial.color = floorColorList[2];
        }
        else if (tileColorIndex == 3 && floorColorIndex == 3)
        {
            // Set Tile color to GREEN
            //tileMaterial.SetColor("_Tint", tileColorList[3]);
            tileMaterial.color = tileColorList[3];
            // Set Floor color to GREEN
            floorMaterial.color = floorColorList[3];
        }
        else if (tileColorIndex == 4 && floorColorIndex == 4)
        {
            // Set Tile color to BLUE
            //tileMaterial.SetColor("_Tint", tileColorList[4]);
            tileMaterial.color = tileColorList[4];
            // Set Floor color to BLUE
            floorMaterial.color = floorColorList[4];
        }
        else if (tileColorIndex == 5 && floorColorIndex == 5)
        {
            // Set Tile color to INDIGO
            //tileMaterial.SetColor("_Tint", tileColorList[5]);
            tileMaterial.color = tileColorList[5];
            // Set Floor color to INDIGO
            floorMaterial.color = floorColorList[5];
        }
        else if (tileColorIndex == 6 && floorColorIndex == 6)
        {
            // Set Tile color to VIOLET
            //tileMaterial.SetColor("_Tint", tileColorList[6]);
            tileMaterial.color = tileColorList[6];
            // Set Floor color to VIOLET
            floorMaterial.color = floorColorList[6];
        }
    }
}
