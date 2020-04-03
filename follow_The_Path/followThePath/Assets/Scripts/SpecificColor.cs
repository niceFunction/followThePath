using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

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

    readonly string USE_SPECIFIC_COLOR;
    readonly string USE_SPECIFIC_COLOR_INDEX;
    bool useSpecificColor;

    public static SpecificColor Instance { get; private set; }

    private void Start()
    {
        AddColorNamesToDropdown();
        PlayerPrefs.GetInt(USE_SPECIFIC_COLOR_INDEX);
        GetDropdownValue();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
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
        // THIS COLOR IS NEVER SAVED
        UxManager.Instance.TileMaterial.color = UxManager.Instance.ColorList[index].TileColor;
        UxManager.Instance.FloorMaterial.color = UxManager.Instance.ColorList[index].FloorColor;
        
        PlayerPrefs.SetInt(USE_SPECIFIC_COLOR_INDEX, index);
        SaveColorValue();
    }

    /// <summary>
    /// Saves the currently set color to player preferences.
    /// </summary>
    public void SaveColorValue()
    {
        PlayerPrefs.SetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorDropdown.value);
        PlayerPrefs.Save();
    }

    void GetDropdownValue()
    {
        UxManager.Instance.ColorDropdown.value = PlayerPrefs.GetInt(USE_SPECIFIC_COLOR, UxManager.Instance.ColorList.Length - 1);
    }

}