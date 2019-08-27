using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private float length = 19.9f;

    [SerializeField] private Tile[] connectsTo;

    public Tile SpawnNext()
    {
        Tile t = connectsTo[Random.Range(0, connectsTo.Length)];
        t = Instantiate(t.gameObject).GetComponent<Tile>();
        t.transform.position = this.transform.position + new Vector3(0f, 0f, length);

        return t;
    }
}
