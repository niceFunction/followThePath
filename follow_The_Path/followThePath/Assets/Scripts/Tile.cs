using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tile is responsible where it will end up
/// </summary>
/// <param name="Tile"></param>
public class Tile : scr_PooledObject
{
    
    [SerializeField] private Tile[] connectsTo;

    public Tile[] ConnectsTo { get { return connectsTo; } }

    // Private field that only instances of Tile is allowed to access and change
    [SerializeField] private float length; 
    // Public property will allow other objects to read the length of a Tile
    public float Length { get { return length; } } 

    /// <summary>
    /// SetPositionAfter responsible for the tiles positioning after the previous tile
    /// </summary>
    /// <param name="newTile"></param>
    public void SetPositionAfter(Tile previousTile)
    {
        Vector3 newPos = new Vector3(0f, 0f, previousTile.transform.position.z + this.Length);
        this.transform.position = newPos;
    }

}
