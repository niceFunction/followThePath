using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
    For adding sound, to serve as a reminder:
    Introduction to AUDIO in Unity (Brackeys): www.youtube.com/watch?v=6OT43pvUyfY
    Fade Audio in Unity: https://johnleonardfrench.com/articles/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
*/
public class Player : MonoBehaviour
{

    // Lowpass Filter Related varaibels
    const float updateSpeed = 60.0f;

    float accelerometerUpdateInterval = 1.0f / updateSpeed;
    float lowPassKernelWidthInSeconds = 1.0f;
    float lowPassFilterFactor = 0;
    Vector3 lowPassValue = Vector3.zero;

    //Movement related variables
    public float speed = 500;
    public float maxSpeed = 40;
    
    // Audio related variables
    [HideInInspector]
    public AudioSource ballSource;
    [SerializeField]
    [Range(0.1f, 20f)]
    private float[] speedLimits;
    public AudioClip[] ballRollClips;

    [HideInInspector]
    public Rigidbody RB;
    
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        ballSource = GetComponent<AudioSource>();

        // Filter Accelerometer
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        lowPassValue = Input.acceleration;

    }

    private void Update()
    {
        // Get Raw Accelerometer values (pass in false to get raw Accelerometer values)
        Vector3 rawAccelValue = filterAccelValue(false);
        //Debug.Log("Raw X: " + rawAccelValue.x + " Y: " + rawAccelValue.y + " Z: " + rawAccelValue.z);

        // Get smoothed Accelerometer values (pass in true to get Filtered Accelerometer values)
        Vector3 filteredAccelValue = filterAccelValue(true);
        //Debug.Log("FILTERED X: " + filteredAccelValue.x + " Y: " + filteredAccelValue.y + " Z: " + filteredAccelValue.z);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(lowPassValue.x, 0.0f, lowPassValue.y);

#if UNITY_EDITOR
        // Allow other input controls in editor onlyz
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
#endif
        RB.AddForce(movement * speed * Time.deltaTime);

        // Limit Ball velocity
        if (RB.velocity.magnitude > maxSpeed)
        {
            RB.velocity = RB.velocity.normalized * maxSpeed;
        }

        #region Play ball different ball sounds depending on velocity
        if (RB.velocity.magnitude > speedLimits[0] && !ballSource.isPlaying)
        {
            ballSource.Stop();
            ballSource.PlayOneShot(ballSource.clip = ballRollClips[0]);
            
            if (RB.velocity.magnitude > speedLimits[1])
            {
                ballSource.Stop();
                ballSource.PlayOneShot(ballSource.clip = ballRollClips[1]);
            }
            if (RB.velocity.magnitude > speedLimits[2])
            {
                ballSource.Stop();
                ballSource.PlayOneShot(ballSource.clip = ballRollClips[2]);
            }
            if (RB.velocity.magnitude > speedLimits[3])
            {
                ballSource.Stop();
                ballSource.PlayOneShot(ballSource.clip = ballRollClips[3]);
            }
            if (RB.velocity.magnitude > speedLimits[4])
            {
                ballSource.Stop();
                ballSource.PlayOneShot(ballSource.clip = ballRollClips[4]);
            }
        }
        #endregion

        //Debug.Log("Player Velocity: " + RB.velocity.magnitude);
    }

    Vector3 filterAccelValue(bool smooth)
    {
        if (smooth)
        {
            lowPassValue = Vector3.Lerp(lowPassValue, Input.acceleration, lowPassFilterFactor);
        }
        else
        {
            lowPassValue = Input.acceleration;
        }
        return lowPassValue;
    }

}
