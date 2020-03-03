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
    private int direction = 0;
    public int Direction { get { return direction; } set { direction = value; } }

    //private int stopDirection = 0;
    //public int StopDirection { get { return stopDirection; } }

    public static Propeller Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Direction: " + direction);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePropeller();
    }

    public void RotatePropeller()
    {
        RotateObject.transform.Rotate(0, (RotationSpeed * Direction) * Time.deltaTime, 0);
    }
}
