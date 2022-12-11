using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objectPool;
    public GameObject prefab;
    public List<GameObject> pooledObjects;
    public int initialCount = 20;

    private void Awake()
    {
        if (objectPool == null)
        {
            objectPool = this;
            pooledObjects = new List<GameObject>();
        }

        instantiateObjects(initialCount);
    }

    private void instantiateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.SetActive(false);
            pooledObjects.Add(gameObject);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        instantiateObjects(pooledObjects.Count / 2);
        return pooledObjects[pooledObjects.Count - 1];
    }

}
