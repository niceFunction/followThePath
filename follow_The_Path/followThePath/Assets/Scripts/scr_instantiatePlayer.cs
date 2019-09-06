using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Remove this class, as it is unused.
public class scr_instantiatePlayer : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject playerObject;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(playerObject, new Vector3(0, 0.5f, 0), Quaternion.identity);
    }
}
