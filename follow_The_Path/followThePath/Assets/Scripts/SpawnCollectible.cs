using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{

    public GameObject collectibleObject;

    private float spawnChance;
    private float spawnChanceValue = 0.2f;

    private void Awake()
    {
        CreateCollectible();
    }

    void CreateCollectible()
    {
        spawnChance = Random.Range(0, 2);
        
        if (spawnChance > spawnChanceValue)
        {
            Instantiate(collectibleObject, transform.position, transform.rotation);
            DestroySpawner();
        }
        else if (spawnChance < spawnChanceValue)
        {
            DestroySpawner();
        }
    }

    void DestroySpawner()
    {
        Destroy(this.gameObject);
    }
}
