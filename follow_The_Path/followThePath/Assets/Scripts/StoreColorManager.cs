using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreColorManager : MonoBehaviour
{
    public ColorManager colorManager;

    public static StoreColorManager ColorInstance { get; private set; }

    private void Awake()
    {
        if (ColorInstance == null)
        {
            ColorInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //colorManager.
    }

}
