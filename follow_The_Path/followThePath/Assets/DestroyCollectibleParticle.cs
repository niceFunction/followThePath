﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectibleParticle : MonoBehaviour
{
    private ParticleSystem collectibleParticles;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
