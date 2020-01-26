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

    private Color currentRandomColorOne;
    private Color currentRandomColorTwo;

    private Color colorA;
    private Color colorB; 

    private float changeColorTimeAmount;
    public float changeColorTimeReset;
    private bool isChangingColor;

    // Start is called before the first frame update
    void Start()
    {
        changeColorTimeAmount = changeColorTimeReset;
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeNewRandomColor();
        print("Time is: " + changeColorTimeAmount);
    }

    private void ChangeNewRandomColor()
    {
        changeColorTimeAmount -= Time.deltaTime;

        if (changeColorTimeAmount < 0)
        {
            Debug.Log("Changing color now!");
            changeColorTimeAmount = changeColorTimeReset;
            // Start the Coroutine here
            StartCoroutine(MakeRandomColor());
        }
    }

    private void SetColorValue()
    {
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
        
    }
    
}
