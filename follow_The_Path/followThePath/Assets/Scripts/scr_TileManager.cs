using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TileManager : MonoBehaviour
{

    private int tilesToRemove = 3;

    [SerializeField] private Tile startTile;

    [SerializeField] private Transform player;

    // Serialized private fields, because we don't want other objects to access these
    [SerializeField] private GameObject[] leftTilePrefabs;
    [SerializeField] private GameObject[] midTilePrefabs;
    [SerializeField] private GameObject[] rightTilePrefabs;

    [SerializeField] private float tileLength = 20f;
    [SerializeField] private int tilesToSpawn = 2;

    private Tile lastSpawnedTile;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnedTile = startTile;
        SpawnTiles();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTiles();
    }

    void SpawnTiles()
    {

        // Spawn a new tile if the player is sufficiently far
        if (player.position.z + (tilesToSpawn * tileLength) > lastSpawnedTile.transform.position.z)
        {
            lastSpawnedTile = lastSpawnedTile.SpawnNext();

        }
    }
}
