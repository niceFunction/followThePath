using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DetectCollision : MonoBehaviour
{
    //public GameObject playerObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tile") 
        {
            Debug.Log("Collision Detected");
        }
        
    }
}
