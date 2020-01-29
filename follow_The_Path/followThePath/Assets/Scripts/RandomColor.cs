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

    private ColorIndex tileIndex = new ColorIndex();

    [SerializeField, Range(0.1f, 10f)] private float changeColorTime = 1f;

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
        SetNewColorIndice(tileIndex, tileColorList); // Copy this row and change tileIndex and tileColorList to floor or other, if adding more.
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

    private void UpdateColors(float fraction)
    {
        UpdateColor(tileMaterial, tileColorList, tileIndex, fraction); // Copy this row and change tileMaterial, tileIndex and tileColorList to floor or other, if adding more.
    }
    private void UpdateColor(Material material, Color[] colorList, ColorIndex indice, float fraction)
    {
        material.color = Color.Lerp(colorList[indice.previous], colorList[indice.next], fraction);
    }

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

                UpdateColors(fraction);

                yield return new WaitForEndOfFrame();
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
