using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A very simple Pool.
/// It is a singleton.
/// It works only if all prefabs have different names and the objects from here are never renamed.
/// </summary>
public class TilePool : MonoBehaviour
{
    // TODO rewrite to not be a Singleton.
    private static TilePool instance;

    // This dictionary contains Queues for all object, prefab name being the key to access them
    private Dictionary<string, Queue<Tile>> pool = new Dictionary<string, Queue<Tile>>();

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Takes an object from the Pool based on prefab
    /// </summary>
    /// <param name="prefabName"></param>
    /// <returns>A Tile</returns>
    public static Tile GetFromPool(GameObject prefab)
    {
        // Get the right queue from the Pool
        Queue<Tile> queue = instance.GetQueue(prefab.name);

        Tile tile;
        // Dequeue an object, if the queue is not empty.
        if (queue.Count > 0)
        {
            
            tile = queue.Dequeue();
        }
        // Create a new object, the queue was empty.
        else
        {
            tile = instance.GetNewTile(prefab);
        }

        // Set the game object to be active in the scene.
        tile.gameObject.SetActive(true);
        return tile;
    }

    /// <summary>
    /// Retrieves a Queue from the Pool based on name.
    /// Adds a new Queue to the Pool with that key if it does not already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>The specific Queue from the Pool with the given key</returns>
    private Queue<Tile> GetQueue(string key)
    {
        Queue<Tile> queue = null;
        if (instance.pool.TryGetValue(key, out queue))
        {
            return queue;
        }
        else
        {
            queue = new Queue<Tile>();
            pool.Add(key, queue);
            return queue;
        }
    }

    /// <summary>
    /// Creates a new Tile based on the prefab.
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns>A newly instantiated Tile</returns>
    private Tile GetNewTile(GameObject prefab)
    {
        // Instantiate a new Tile from the prefab.
        Tile t = Instantiate(prefab).GetComponent<Tile>();
        // Set the name to be the same as the prefab, 
        // we need this for the Queue to work since "name" is the key to the right Queue in the pool.
        t.name = prefab.name;
        // Move the game object to be under the TilePool object in the Editor.
        t.transform.parent = this.transform;

        return t;
    }

    /// <summary>
    /// Adds on object to the Pool based on name
    /// </summary>
    /// <param name="tile">Tile to add to the Pool</param>
    public static void AddToPool(Tile tile)
    {
        // Disable the game object to be inactive in the scene
        tile.gameObject.SetActive(false);

        // Get the right queue from the Pool
        Queue<Tile> queue = instance.GetQueue(tile.name);

        // Add the tile to the queue again
        queue.Enqueue(tile);
    }
}
