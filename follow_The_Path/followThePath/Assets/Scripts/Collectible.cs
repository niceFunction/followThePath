using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // SCORE & UI - Brackeys
    //youtu.be/TAGZxRMloyU
    private int collectValue = 1;
    private Collider scoreCube;
    public GameObject collectibleParent;
    [Range(0.1f, 1.0f)]
    public float destroyDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        scoreCube = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("DestroyObject", destroyDelay);
            Debug.Log("Player collided with Collectible");
        }
    }

    private void DestroyObject()
    {
        Object.Destroy(collectibleParent);
    }
}
