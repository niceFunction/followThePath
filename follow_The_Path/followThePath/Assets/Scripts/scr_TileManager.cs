using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TileManager : MonoBehaviour
{

    public Tile[] tilePrefabs;


    private int tilesToRemove = 3;

    [SerializeField] private Tile startTile;

    [SerializeField] private Transform player;
    /*
    // Serialized private fields, because we don't want other objects to access these
    [SerializeField] private GameObject[] leftTilePrefabs;
    [SerializeField] private GameObject[] midTilePrefabs;
    [SerializeField] private GameObject[] rightTilePrefabs;
    */

    //Q: Can I use this instead of "length" in "t.transform.position" in "Tile.cs"
    //   If I'm supposed to move that piece of code here?
    //[SerializeField] private float tileLength = 20f;
    [SerializeField] private float length = 20f;
    [SerializeField] private int tilesToSpawn = 2;


    public float Length { get { return length; } }

    private Tile lastSpawnedTile;
   // private Tile previousTile; //Q: Do I really need this or can I just use "lastSpawnedTile"?

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

    /*
       position.z för den nya tilen skall vara förraTilen.position.z + förra tilens längd.
       this.transform.position = new Vector3(0f, 0f, previousTile.position.z + previousTile.length);
     */

    void SpawnTiles()
    {
        //Q: If you're related to Object Pooling, when are you supposed to be like this or not?
        Tile prefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
        Tile spawn = prefab.GetPooledInstance<Tile>();
        Tile t = 
        
        //Tile previousTile;
        // Spawn a new tile if the player is sufficiently far
        if (player.position.z + (tilesToSpawn * length) > lastSpawnedTile.transform.position.z)
        {
            
            //Q: If I'm going to spawn stuff, why are you here?
            //lastSpawnedTile = lastSpawnedTile.SpawnNext();
            t.transform.position = this.transform.position + new Vector3(0f, 0f, lastSpawnedTile.Length);

            lastSpawnedTile = t;
        }

    }

}
