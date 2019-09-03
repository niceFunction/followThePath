using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ObjectPool : MonoBehaviour
{
    scr_PooledObject prefab;
    public scr_PooledObject GetObject()
    {
        scr_PooledObject obj = Instantiate<scr_PooledObject>(prefab);
        obj.transform.SetParent(transform, false);
        obj.Pool = this;
        return obj;
    }

    public void AddObject(scr_PooledObject o)
    {
        Object.Destroy(o.gameObject);
    }

    public static scr_ObjectPool GetPool (scr_PooledObject prefab)
    {
        GameObject obj = new GameObject(prefab.name + " Pool");
        scr_ObjectPool pool = obj.AddComponent<scr_ObjectPool>();
        pool.prefab = prefab;
        return pool;
    }

}
/*
Cat Like Coding:
    catlikecoding.com/unity/tutorials/object-pools/
 
Brackeys - Object Pooling:   
    www.youtube.com/watch?v=tdSmKaJvCoA
 */
