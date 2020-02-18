using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that when active shifts the colors on Tiles/Floors into new colors from predetermined list of colors
/// </summary>
/// <param name="RandomColor"></param>
public class RandomColor : MonoBehaviour
{
    // Both of tile/floor uses the same index so that the colors matches the same index on the lists of colors
    private ColorIndex randomColorIndex = new ColorIndex();

    [Tooltip("How fast will the change of color happen? The lower the value, the faster the change happens")]
    [SerializeField, Range(0.1f, 10f)] 
    private float changeColorTime = 1f;

    private float colorDuration;
    //private float currentColorDuration;
    [Tooltip("Duration of time left until the color on materials will change")]
    [SerializeField, Range(10f, 300f)]
    private float currentColorDuration = 30f;
    private float stopColorDuration = 0;
    // How much much of the current time is left until the color changes again?

    //public IEnumerator RandomColorCoroutine { get { return MakeRandomColor(); } }

    //private float elapsedTime = 0f;

    public static RandomColor Instance { get; private set; }
    Coroutine MakingRandomColor;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SelectNewRandomColorIndices();
        UpdateColors(1f);
    }

    private void Update()
    {
        //Debug.Log("Current elapsed time: " + (elapsedTime += Time.deltaTime));
    }

    /// <summary>
    /// Updates color indices for all indices
    /// </summary>
    private void SelectNewRandomColorIndices()
    {
        // Cycles the indices in the lists of colors (Tiles and Floors)
        // Copy this row and change tileIndex and tileColorList to floor or other, if adding more.
        SetNewColorIndice(randomColorIndex, ColorManager.Instance.ColorList);
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
    /// Updates colors for all materials by choosing a random index and shifts it over time
    /// </summary>
    /// <param name="fraction"></param>
    private void UpdateColors(float fraction)
    {
        // Updates the color of the material on Tiles and Floors
        UpdateTileColor(ColorManager.Instance.TileMaterial, ColorManager.Instance.ColorList, randomColorIndex, fraction); // Copy this row and change tileMaterial, tileIndex and tileColorList to floor or other, if adding more.
        UpdateFloorColor(ColorManager.Instance.FloorMaterial, ColorManager.Instance.ColorList, randomColorIndex, fraction);
        colorDuration = currentColorDuration;

    }

    /// <summary>
    /// Updates color for the Tile material
    /// </summary>
    /// <param name="material"></param>
    /// <param name="colorList"></param>
    /// <param name="indice"></param>
    /// <param name="fraction"></param>
    private void UpdateTileColor(Material material, Colors.ColorGroup[] colorList, ColorIndex indice, float fraction)
    {
        material.color = Color.Lerp(colorList[indice.previous].TileColor, colorList[indice.next].TileColor, fraction);   
    }

    /// <summary>
    /// Updates color for the Floor material
    /// </summary>
    /// <param name="material"></param>
    /// <param name="colorList"></param>
    /// <param name="indice"></param>
    /// <param name="fraction"></param>
    private void UpdateFloorColor(Material material, Colors.ColorGroup[] colorList, ColorIndex indice, float fraction)
    {
        material.color = Color.Lerp(colorList[indice.previous].FloorColor, colorList[indice.next].FloorColor, fraction);
    }

    /// <summary>
    /// Coroutine that shifts colors randomly
    /// </summary>
    IEnumerator MakeRandomColor()
    {
        //IEnumerator colorCoroutine = MakeRandomColor();
        // TODO 1a. Time still counts down, create variables to start and restart time
        // TODO 1b. figure out if stopping you should stop time here or somewhere else.
        while(true)
        {
            float elapsedTime = 0f;
            SelectNewRandomColorIndices(); // Select the new Colors
            while(elapsedTime <= changeColorTime)
            {
                // This loop makes sure the color is updated)
                elapsedTime += Time.deltaTime;

                float fraction = elapsedTime / changeColorTime;

                UpdateColors(fraction); // Update the actual material colors

                yield return new WaitForSeconds(0);
            }
            elapsedTime = 0;
            yield return new WaitForSeconds(currentColorDuration);
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
        //StartCoroutine(RandomColorCoroutine);
        //StartCoroutine(MakeRandomColor());
        MakingRandomColor = StartCoroutine(MakeRandomColor());
        Debug.Log("Corutine started!");
    }

    /// <summary>
    /// Stops the routine for shifting colors randomly
    /// </summary>
    public void StopRandomColor()
    {
        //StopCoroutine(RandomColorCoroutine);
        StopCoroutine(MakingRandomColor);
        Debug.Log("Coroutine stopped!");
    }
}