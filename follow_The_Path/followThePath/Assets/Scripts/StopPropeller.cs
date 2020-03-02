using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPropeller : MonoBehaviour
{
    [SerializeField, Tooltip("Stop the rotation of the propeller object\n" +
        "(Can be found in RoundAboutMidEnter objects)")]
    private GameObject propellerObject;
    public GameObject PropellerObject { get { return propellerObject; } }

    private bool havePlayerEntered;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // TODO destroy the attached object when the Player enters it

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has Entered");
            havePlayerEntered = true;
        }
        else
        {
            havePlayerEntered = false;
        }
    }
}
