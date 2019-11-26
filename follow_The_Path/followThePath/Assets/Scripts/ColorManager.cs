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

    [SerializeField]
    [Tooltip("Create an Array of Colors and choose Colors for Tiles")]
    private Color[] tileColorList;
    [SerializeField]
    [Tooltip("Create an Array of Colors and choose Colors for Floors")]
    private Color[] floorColorList;

    // Used to get/set the current Color
    private Color currentTileColor;
    private Color currentFloorColor;

    // Variables used to Randomize colors
    public float colorChangeTimerReset;
    private float colorChangeTimer;
    private bool currentlyChangingColor;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTileColor = tileMaterial.color;
        currentFloorColor = floorMaterial.color;
        colorChangeTimer = colorChangeTimerReset;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time is: " + colorChangeTimer);
        Debug.Log("currentlyChangingColor: " + currentlyChangingColor);
        NewRandomColor();
    }

    public void NewRandomColor()
    {
        colorChangeTimer -= Time.deltaTime;
        if (colorChangeTimer < 0 && !currentlyChangingColor)
        {
            StartCoroutine(SetRandomColor());
            colorChangeTimer = colorChangeTimerReset;
        }
    }

    /// <summary>
    /// This Coroutine is used to randomize the "Tile" colors using Random.Range
    /// </summary>
    /// <returns></returns>
    IEnumerator SetRandomColor()
    {
        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
        int floorColorIndex = Random.Range(0, floorColorList.Length);

        float elapsedTime = 0.0f;
        float totalTime = 3.0f;

        // Set the tileMaterial.color into a random different color
        currentlyChangingColor = true;
        while (elapsedTime < totalTime && tileColorIndex == floorColorIndex && tileColorIndex >= 0 && tileColorIndex <= 6)
        {
            elapsedTime += Time.deltaTime;
            float fraction = Mathf.Sin(elapsedTime / totalTime);

            tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[tileColorIndex], fraction);
            floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[floorColorIndex], fraction);

            yield return null;
        }
        currentlyChangingColor = false;
    }

    /* Leave this be for now
    // https://www.youtube.com/watch?v=Q4NYCSIOamY
    // https://www.youtube.com/watch?v=LRoqGsJGgA4
    public void SetSpecificColor()
    {
        List<string> colorNames = new List<string>() {"RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET"}
    }
    */

}
