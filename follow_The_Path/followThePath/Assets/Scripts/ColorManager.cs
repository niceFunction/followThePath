using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager class used to change the color of prefabs, specifically Tiles and Floors.
/// </summary>

// https://www.youtube.com/watch?v=pvo0RCiqtLQ&feature=youtu.be&t=254
// https://www.youtube.com/watch?v=usAaH5Mi0ZQ

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

    private Color currentTileColor;
    private Color currentFloorColor;

    // Start is called before the first frame update
    void Start()
    {
        currentTileColor = Color.white;
        currentFloorColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
        Debug.Log(currentTileColor);

    }

    void ColorChange()
    {

        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
        int floorColorIndex = Random.Range(0, floorColorList.Length);

        #region Set Material Color
        /// <summary>
        /// If indices are equals to an int value, set the materials to that color from the tile/floor arrays.
        /// </summary>
        if (tileColorIndex == 0 && floorColorIndex == 0)
        {
            // Set Tile color to RED
            tileMaterial.color = tileColorList[0];
            
            // Set Floor color to RED
            floorMaterial.color = floorColorList[0];

            currentTileColor = tileColorList[0];
            currentFloorColor = floorColorList[0]; 
        }
        else if (tileColorIndex == 1 && floorColorIndex == 1)
        {
            // Set Tile color to ORANGE
            tileMaterial.color = tileColorList[1];

            // Set Floor color to ORANGE
            floorMaterial.color = floorColorList[1];

            currentTileColor = tileColorList[1];
            currentFloorColor = floorColorList[1];
        }
        else if (tileColorIndex == 2 && floorColorIndex == 2)
        {
            // Set Tile color to YELLOW
            tileMaterial.color = tileColorList[2];

            // Set Floor color to YELLOW
            floorMaterial.color = floorColorList[2];

            currentTileColor = tileColorList[2];
            currentFloorColor = floorColorList[2];
        }
        else if (tileColorIndex == 3 && floorColorIndex == 3)
        {
            // Set Tile color to GREEN
            tileMaterial.color = tileColorList[3];

            // Set Floor color to GREEN
            floorMaterial.color = floorColorList[3];

            currentTileColor = tileColorList[3];
            currentFloorColor = floorColorList[3];
        }
        else if (tileColorIndex == 4 && floorColorIndex == 4)
        {
            // Set Tile color to BLUE
            tileMaterial.color = tileColorList[4];

            // Set Floor color to BLUE
            floorMaterial.color = floorColorList[4];

            currentTileColor = tileColorList[4];
            currentFloorColor = floorColorList[4];
        }
        else if (tileColorIndex == 5 && floorColorIndex == 5)
        {
            // Set Tile color to INDIGO
            tileMaterial.color = tileColorList[5];

            // Set Floor color to INDIGO
            floorMaterial.color = floorColorList[5];

            currentTileColor = tileColorList[5];
            currentFloorColor = floorColorList[5];
        }
        else if (tileColorIndex == 6 && floorColorIndex == 6)
        {
            // Set Tile color to VIOLET
            tileMaterial.color = tileColorList[6];

            // Set Floor color to VIOLET
            floorMaterial.color = floorColorList[6];

            currentTileColor = tileColorList[6];
            currentFloorColor = floorColorList[6];
        }
        //tileMaterial.color = Color.Lerp(tileMaterial.color, currentTileColor, changeSpeed);
        //floorMaterial.color = Color.Lerp(floorMaterial.color, currentFloorColor, changeSpeed);
        #endregion
    }
}
