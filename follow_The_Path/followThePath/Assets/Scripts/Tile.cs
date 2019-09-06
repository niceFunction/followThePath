using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : scr_PooledObject
{
    // TODO restore length into Tile, it is an attribute that is part of a tile, and no other object should have to store info on the length of a tile.
    // Cohesion: The function and variables in a class relates closely to the purpose of that class.
    // Decoupling: Avoid intricate connections between objects, separate their concerns to do only their purpose.
    //Q: Do I need you if I move the "t.transform.position" part of the code? 
    //   Because I already have a variable called "tileLength" in "scr_tileManager".
    //[SerializeField] private float length = 20f; 
    
    [SerializeField] private Tile[] connectsTo;

    // TODO create property to allow other objects to access "length"

    //private Tile previousTile;
    

    // TODO remove this method if it is not going to be used. Do not have duplicate logic in separate places. Either Tile spawns Tiles, or TileManager spawns them.
    public Tile SpawnNext()
    {

        Tile t = connectsTo[Random.Range(0, connectsTo.Length)];
        t = Instantiate(t.gameObject).GetComponent<Tile>();
       // t.transform.position = this.transform.position + new Vector3(0f, 0f, length);

        return t;
    }


}
