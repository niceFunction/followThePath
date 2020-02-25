using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions just like the normal "PlayerPrefs" but with bool instead
/// </summary>
public class PlayerPrefsX : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="name">Set the name of the Key</param>
	/// <param name="booleanValue">True or False value</param>
	public static void SetBool(string name, bool booleanValue)
	{
		PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
	}

	/// <summary>
	/// Get the Key (which should be a string)
	/// </summary>
	/// <param name="name">Get the name of the key (must be the same name as the Set- Key name)</param>
	/// <returns></returns>
	public static bool GetBool(string name)
	{
		return PlayerPrefs.GetInt(name) == 1 ? true : false;
	}

	public static bool GetBool(string name, bool defaultValue)
	{
		if (PlayerPrefs.HasKey(name))
		{
			return GetBool(name);
		}

		return defaultValue;
	}
}
