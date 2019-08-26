using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ball : MonoBehaviour
{
    public float speed = 500;

    private Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);

        RB.AddForce(movement * speed * Time.deltaTime);
    }
}
