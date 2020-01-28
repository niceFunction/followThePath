using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A temporary class for testing new method of randomizing order of colors from predetermined "list" of colors
/// </summary>
/// <param name="RandomColor"></param>
public class RandomColor : MonoBehaviour
{
    [SerializeField, Tooltip("First random color material")]
    private Material tileMaterial;
    [SerializeField, Tooltip("Second random color material")]
    private Material floorMaterial;

    [SerializeField, Tooltip("List of colors for the first material")]
    private Color[] tileColorList; // This variable will be replaced by "tileMaterial"
    [SerializeField, Tooltip("List of colors for the second material")]
    private Color[] floorColorList; // This variable will be replaced by "floorMaterial"

    //private Color currentRandomColorOne;
    //private Color currentRandomColorTwo;

    private Color currentTileColor;
    private Color currentFloorColor;

    private Color previousTileColor;
    private Color previousFloorColor;

    private Color colorA;
    private Color colorB; 

    [SerializeField]
    private float changeColorTimeAmount;
    public float changeColorTimeReset;
    private bool isChangingColor;

    List<Color> tileColors = new List<Color>();
    List<Color> floorColors = new List<Color>();

    bool hasSetFirstColor = false;

    // Start is called before the first frame update
    void Start()
    {

        tileColors.AddRange(tileColorList);
        floorColors.AddRange(floorColorList);
        
        changeColorTimeAmount = changeColorTimeReset;
        StartCoroutine(MakeRandomColor());
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeNewRandomColor();
        //print("Time is: " + changeColorTimeAmount);
    }

    private void ChangeNewRandomColor()
    {
        /* changeColorTimeAmount -= Time.deltaTime;

        if (changeColorTimeAmount < 0)
        {
            Debug.Log("Changing color now!");
            changeColorTimeAmount = changeColorTimeReset;
            // Start the Coroutine here
            StartCoroutine(MakeRandomColor());
        }


        Color tempTileColor = null;
        if (currentTileColor != null)
        {
            tempTileColor = previousTileColor;
        }

        currentTileColor = tileColors(Random.Range(0, randomColorListOne.Length));
        

        if (tempTileColor != null)
        {
            // Put the temp color back into the list
        }
        */
        Color tempTileColor = previousTileColor;
        /*
         Error Message:
         Index was out of range. Must be non-negative and 
         less than the size of the collection.
        */
        /*
         For some reason "index" goes out of "range", in the Editor it (for some reason)
         creates either high or low number of int values
        */
        //TODO quesation: Replace ".Length" with ".GetUpperBound(0)"? and replace "(0)" with ".GetLowerBound(0)"?
        int index = Random.Range(tileColorList.GetLowerBound(0), tileColorList.Length); 
        Debug.Log(index);
        currentTileColor = tileColorList[index];

        tileColors.RemoveAt(index);
        if (hasSetFirstColor)
        {
            tileColors.Add(tempTileColor);
            
        }
        hasSetFirstColor = true;
    }

    private void SetColorValue(float fraction)
    {
        /*
         I need to use "material" and (in my case) "currentTileColor"
            
        randomColorMaterialOne.color = currentTileColor;
        */

        /*
        What is an IndexOutOfRangeException / ArgumentOutOfRangeException and how do I fix it?
        https://stackoverflow.com/questions/20940979/what-is-an-indexoutofrangeexception-argumentoutofrangeexception-and-how-do-i-f
        
        Index was out of range. Must be non-negative or less than size of collection
         https://stackoverflow.com/questions/30974623/index-was-out-of-range-must-be-non-negative-or-less-than-size-of-collection

        */
        // TODO Calculate the new exact color to apply to the material, using the material and currentFloorColor
        tileMaterial.color = currentTileColor;
        Debug.Log("Current color index is: " + currentTileColor);
    }

    IEnumerator MakeRandomColor()
    {
        float elapsedTime = 0f;
        float totalTime = changeColorTimeAmount;
        
        while(true)
        {
            ChangeNewRandomColor(); // Select the new Color
            while(elapsedTime < totalTime)
            {
                // This loop makes sure the color is updated
                elapsedTime += Time.deltaTime;
                float fraction = Mathf.Sin(elapsedTime / totalTime);
                SetColorValue(fraction);
            }
            SetColorValue(1f); // Just to make sure the colors are 100% this color
        }
        
    }
    
}
