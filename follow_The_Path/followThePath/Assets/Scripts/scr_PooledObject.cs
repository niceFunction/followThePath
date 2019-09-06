using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PooledObject : MonoBehaviour
{
    public scr_ObjectPool Pool { get; set; }

    [System.NonSerialized]
    scr_ObjectPool poolInstanceForPrefab;

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
    public T GetPooledInstance<T>() where T : scr_PooledObject
    {
        if (!poolInstanceForPrefab)
        {
            poolInstanceForPrefab = scr_ObjectPool.GetPool(this);
        }
        return (T)poolInstanceForPrefab.GetObject();
    }
}

// TODO put this comment block at the top, to better inform where this code has been taken from/inspired by.
/*
Cat Like Coding:
    catlikecoding.com/unity/tutorials/object-pools/
 
Brackeys - Object Pooling:   
    www.youtube.com/watch?v=tdSmKaJvCoA
 */
