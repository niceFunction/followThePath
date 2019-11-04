using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DetectBallCollision : MonoBehaviour
{
    private AudioSource collisionSource;
    public AudioClip[] collisionClips;

    private void Start()
    {
        collisionSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("Ball collided with wall");
            collisionSource.Stop();
            collisionSource.PlayOneShot(collisionSource.clip = collisionClips[Random.Range(0, collisionClips.Length)]);
        }
        
    }
}
