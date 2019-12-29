using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This manager is used to test a different implementation of a "visual" manager
/// </summary>
public class TestManager : MonoBehaviour
{

    /* Content, names and variables may be a subject to change.
       
       For testing purposes, this manager will use custom "classes",
       this is simply to see if this version of a "visual" manager 
       will work better in the long run.

       Inspiration for this implementation will be taken from the AudioManager
       and the Sound class.
    */
    [SerializeField]
    private SamuelEinheri.ToggleOption[] toggleOptions;
    [SerializeField]
    private SamuelEinheri.ColorOption[] colorOptions;

    List<string> colorNames = new List<string> { 
        "RED", 
        "ORANGE", 
        "YELLOW", 
        "GREEN", 
        "BLUE", 
        "INDIGO", 
        "VIOLET" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpecificColor(int index)
    { 
        if (index == 0)
        {
            //colorOptions[0].material.color = colorOptions[0].
        }
    }
}