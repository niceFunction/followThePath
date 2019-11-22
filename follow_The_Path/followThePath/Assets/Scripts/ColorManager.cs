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

    public float colorChangeTimerReset = 3.0f;
    private float colorChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        //currentTileColor = Color.white;
        //currentFloorColor = Color.white;
        colorChangeTimer = colorChangeTimerReset;
    }

    // Update is called once per frame
    void Update()
    {
        //SetRandomColor();
        colorChangeTimer -= Time.deltaTime;
        if (colorChangeTimer < 0)
        {
            StartCoroutine(SetRandomColor());
            colorChangeTimer = colorChangeTimerReset;
        }
        //Debug.Log("colorChangeTimer: " + colorChangeTimer);
    }

    IEnumerator SetRandomColor()
    {
        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
        int floorColorIndex = Random.Range(0, floorColorList.Length);

        float elapsedTime = 0.0f;
        float totalTime = 2.0f;
        //Debug.Log("tileColorIndex is: " + tileColorIndex);

        #region Set Material Color

        while (elapsedTime < totalTime)
        { 
             /// <summary>
            /// If indices are equals to an int value, set the materials to that color from the tile/floor arrays.
            /// </summary>
            if (tileColorIndex == 0 && floorColorIndex == 0)
            {
                // Set Tile color to RED
                //tileMaterial.color = tileColorList[0];.
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[0], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to RED
                //floorMaterial.color = floorColorList[0];.
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[0], (Mathf.Sin(elapsedTime / totalTime)));

                //currentTileColor = tileColorList[0];
                //currentFloorColor = floorColorList[0]; 
            }
            else if (tileColorIndex == 1 && floorColorIndex == 1)
            {
                // Set Tile color to ORANGE
                //tileMaterial.color = tileColorList[1];.
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[1], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to ORANGE
                //floorMaterial.color = floorColorList[1];.
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[1], (Mathf.Sin(elapsedTime / totalTime)));

                //currentTileColor = tileColorList[1];
                //currentFloorColor = floorColorList[1];
            }
            else if (tileColorIndex == 2 && floorColorIndex == 2)
            {
                // Set Tile color to YELLOW
                //tileMaterial.color = tileColorList[2];
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[2], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to YELLOW
                //floorMaterial.color = floorColorList[2];
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[2], (Mathf.Sin(elapsedTime / totalTime)));

                //currentTileColor = tileColorList[2];
                //currentFloorColor = floorColorList[2];
            }
            else if (tileColorIndex == 3 && floorColorIndex == 3)
            {
                // Set Tile color to GREEN
                //tileMaterial.color = tileColorList[3];
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[3], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to GREEN
                //floorMaterial.color = floorColorList[3];
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[3], (Mathf.Sin(elapsedTime / totalTime)));

                //currentTileColor = tileColorList[3];
                //currentFloorColor = floorColorList[3];
            }
            else if (tileColorIndex == 4 && floorColorIndex == 4)
            {
                // Set Tile color to BLUE
                //tileMaterial.color = tileColorList[4];
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[4], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to BLUE
                //floorMaterial.color = floorColorList[4];.
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[4], (Mathf.Sin(elapsedTime / totalTime)));

                //currentTileColor = tileColorList[4];
                //currentFloorColor = floorColorList[4];
            }
            else if (tileColorIndex == 5 && floorColorIndex == 5)
            {
                // Set Tile color to INDIGO
                //tileMaterial.color = tileColorList[5];
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[5], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to INDIGO
                //floorMaterial.color = floorColorList[5];
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[5], (Mathf.Sin(elapsedTime / totalTime)));
                //currentTileColor = tileColorList[5];
                //currentFloorColor = floorColorList[5];
            }
            else if (tileColorIndex == 6 && floorColorIndex == 6)
            {
                // Set Tile color to VIOLET
                //tileMaterial.color = tileColorList[6];
                elapsedTime += Time.deltaTime;
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[6], (Mathf.Sin(elapsedTime / totalTime)));

                // Set Floor color to VIOLET
                //floorMaterial.color = floorColorList[6];
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[6], (Mathf.Sin(elapsedTime / totalTime)));

                //currentTileColor = tileColorList[6];
                //currentFloorColor = floorColorList[6];
            }
            yield return null;
        }
        #endregion
    }
}
