using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    //TODO personal note: Keep in mind that sound may repeat quickly if the player is colliding with Tile AND Propeller
    [SerializeField, Tooltip("Object to be rotated")]
    private GameObject rotateObject;
    public GameObject RotateObject { get { return rotateObject; } }

    [SerializeField, Range(0.01f, 10f), Tooltip("The speed the propeller is rotating")]
    private float rotationSpeed = 0.01f;
    public float RotationSpeed { get { return rotationSpeed; } }

    [SerializeField, Range(-1, 1), Tooltip("The direction the properller is rotating.\n " +
        "1 = clockwise, -1 = counterclockwise.\n" +
        "Shouldn't be 0.")]
    private int direction = 0; // If direction IS 0, the propeller won't rotate at all
    public int Direction { get { return direction; } set { direction = value; } }

    [SerializeField, Range(0, 100), Tooltip("Propeller will spin depending how close the Player is")]
    private float playerProximity = 10f;

    

    //public static Propeller Instance { get; private set; }

    private void Awake()
    {
        /*
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PROPELLER HAS SPAWNED");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsNear())
        {
            RotatePropeller();
        }
        else
        {
            // Personal note: Either do something or nothing at all
            StopPropeller();
        }
    }

    public void RotatePropeller()
    {
        RotateObject.transform.Rotate(0, (RotationSpeed * Direction) * Time.deltaTime, 0);
    }

    /// <summary>
    /// If the player is within a certain distance, rotate the propeller, if not, don't
    /// </summary>
    /// <returns></returns>
    private bool PlayerIsNear()
    {
        return Vector3.SqrMagnitude(transform.position - Player.Instance.transform.position) < (playerProximity * playerProximity);
    }

    /// <summary>
    /// If the Player has reached a certain distance, stop spinning
    /// </summary>
    private void StopPropeller()
    {
        if (Player.Instance.transform.position.z > transform.position.z + playerProximity)
        {
            Direction = 0;
        }
    }
}
