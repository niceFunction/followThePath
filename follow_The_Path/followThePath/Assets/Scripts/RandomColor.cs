using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A temporary class for testing new method of randomizing order of colors from predetermined "list" of colors
/// </summary>
/// <param name="RandomColor"></param>
public class RandomColor : MonoBehaviour
{
    // Both of tile/floor uses the same index so that the colors matches the same index on the lists of colors
    private ColorIndex randomColorIndex = new ColorIndex();

    [Tooltip("How fast will the change of color happen? The lower the value, the faster the change happens")]
    [SerializeField, Range(0.1f, 10f)] 
    private float changeColorTime = 1f;

    [Tooltip("Duration of time left until the color on materials will change")]
    [SerializeField, Range(10f, 300f)]
    private float changeColorDuration = 30f;
    // How much much of the current time is left until the color changes again?
    private float currentColorDuration;

    public static RandomColor Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SelectNewRandomColorIndices();
        UpdateColors(1f);
    }

    /// <summary>
    /// Updates color indices for all indices
    /// </summary>
    private void SelectNewRandomColorIndices()
    {
        // Cycles the indices in the lists of colors (Tiles and Floors)
        //SetNewColorIndice(randomColorIndex, ColorManager.Instance.TileColorList); // Copy this row and change tileIndex and tileColorList to floor or other, if adding more.
        //SetNewColorIndice(randomColorIndex, ColorManager.Instance.FloorColorList);
        SetNewColorIndice(randomColorIndex, );
    }

    /// <summary>
    /// Selects new indices for the provided indice, from the provided list.
    /// </summary>
    /// <param name="indice">The indice to update</param>
    /// <param name="colors">The list of colors to choose from</param>
    private void SetNewColorIndice(ColorIndex indice, Colors.ColorGroup[] colors)
    {
        int maxValue = colors.Length - 1;
        // We've completed one full cycle of color fade, so "next" color index should be saved as "previous"
        indice.previous = indice.next;
        // Select a new color from the provided list
        indice.next = UnityEngine.Random.Range(0, maxValue);
    }

    /// <summary>
    /// Updates colors for all materials
    /// </summary>
    /// <param name="fraction"></param>
    private void UpdateColors(float fraction)
    {
        // Updates the color of the material on Tiles and Floors
        UpdateColor(ColorManager.Instance.TileMaterial, ColorManager.Instance.TileColorList, randomColorIndex, fraction); // Copy this row and change tileMaterial, tileIndex and tileColorList to floor or other, if adding more.
        UpdateColor(ColorManager.Instance.FloorMaterial, ColorManager.Instance.FloorColorList, randomColorIndex, fraction);
        currentColorDuration = changeColorDuration;

    }

    /// <summary>
    /// Updates color for the specified material
    /// </summary>
    /// <param name="material"></param>
    /// <param name="colorList"></param>
    /// <param name="indice"></param>
    /// <param name="fraction"></param>
    private void UpdateColor(Material material, Color[] colorList, ColorIndex indice, float fraction)
    {
        material.color = Color.Lerp(colorList[indice.previous], colorList[indice.next], fraction);
    }

    /// <summary>
    /// "Blends" one color into another predetermined color 
    /// </summary>
    IEnumerator MakeRandomColor()
    {
        float elapsedTime = 0f;
        
        while(true)
        {
            SelectNewRandomColorIndices(); // Select the new Colors
            while(elapsedTime <= changeColorTime)
            {
                // This loop makes sure the color is updated
                elapsedTime += Time.deltaTime;
                // float fraction = Mathf.Sin(elapsedTime / changeColorTime);
                float fraction = elapsedTime / changeColorTime;

                UpdateColors(fraction); // Update the actual material colors

                yield return new WaitForSeconds(0);
            }
            elapsedTime = 0;
            yield return new WaitForSeconds(changeColorDuration);
        }  
    }

    /// <summary>
    /// To easier keep track of two indices
    /// </summary>
    private class ColorIndex
    {
        public int previous, next;
    }

    /// <summary>
    /// Starts the routine for shifting colors randomly
    /// </summary>
    public void StartRandomColor()
    {
        StartCoroutine(MakeRandomColor());
    }

    /// <summary>
    /// Stops the routine for shifting colors randomly
    /// </summary>
    public void StopRandomColor()
    {
        StopCoroutine(MakeRandomColor());
    }
}