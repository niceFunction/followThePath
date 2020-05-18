using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static Colors;

[CreateAssetMenu]
public class ColorList : ScriptableObject
{
    public ColorGroup[] Colors { get { return colors; } }
    [SerializeField] private ColorGroup[] colors;

}
