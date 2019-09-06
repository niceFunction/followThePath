using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO Remove this class.
 * it is unused, is a complex solution for a simple problem.
 */
public class scr_CountTiles : MonoBehaviour
{

    private int removalCounter = 0;
    private int triggerTileRemoval = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (removalCounter >= triggerTileRemoval)
        {
            // Trigger removal of Tiles here
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            // When the Player has Collided with the GameObject called "tileGate"
            // increment removalCounter by 1 ONCE upon collision 
            removalCounter += 1;
        }
        /*
         else if (removalCounter == triggerTileRemoval
         {
            remove tiles in "scr_TileManager"
         }
        */
    }
}
