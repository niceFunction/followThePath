using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all tiles
/// </summary>
/// <param name="scr_TileManager"></param>
public class scr_TileManager : MonoBehaviour
{

    public Tile[] tilePrefabs;

    [SerializeField] private Tile startTile;

    [SerializeField] private Transform player;

    [SerializeField] private int safeDistance = 4;

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

    /// <summary>
    /// SpawnTiles() tells new tiles to place themselves relative to the previous tile
    /// </summary>
    void SpawnTiles()
    {
        Tile tile;
        // Spawn a new tile if the player is sufficiently far
        if(player.position.z + safeDistance > lastSpawnedTile.transform.position.z + lastSpawnedTile.Length)
        {
            Tile choosePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
            Tile t = TilePool.GetFromPool(choosePrefab.gameObject);

            t.SetPositionAfter(lastSpawnedTile);
            lastSpawnedTile = t;
        }
    }

}
