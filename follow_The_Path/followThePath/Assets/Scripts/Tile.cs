using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : scr_PooledObject
{
    // Cohesion: The function and variables in a class relates closely to the purpose of that class.
    // Decoupling: Avoid intricate connections between objects, separate their concerns to do only their purpose.
    
    [SerializeField] private Tile[] connectsTo;

    // Private field that only instances of Tile is allowed to access and change
    [SerializeField] private float length; 
    // Public property will allow other objects to read the length of a Tile
    public float Length { get { return length; } } 

    public void PositionNewTile(Tile newTile)
    {
        newTile.transform.position = new Vector3(0f, 0f, newTile.transform.position.z + newTile.Length);
    }

}
