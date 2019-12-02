using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    /// colorDropDown and randomizeColorsToggle are used for specifying colors
    /// </summary>
    [Tooltip("Create Dropdown UI element and add it here")]
    public TMP_Dropdown colorDropdown; 
    [Tooltip("Create Toggle UI element and add it here")]
    public Toggle randomizeColorsToggle;

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

    // Variables used to set specific colors
    List<string> colorNames = new List<string>() { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };


    // https://flaredust.com/game-dev/unity/having-fun-with-shaders-in-unity/
    public static ColorManager ColorInstance { get; private set; }

    void Awake()
    {
        if (ColorInstance == null)
        {
            ColorInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

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
        SetColorMode();
        Debug.Log("Random Color Timer: " + colorChangeTimer);
    }

    public void SetColorMode()
    {
        if (randomizeColorsToggle.isOn == true)
        {
            ///<summary>
            /// Color Randomization is active and set specific color dropdown is non-interactable
            /// </summary>
            colorDropdown.interactable = false;
            NewRandomColor();
            PlayerPrefs.Save();
        }
        else if (randomizeColorsToggle.isOn == false)
        {
            ///<summary>
            /// Color randomization is inactive and set specific color dropdown is interactable
            /// </summary>
            colorDropdown.interactable = true;
            colorChangeTimer = colorChangeTimerReset;
            PlayerPrefs.Save();
        }
    }

    public void NewRandomColor()
    {
        colorChangeTimer -= Time.deltaTime;

        if (colorChangeTimer < 0 && !currentlyChangingColor)
        {
            currentlyChangingColor = true;
            colorChangeTimer = colorChangeTimerReset;
            StartCoroutine(SetRandomColor());
        }
    }

    /// <summary>
    /// This Coroutine is used to randomize the "Tile" colors using Random.Range
    /// </summary>
    /// <returns></returns>
    IEnumerator SetRandomColor()
    {
        #region Randomize colors
        currentlyChangingColor = true;
        //TODO Look more into getting random element from array
        Debug.Log("Random Color Timer: " + colorChangeTimer);
        ///<summary>
        /// Using tileColorList as the 2nd argument in Random.Range as both
        /// of the tile- and floor mateial color arrays are of the same length.
        /// </summary>
        int colorIndex = Random.Range(0, tileColorList.Length);

        Debug.Log("Color Element is: " + colorIndex);

        float elapsedTime = 0.0f;
        float totalTime = 6.0f;

        // Set the materials into a random color
        #region Old arguments used for while loop
        /* 
           while (elapsedTime < totalTime && tileColorList == floorColorList && tileColorIndex >= 0 && tileColorIndex <= 0)

            int tileColorIndex = Random.Range(0, tileColorList.Length);
            int floorColorIndex = Random.Range(0, floorColorIndex.Length);

           tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[tileColorIndex], fraction);
           floorMaterial.color = Color.Lerp(currentTileColor, tileColorList[floorColorIndex], fraction);
         */
        #endregion

        while (elapsedTime < totalTime && colorIndex >= 0 && colorIndex <= 6)
        {
            elapsedTime += Time.deltaTime;
            float fraction = Mathf.Sin(elapsedTime / totalTime);

            tileMaterial.color = Color.Lerp(currentTileColor, tileColorList[colorIndex], fraction);
            floorMaterial.color = Color.Lerp(currentFloorColor, floorColorList[colorIndex], fraction);

            yield return null;
        }
        currentlyChangingColor = false;
        #endregion
    }

    // Leave this be for now
    // https://www.youtube.com/watch?v=Q4NYCSIOamY
    // https://www.youtube.com/watch?v=LRoqGsJGgA4.
    void PopulateColorList()
    {
        colorDropdown.AddOptions(colorNames);
    }

    public void SetSpecificColor(int index)
    {
        #region Set materials to a specific color
        if (index == 0)
        {
            tileMaterial.color = tileColorList[0];
            floorMaterial.color = floorColorList[0];
        }
        else if (index == 1)
        {
            tileMaterial.color = tileColorList[1];
            floorMaterial.color = floorColorList[1];
        }
        else if (index == 2)
        {
            tileMaterial.color = tileColorList[2];
            floorMaterial.color = floorColorList[2];
        }
        else if (index == 3)
        {
            tileMaterial.color = tileColorList[3];
            floorMaterial.color = floorColorList[3];
        }
        else if (index == 4)
        {
            tileMaterial.color = tileColorList[4];
            floorMaterial.color = floorColorList[4];
        }
        else if (index == 5)
        {
            tileMaterial.color = tileColorList[5];
            floorMaterial.color = floorColorList[5];
        }
        else if (index == 6)
        {
            tileMaterial.color = tileColorList[6];
            floorMaterial.color = floorColorList[6];
        }
        #endregion
    }
}
