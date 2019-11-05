using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // SCORE & UI - Brackeys
    //youtu.be/TAGZxRMloyU
    //private int collectValue = 1;
    //private Collider scoreCube;

    [Tooltip("Destroy the Collectible parent, which this object is a child of.")]
    public GameObject collectibleParent;
    [Range(0.1f, 1.0f)]
    public float destroyDelay = 0.5f;

    /// <summary>
    /// Get the AudioSource component
    /// </summary>
    private AudioSource collectSource;
    /// <summary>
    /// The Audio Clip that's supposed to play
    /// </summary>
    public AudioClip collectClip;

    // Start is called before the first frame update
    void Start()
    {
        //scoreCube = GetComponent<Collider>();
        collectSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !collectSource.isPlaying)
        {
            Invoke("DestroyObject", destroyDelay);
            collectSource.Stop();
            collectSource.PlayOneShot(collectSource.clip = collectClip);
            Debug.Log("Player collided with Collectible");
        }
    }

    private void DestroyObject()
    {
        Object.Destroy(collectibleParent);
    }
}
