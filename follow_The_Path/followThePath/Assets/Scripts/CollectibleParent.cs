using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to rotate the collectible along the Y-axis
/// </summary>
public class CollectibleParent : MonoBehaviour
{
    [Tooltip("Used to reference itself")]
    [SerializeField]
    private GameObject collectibleParent;

    [Tooltip("Set how fast the Collectible rotates, should be the same as counter-clockwise.")]
    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float clockwiseSpeed = 1.0f;
    
    [Tooltip("Set how fast the Collectible rotates, should be the same as clockwise.")]
    [SerializeField]
    [Range(-1.0f, -0.01f)]
    private float counterClockwiseSpeed = -1.0f;
    
    /// <summary>
    /// The collectibles current rotation
    /// </summary>
    private float currentRotation;
    /// <summary>
    /// Used to for choosing a direction
    /// </summary>
    private int randomDirection;


    private void Awake()
    {
        
        randomDirection = Random.Range(0, 2);
        //Debug.Log("Rotation direction: " + randomDirection);
        if (randomDirection == 0)
        {
            // Set currentRotation to Counter-Clockwise
            currentRotation = counterClockwiseSpeed;
        }
        else if (randomDirection == 1)
        {
            // Set currentRotation to Clockwise.
            currentRotation = clockwiseSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        collectibleParent.transform.Rotate(0, currentRotation, 0);
    }
}
