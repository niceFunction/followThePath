using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    //private bool trailActive = false;
    private Player Ball;
    private TrailRenderer Trail;

    [Range(0.1f, 8.0f)]
    public float triggerTrail = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GetComponentInParent<Player>();
        Trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Ball.RB.velocity.magnitude < triggerTrail)
        {
            Trail.emitting = false;
        }
        else if(Ball.RB.velocity.magnitude > triggerTrail)
        {
            Trail.emitting = true;
        }
    }
}