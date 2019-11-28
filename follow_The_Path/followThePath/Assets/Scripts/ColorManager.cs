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
    /// <summary>
    /// The Materials are added to the references in the Inspector
    /// </summary>
    [Tooltip("Used to change color on the Tiles")]
    public Material tileMaterial;
    [Tooltip("Used to change the color of the Floor")]
    public Material floorMaterial;

    /// <summary>
    /// The Color arrays size are specified in the Inspector.
    /// In this case, colors of the Rainbow and the colors for the floor
    /// is in a darker hue.
    /// </summary>
    [SerializeField]
    [Tooltip("Creates an Array of Colors for Tiles")]
    private Color[] tileColorList;
    [SerializeField]
    [Tooltip("Create an Array of Colors for Floors")]
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
        //Debug.Log("colorChangeTimer: " + colorChangeTimer);
        //Debug.Log("currentlyChangingColor: " + currentlyChangingColor);
        NewRandomColor();
    }

    public void NewRandomColor()
    {
        colorChangeTimer -= Time.deltaTime;

        if (colorChangeTimer < 0 && !currentlyChangingColor)
        {
            colorChangeTimer = colorChangeTimerReset;
            StartCoroutine(SetRandomColor());
            Debug.Log("Currently Changing Color: " + currentlyChangingColor);
        }

    }

    /// <summary>
    /// This Coroutine is used to randomize the "Tile" colors using Random.Range
    /// </summary>
    /// <returns></returns>


    /* Store "tileColorIndex" in a temporary variable that removes elements from it
     Figure out how to store "tileColorIndex" in a temporary "list" variable and randomly choose from that list
     and remove that element from that "list".
     When that temporary "list" is empty, "repopluate" that "list" again.

    https://forum.unity.com/threads/how-to-not-pick-same-object-from-array-twice-in-a-row.298546/
    https://stackoverflow.com/questions/43708077/how-to-prevent-same-object-from-being-picked-from-array-twice-in-a-row
    https://www.reddit.com/r/Unity3D/comments/7hp91b/can_i_avoid_repeated_numbers_with_randomrange/?sort=top
     */
    IEnumerator SetRandomColor()
    {
        currentlyChangingColor = true;
        //TODO Look more into getting random element from array
        int tileColorIndex = Random.Range(0, tileColorList.Length);
        int floorColorIndex = Random.Range(0, floorColorList.Length);
        Debug.Log("Color Element is: " + tileColorIndex);

        float elapsedTime = 0.0f;
        float totalTime = 6.0f;

        // Set the tileMaterial.color into a random different color
        while (elapsedTime < totalTime && tileColorIndex == floorColorIndex && tileColorIndex >= 0 && tileColorIndex <= 6)
        {
            elapsedTime += Time.deltaTime;
            float fraction = Mathf.Sin(elapsedTime / totalTime);

            tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[tileColorIndex], fraction);
            floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[floorColorIndex], fraction);

            yield return null;
            //Debug.Log("Current Color Index: " + tileColorIndex);

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
