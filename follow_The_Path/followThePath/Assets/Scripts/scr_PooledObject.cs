using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PooledObject : MonoBehaviour
{
    public scr_ObjectPool Pool { get; set; }

    public void ReturnToPool()
    {
        if(Pool)
        {
            Pool.AddObject(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
/*
 catlikecoding.com/unity/tutorials/object-pools/
 www.youtube.com/watch?v=tdSmKaJvCoA
 */
