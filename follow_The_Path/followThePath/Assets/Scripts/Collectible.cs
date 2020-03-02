﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // SCORE & UI - Brackeys
    //youtu.be/TAGZxRMloyU
    //private int collectValue = 1;
    //private Collider scoreCube;

    private GameManager gameManager;
    public int collectibleScore;

    [Tooltip("Destroy the Collectible parent, which this object is a child of.")]
    public GameObject collectibleParent;
    [Range(0.1f, 1.0f)]
    public float destroyDelay = 0.5f;

    public GameObject collectibleEffect;

    // Used to make the Collectible "appear" in the scene
    private float appearanceChance;
    private float appearanceChanceValue = 0.2f;

    /// <summary>
    /// Access the collectibles mesh, a workaround to continue playing an SFX when collectible is "destroyed".
    /// </summary>
    MeshRenderer collectibleMesh;
    BoxCollider collectibleCollider;

    /// <summary>
    /// "Get" the AudioSource component
    /// </summary>
    private AudioSource collectSource;
    /// <summary>
    /// The Audio Clip that's supposed to play
    /// </summary>
    public AudioClip collectClip;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManagerObject = GameObject.FindWithTag("GameManager");

        if (GameManagerObject != null)
        {
            gameManager = GameManagerObject.GetComponent<GameManager>();
        }
        else if (gameManager == null)
        {
            Debug.LogWarning("Game Manager not found!");
        }

        collectibleMesh = GetComponent<MeshRenderer>();
        collectibleCollider = GetComponent<BoxCollider>();
        collectSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // How big of a chance will the "Collectible" stay in the Scene?
        appearanceChance = Random.Range(0, 2);
        if (appearanceChance < appearanceChanceValue)
        {
            DestroyObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !collectSource.isPlaying)
        {
            /*
            Disable the collectible renderer before invoking "DestroyObject" method, 
            so that the AudioClip can finish playing.
            */
            collectibleMesh.enabled = false;
            
            /* 
            Disable the collectible Box Collider before invoking "DestroyObject" method, 
            to ensure no more collision happens.
            */
            collectibleCollider.enabled = false;
            Explode();
            // Invoke DestroyObject method
            Invoke("DestroyObject", destroyDelay);
            collectSource.Stop();
            collectSource.PlayOneShot(collectSource.clip = collectClip);

            gameManager.AddScore(collectibleScore);
            Debug.Log("Player collided with Collectible");
        }
    }

    private void DestroyObject()
    {
        Object.Destroy(collectibleParent);
    }

    void Explode()
    {
        Instantiate(collectibleEffect, transform.position, transform.rotation);
    }

}
