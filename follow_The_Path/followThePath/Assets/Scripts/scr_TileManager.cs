using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TileManager : MonoBehaviour
{

    private int tilesToRemove = 3;

    [SerializeField] private Tile startTile;

    // Serialized private fields, because we don't want other objects to access these
    [SerializeField] private GameObject[] leftTilePrefabs;
    [SerializeField] private GameObject[] midTilePrefabs;
    [SerializeField] private GameObject[] rightTilePrefabs;

    [SerializeField] private float tileLength = 20f;
    [SerializeField] private int tilesToSpawn = 20;

    

    // Start is called before the first frame update
    void Start()
    {
        // if(the number of Tiles are less than tilesToSpawn) {
        Tile tile = startTile;
        for (int i = 0; i < tilesToSpawn; i++)
        {
            tile = tile.SpawnNext();
        }
        /*
         else if (triggerTileRemoval has happend in "scr_CountTiles")
         {
            remove previous tiles with "tilesToRemove"
         }
         add new random Tiles
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
