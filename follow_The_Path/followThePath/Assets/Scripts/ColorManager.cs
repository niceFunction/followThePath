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
        colorChangeTimer -= Time.deltaTime;
        if (colorChangeTimer < 0)
        {
            StartCoroutine(SetRandomColor());
            colorChangeTimer = colorChangeTimerReset;
        }
    }

    IEnumerator SetRandomColor()
    {
        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
        int floorColorIndex = Random.Range(0, floorColorList.Length);

        float elapsedTime = 0.0f;
        float totalTime = 2.0f;
        //Debug.Log("tileColorIndex is: " + tileColorIndex);

        #region Randomize Material Color

        while (elapsedTime < totalTime)
        { 
             /// <summary>
            /// If indices are equals to an int value, set the materials to that color from the tile/floor arrays.
            /// </summary>
            if (tileColorIndex == 0 && floorColorIndex == 0)
            {
                elapsedTime += Time.deltaTime;

                // Set Color to RED
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[0], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[0], (Mathf.Sin(elapsedTime / totalTime)));
            }
            else if (tileColorIndex == 1 && floorColorIndex == 1)
            {
                elapsedTime += Time.deltaTime;

                // Set Color to ORANGE
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[1], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[1], (Mathf.Sin(elapsedTime / totalTime)));
            }
            else if (tileColorIndex == 2 && floorColorIndex == 2)
            {
                elapsedTime += Time.deltaTime;

                // Set Color to YELLOW
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[2], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[2], (Mathf.Sin(elapsedTime / totalTime)));
            }
            else if (tileColorIndex == 3 && floorColorIndex == 3)
            {
                elapsedTime += Time.deltaTime;

                // Set Color to GREEN
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[3], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[3], (Mathf.Sin(elapsedTime / totalTime)));
            }
            else if (tileColorIndex == 4 && floorColorIndex == 4)
            {
                elapsedTime += Time.deltaTime;

                // Set Color to BLUE
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[4], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[4], (Mathf.Sin(elapsedTime / totalTime)));
            }
            else if (tileColorIndex == 5 && floorColorIndex == 5)
            {
                elapsedTime += Time.deltaTime;.

                // Set Color to INDIGO
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[5], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[5], (Mathf.Sin(elapsedTime / totalTime)));
            }
            else if (tileColorIndex == 6 && floorColorIndex == 6)
            {
                elapsedTime += Time.deltaTime;

                // Set Color to VIOLET
                tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[6], (Mathf.Sin(elapsedTime / totalTime)));
                floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[6], (Mathf.Sin(elapsedTime / totalTime)));
            }
            yield return null;
        }
        #endregion
    }
}
