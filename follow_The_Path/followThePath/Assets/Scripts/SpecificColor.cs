using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class ColorValueEvent : UnityEvent<int>
{
    /*
       How to AddListener()featuring an argument?
       https://forum.unity.com/threads/how-to-addlistener-featuring-an-argument.266934/#post-1764063
    */
}

/// <summary>
/// Class that specifies a specific chosen color
/// </summary>
public class SpecificColor : MonoBehaviour
{
    /*
       Event Performance: C# vs UnityEvent
       https://jacksondunstan.com/articles/3335
       Removing Event Listeners
       https://jacksondunstan.com/articles/155
       UnityAction/UnityEvent - remove listener from within delegate
       https://answers.unity.com/questions/1492047/unityactionunityevent-remove-listener-from-within.html
       How to AddListener()featuring an argument?
       https://forum.unity.com/threads/how-to-addlistener-featuring-an-argument.266934/#post-1764063
    */

    private List<string> storeColorNames = new List<string>();

    public ColorValueEvent onColorValueEvent = new ColorValueEvent();

    UnityEvent colorValueEvent = new UnityEvent();
    UnityAction<int> colorValueAction = null;

    readonly string USE_SPECIFIC_COLOR;
    bool useSpecificColor;

    public static SpecificColor Instance { get; private set; }

    private void Start()
    {
        AddColorNamesToDropdown();
        GetDropdownValue();
    }

    private void Awake()
    {
        SetDropdownValue();
        colorValueAction = new UnityAction<int>(colorValueIndex => { SetColorValue(); });
    }

    /// <summary>
    /// Populates the "SetSpecificColor" dropdown with the names of colors from ColorList
    /// </summary>
    private void AddColorNamesToDropdown() // For reference: This could be any items that uses List
    {
        for (int i = 0; i < UxManager.Instance.ColorList.Length; i++)
        {
            UxManager.Instance.ColorDropdown.ClearOptions();
            storeColorNames.Add(UxManager.Instance.ColorList[i].Name);
            UxManager.Instance.ColorDropdown.AddOptions(storeColorNames);
        }
    }    

    /// <summary>
    /// When an "index" in the dropdown menu is chosen, sets materials to that color
    /// </summary>
    /// <param name="index"></param>
    public void ParticularColor(int index)
    {
        //TODO personal note: when specifying colors is inactive, replace the "SpecificColorsDropdown" strings with a string that says "Select a Color" or something
        if (index == 0)
        {
            // Set colors to RED
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[0].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[0].FloorColor;
        }
        else if (index == 1)
        {
            // Set colors to ORANGE
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[1].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[1].FloorColor;
        }
        else if (index == 2)
        {
            // Set colors to YELLOW
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[2].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[2].FloorColor;
        }
        else if (index == 3)
        {
            // Set colors to GREEN
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[3].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[3].FloorColor;
        }
        else if (index == 4)
        {
            // Set colors to BLUE
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[4].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[4].FloorColor;
        }
        else if (index == 5)
        {
            // Set colors to INDIGO
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[5].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[5].FloorColor;
        }
        else if (index == 6)
        {
            // Set colors to VIOLET
            UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[6].TileColor;
            UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[6].FloorColor;
        }
    }
    void SetDropdownValue()
    {
        UxManager.Instance.ColorDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            Debug.Log("Setting a Specific Color");
            PlayerPrefs.SetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorDropdown.value);
            //NOTE TO SELF: This PlayerPrefs.Save() may cause "slow-down" depending on platform
            PlayerPrefs.Save();
        }));
    }

    void SetColorValue()
    {
        PlayerPrefs.SetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorDropdown.value);
        PlayerPrefs.Save();
    }

    void GetDropdownValue()
    {
        UxManager.Instance.ColorDropdown.value = PlayerPrefs.GetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorList.Length - 1);
    }

    public void RemoveDropdownValue()
    {
        if (UxManager.Instance.RandomColorsToggle.GetComponent<Toggle>().isOn)
        {
            //UxManager.Instance.ColorDropdown.onValueChanged.RemoveListener(new UnityAction<int>(index =>
            //{
                //UxManager.Instance.ColorDropdown.value = PlayerPrefs.GetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorList.Length - 1);
                //gameObject.GetComponent<Toggle>().                
                Debug.Log("Removing listener");
                //PlayerPrefs.SetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorDropdown.value);
            //}));
        }
    }
}