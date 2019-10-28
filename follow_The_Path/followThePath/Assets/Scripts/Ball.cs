using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
    For adding sound, to serve as a reminder:
    Introduction to AUDIO in Unity (Brackeys): www.youtube.com/watch?v=6OT43pvUyfY
    Fade Audio in Unity: https://johnleonardfrench.com/articles/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
*/
public class Ball : MonoBehaviour
{
    //Movement related variables
    public float speed = 500;
    public float maxSpeed = 40;
    
    // Audio related variables
    private AudioSource ballSource;
    [SerializeField]
    [Range(0.1f, 20f)]
    private float[] speedLimits;
    public AudioClip[] ballRollClips;

    [HideInInspector]
    public Rigidbody RB;
    

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        ballSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);

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

        //Debug.Log("Player Velocity: " + RB.velocity.magnitude);
    }
}
