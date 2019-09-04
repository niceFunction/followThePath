using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : scr_PooledObject
{
    [SerializeField] private float length = 20f;

    [SerializeField] private Tile[] connectsTo;

    public Tile SpawnNext()
    {
        Tile t = connectsTo[Random.Range(0, connectsTo.Length)];
        t = Instantiate(t.gameObject).GetComponent<Tile>();
        t.transform.position = this.transform.position + new Vector3(0f, 0f, length);

        return t;
    }
}
