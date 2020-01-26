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
    private Material randomColorMaterialOne;
    [SerializeField, Tooltip("Second random color material")]
    private Material randomColorMaterialTwo;

    [SerializeField, Tooltip("List of colors for the first material")]
    private Color[] randomColorListOne; // This variable will be replaced by "tileMaterial"
    [SerializeField, Tooltip("List of colors for the second material")]
    private Color[] randomColorListTwo; // This variable will be replaced by "floorMaterial"

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

        tileColors.AddRange(randomColorListOne);
        floorColors.AddRange(randomColorListTwo);
        changeColorTimeAmount = changeColorTimeReset;
        StartCoroutine(MakeRandomColor());
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeNewRandomColor();
        print("Time is: " + changeColorTimeAmount);
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
        int index = Random.Range(0, randomColorListOne.Length);
        currentTileColor = randomColorListOne[index];

        tileColors.RemoveAt(index);
        if (hasSetFirstColor)
        {
            tileColors.Add(tempTileColor);
            hasSetFirstColor = true;
        }
    }

    private void SetColorValue()
    {

        // TODO Calculate the new exact color to apply to the material, using the material and currentFloorColor

        //int colorIndexA = Random.Range(0, randomColorListOne.Length);
        //int colorA = randomColorListOne[i];

        //int colorIndexA = Random.Range(0, randomColorListOne.Length);
        //Color colorA = randomColorListOne[colorIndexA];
    }

    IEnumerator MakeRandomColor()
    {
        /*
        float elapsedTime = 0.0f;
        float totalTime = 6.0f;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            float fraction = Mathf.Sin(elapsedTime / totalTime);
        }
        */
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
                //SetColorValue(fraction);
            }
            //SetColorValue(1f);
        }
    }
    
}
