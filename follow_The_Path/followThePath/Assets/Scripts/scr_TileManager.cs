using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TileManager : MonoBehaviour
{

    public Tile[] tilePrefabs;

    [SerializeField] private Tile startTile;

    [SerializeField] private Transform player;

    [SerializeField] private int safeDistance = 5;

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

    // TODO remove comment block below after fixing the position logic for new tiles
    /*
       position.z för den nya tilen skall vara förraTilen.position.z + förra tilens längd.
       this.transform.position = new Vector3(0f, 0f, previousTile.position.z + previousTile.length);
     */

    void SpawnTiles()
    {
        Tile tile;
        // Spawn a new tile if the player is sufficiently far
        if(player.position.z + safeDistance > lastSpawnedTile.transform.position.z + lastSpawnedTile.Length)
        {
            Tile t = tilePrefabs[Random.Range(0, tilePrefabs.Length)].GetPooledInstance<Tile>();
            t.transform.position = this.transform.position + new Vector3(0f, 0f, lastSpawnedTile.Length);

            lastSpawnedTile = t;
        }

    }

}
