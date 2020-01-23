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

    private Color nextColor;

    private List<int> randomColorIndex = new List<int>();

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
        ChangeNewRandomColor();
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
        }
    }

    private void GetColorIndex(int index)
    {
        if (index == 0)
        {
            randomColorMaterialOne.color = randomColorListOne[0];
        }
        else if (index == 1)
        {
            randomColorMaterialOne.color = randomColorListOne[1];
        }
        else if (index == 2)
        {
            randomColorMaterialOne.color = randomColorListOne[2];
        }
        else if (index == 3)
        {
            randomColorMaterialOne.color = randomColorListOne[3];
        }
        else if (index == 4)
        {
            randomColorMaterialOne.color = randomColorListOne[4];
        }
        else if (index == 5)
        {
            randomColorMaterialOne.color = randomColorListOne[5];
        }
        else if (index == 6)
        {
            randomColorMaterialOne.color = randomColorListOne[6];
        }
    }


}
