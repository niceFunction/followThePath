using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TileManager : MonoBehaviour
{

    public Tile[] tilePrefabs;


    private int tilesToRemove = 3; // TODO remove this, it is unused and unecessary.

    [SerializeField] private Tile startTile;

    [SerializeField] private Transform player;
    /*
    // Serialized private fields, because we don't want other objects to access these
    [SerializeField] private GameObject[] leftTilePrefabs;
    [SerializeField] private GameObject[] midTilePrefabs;
    [SerializeField] private GameObject[] rightTilePrefabs;
    */
    // TODO remove out-commented code above and below
    //Q: Can I use this instead of "length" in "t.transform.position" in "Tile.cs"
    //   If I'm supposed to move that piece of code here?
    //[SerializeField] private float tileLength = 20f;
    [SerializeField] private float length = 20f; // TODO remove this, TileManager should not know the length of a tile.
    [SerializeField] private int tilesToSpawn = 2;


    public float Length { get { return length; } }

    private Tile lastSpawnedTile;
   // private Tile previousTile; //Q: Do I really need this or can I just use "lastSpawnedTile"?
   // TODO remove comment above. 

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
        // TODO move the code block below to into the "if" statement, because we only want this if we should spawn a tile.
        //Q: If you're related to Object Pooling, when are you supposed to be like this or not?
        Tile prefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
        Tile spawn = prefab.GetPooledInstance<Tile>();
        Tile t = // TODO remove this line, it is unecessary. the new tile is already stored as "spawn"
            // TODO the whole block above could be rewritten as: Tile t = tilePrefabs[Random.Range(0, tilePrefabs.Length)].GetPooledInstance<Tile>();


        //Tile previousTile;
        // Spawn a new tile if the player is sufficiently far
        if (player.position.z + (tilesToSpawn * length) > lastSpawnedTile.transform.position.z)
        {
            // TODO remove comment and out-commented code below, it is unecessary to save.
            //Q: If I'm going to spawn stuff, why are you here?
            //lastSpawnedTile = lastSpawnedTile.SpawnNext();
            t.transform.position = this.transform.position + new Vector3(0f, 0f, lastSpawnedTile.Length);

            lastSpawnedTile = t;
        }

    }

}
