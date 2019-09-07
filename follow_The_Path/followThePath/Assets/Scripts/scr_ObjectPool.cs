using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Cat Like Coding:
    catlikecoding.com/unity/tutorials/object-pools/
 
Brackeys - Object Pooling:   
    www.youtube.com/watch?v=tdSmKaJvCoA
 */

public class scr_ObjectPool : MonoBehaviour
{
    scr_PooledObject prefab;
    List<scr_PooledObject> availableObjects = new List<scr_PooledObject>(); 
    public scr_PooledObject GetObject()
    {
        scr_PooledObject obj = Instantiate<scr_PooledObject>(prefab);
        int lastAvailableIndex = availableObjects.Count - 1;
        if (lastAvailableIndex >= 0)
        {
            obj = availableObjects[lastAvailableIndex];
            availableObjects.RemoveAt(lastAvailableIndex);
            obj.gameObject.SetActive(true);

        }
        else
        {
            obj = Instantiate<scr_PooledObject>(prefab);
            obj.transform.SetParent(transform, false);
            obj.Pool = this;

        }
        
        return obj;
    }

    public static scr_ObjectPool GetPool (scr_PooledObject prefab)
    {
        GameObject obj;
        scr_ObjectPool pool;
        if (Application.isEditor)
        {
            obj = GameObject.Find(prefab.name + " Pool");
            if (obj)
            {
                pool = obj.GetComponent<scr_ObjectPool>();
                if (pool)
                {
                    return pool;
                }
            }
        }

        obj = new GameObject(prefab.name + " Pool");
        pool = obj.AddComponent<scr_ObjectPool>();
        pool.prefab = prefab;
        return pool;
    }
    public void AddObject(scr_PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        availableObjects.Add(obj);
    }
}
