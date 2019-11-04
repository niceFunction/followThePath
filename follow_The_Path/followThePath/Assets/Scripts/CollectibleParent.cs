using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleParent : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleParent;

    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float clockwiseSpeed = 1.0f;
    
    [SerializeField]
    [Range(-1.0f, -0.01f)]
    private float counterClockwiseSpeed = -1.0f;

    private float currentSpeed;

    private int randomDirection; //= Random.Range(0, 1);
    private bool isClockwise = false;
    private bool isCounterClockwise = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        randomDirection = Random.Range(0, 2);
        Debug.Log("Rotation direction: " + randomDirection);
        if (randomDirection == 0)
        {
            currentSpeed = counterClockwiseSpeed;
        }
        else if (randomDirection == 1)
        {
            currentSpeed = clockwiseSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        collectibleParent.transform.Rotate(0, currentSpeed, 0);
    }
}
