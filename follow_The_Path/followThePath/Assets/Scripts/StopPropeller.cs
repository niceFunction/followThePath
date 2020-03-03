using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPropeller : MonoBehaviour
{
    [SerializeField, Tooltip("Stop the rotation of the propeller object.\n" +
        "Will delete itself after Player object collides with itself")]
    private GameObject stopPropellerObject;
    public GameObject StopPropellerObject { get { return stopPropellerObject; } }


    [SerializeField, Tooltip("Add Gameobjects with TrailRenderers\n" +
        "For the Propeller, it should be 2, one for each propeller")]
    private TrailRenderer[] propellerTrailGroup;

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
            Propeller.Instance.Direction = 0;
            propellerTrailGroup[0].emitting = false;
            propellerTrailGroup[1].emitting = false;
            DestroyObject();
        }
    }
 
    private void DestroyObject()
    {
        Object.Destroy(StopPropellerObject);
    }
 
}
