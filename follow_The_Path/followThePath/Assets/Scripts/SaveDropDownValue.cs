using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class SaveDropDownValue : MonoBehaviour
{

    const string colorName = "colorValue";
    [SerializeField]
    private TMP_Dropdown colorDropdown;

    private void Awake()
    {
        SetDropdownValue();
        Debug.Log(colorDropdown.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetDropdownValue();
    }

    void SetDropdownValue()
    {
        colorDropdown = GetComponent<TMP_Dropdown>();
        colorDropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(colorName, colorDropdown.value);
            // This PlayerPrefs.Save() may cause "slow-down" depending on platform
            PlayerPrefs.Save();
        }));
    }

    void GetDropdownValue()
    {
        colorDropdown.value = PlayerPrefs.GetInt(colorName, UxManager.Instance.ColorList.Length - 1);
    }

}
