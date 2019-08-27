using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TileManager : MonoBehaviour
{
    [SerializeField] private Tile startTile;

    // Serialized private fields, because we don't want other objects to access these
    [SerializeField] private GameObject[] leftTilePrefabs;
    [SerializeField] private GameObject[] midTilePrefabs;
    [SerializeField] private GameObject[] rightTilePrefabs;

    [SerializeField] private float tileLength = 19.9f;
    [SerializeField] private int tilesToSpawn = 20;

    

    // Start is called before the first frame update
    void Start()
    {
        Tile tile = startTile;
        for (int i = 0; i < tilesToSpawn; i++)
        {
            tile = tile.SpawnNext();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
