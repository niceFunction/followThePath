using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ColorEvent : UnityEvent<int>
{
    public ColorEvent onColorEventChange = new ColorEvent();

    void InvokeColorEvent()
    {
        onColorEventChange.Invoke(0);
    }

}
