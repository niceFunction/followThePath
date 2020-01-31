using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A temporary class for testing new method of randomizing order of colors from predetermined "list" of colors
/// </summary>
/// <param name="RandomColor"></param>
public class RandomColor : MonoBehaviour
{
    [SerializeField, Tooltip("The material attached to the Tiles")]
    private Material tileMaterial;
    [SerializeField, Tooltip("The material attached to the Floors")]
    private Material floorMaterial;

    [SerializeField, Tooltip("List of colors for the Tiles (In lighter hues)")]
    private Color[] tileColorList;
    [SerializeField, Tooltip("List of colors for the Floors (in darker hues)")]
    private Color[] floorColorList;

    private ColorIndex tileIndex = new ColorIndex();

    [Tooltip("How fast will the change of color happen? The lower the value, the faster the change happens")]
    [SerializeField, Range(0.1f, 10f)] 
    private float changeColorTime = 1f;

    [Tooltip("How much time will pass until the color changes again?")]
    [SerializeField, Range(10f, 300f)]
    private float changeColorDuration = 30f;

    void Start()
    {
        SelectNewRandomColorIndices();
        UpdateColors(1f);
        
        StartCoroutine(MakeRandomColor());
    }

    /// <summary>
    /// Updates color indices for all indices
    /// </summary>
    private void SelectNewRandomColorIndices()
    {
        // Cycles the indices in the lists of colors (Tiles and Floors)
        SetNewColorIndice(tileIndex, tileColorList); // Copy this row and change tileIndex and tileColorList to floor or other, if adding more.
        SetNewColorIndice(tileIndex, floorColorList);
    }

    /// <summary>
    /// Selects new indices for the provided indice, from the provided list.
    /// </summary>
    /// <param name="indice">The indice to update</param>
    /// <param name="colors">The list of colors to choose from</param>
    private void SetNewColorIndice(ColorIndex indice, Color[] colors)
    {
        // We've completed one full cycle of color fade, so "next" color index should be saved as "previous"
        indice.previous = indice.next;
        // Select a new color from the provided list
        indice.next = Random.Range(0, colors.Length - 1);
    }

    /// <summary>
    /// Updates colors for all materials
    /// </summary>
    /// <param name="fraction"></param>
    private void UpdateColors(float fraction)
    {
        // Updates the color of the material on Tiles and Floors
        UpdateColor(tileMaterial, tileColorList, tileIndex, fraction); // Copy this row and change tileMaterial, tileIndex and tileColorList to floor or other, if adding more.
        UpdateColor(floorMaterial, floorColorList, tileIndex, fraction);
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
            while(elapsedTime < changeColorTime)
            {
                // This loop makes sure the color is updated
                elapsedTime += Time.deltaTime;
                float fraction = Mathf.Sin(elapsedTime / changeColorTime);

                UpdateColors(fraction); // Update the actual material colors

                yield return new WaitForSeconds(0);
            }
            elapsedTime = 0;
        }  
    }

    /// <summary>
    /// To easier keep track of two indices
    /// </summary>
    private class ColorIndex
    {
        public int previous, next;
    }
}