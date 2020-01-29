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
    private Color[] tileColorList;
    [SerializeField, Tooltip("List of colors for the second material")]
    private Color[] floorColorList;

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
    bool hasSetSecondColor = false;

    // Start is called before the first frame update
    void Start()
    {

        tileColors.AddRange(tileColorList);
        floorColors.AddRange(floorColorList);
        
        changeColorTimeAmount = changeColorTimeReset;
        StartCoroutine(MakeRandomColor());
        currentTileColor = tileMaterial.color;

        //previousTileColor = tileMaterial.color;
        SetColorValue(1f);
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeNewRandomColor();
        //print("Time is: " + changeColorTimeAmount);
    }

    private void ChangeNewRandomColor()
    {
        Color tempTileColorOne = previousTileColor;

        Debug.Log("Previous color: " + previousTileColor);

        //TODO quesation: Replace ".Length" with ".GetUpperBound(0)"? and replace "(0)" with ".GetLowerBound(0)"?
        int indexOne = Random.Range(0, tileColorList.Length - 1); 
        Debug.Log("indexOne is: " + indexOne);
        currentTileColor = tileColorList[indexOne];

        tileColors.RemoveAt(indexOne);
        if (hasSetFirstColor)
        {
            tileColors.Add(tempTileColorOne);
            
        }
        
        hasSetFirstColor = true;

        if (hasSetFirstColor == true)
        {
            Color tempTileColorTwo = tempTileColorOne;

            int indexTwo = Random.Range(0, tileColorList.Length - 1);
            currentTileColor = tileColorList[indexTwo];

            tileColors.RemoveAt(indexTwo);
            if (hasSetSecondColor)
            {
                //tileColors.Add(currentTileColor);
                tileColors.Insert(indexOne, currentTileColor);
                tileColors.Add(tempTileColorTwo);
            }
            hasSetSecondColor = true;
            // something here
            /*
             B. Choose random color from list and pick it out (save as "ColorA")
             c. Choose new random color from list and pick it out (save as "ColorB")
             D. Put ColorA back to list
             E. Save ColorB as ColorA
             F. Repeat from C.
            */

        }
    }

    private void SetColorValue(float fraction)
    {
        // TODO Calculate the new exact color to apply to the material, using the material and currentFloorColor
        tileMaterial.color = Color.Lerp(previousTileColor, currentTileColor, fraction);
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

                yield return new WaitForSeconds(0);
            }
            elapsedTime = 0;

            SetColorValue(1f); // Just to make sure the colors are 100% this color
        }
        
    }
    
}
