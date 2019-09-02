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

    public void AddObject (scr_PooledObject o)
    {
        Object.Destroy(o.gameObject);
    }
}
/*
 catlikecoding.com/unity/tutorials/object-pools/
 www.youtube.com/watch?v=tdSmKaJvCoA
 */
