using System.Collections.Generic;
using UnityEngine;

namespace Hades
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public ObjectPool[] ObjectPools;

        private readonly Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();
        private readonly Dictionary<string, List<GameObject>> objectPoolDict = new Dictionary<string, List<GameObject>>();
        private readonly Dictionary<GameObject, string> pooledObjectDict = new Dictionary<GameObject, string>();

        public static ObjectPoolManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Preload();
        }

        public void Add(ObjectPool objectPool)
        {
            if (objectPool == null || string.IsNullOrEmpty(objectPool.Name) || objectPool.Prefab == null || objectPool.Amount == 0) return;

            if (!objectPoolDict.ContainsKey(objectPool.Name))
            {
                objectPoolDict[objectPool.Name] = new List<GameObject>();
            }

            Add(objectPool.Name, objectPool.Prefab, objectPool.Amount);
        }

        public void Add(string name, GameObject prefab, int amount)
        {
            for (int j = 0; j < amount; j++)
            {
                GameObject pooledObject = Instantiate(prefab, transform);
                pooledObject.SetActive(false);
                objectPoolDict[name].Add(pooledObject);
            }
        }

        public GameObject Get(string name, Transform parent = null)
        {
            if (!objectPoolDict.ContainsKey(name)) return null;

            if (objectPoolDict[name].Count == 0)
            {
                Add(name, prefabDict[name], 1);
            }

            GameObject pooledObject = objectPoolDict[name][0];
            objectPoolDict[name].Remove(pooledObject);
            pooledObjectDict[pooledObject] = name;
            pooledObject.transform.parent = parent;
            pooledObject.SetActive(true);
            return pooledObject;
        }

        public void Return(GameObject pooledObject)
        {
            if (!pooledObjectDict.ContainsKey(pooledObject)) return;

            string name = pooledObjectDict[pooledObject];
            objectPoolDict[name].Add(pooledObject);
            pooledObjectDict.Remove(pooledObject);
            pooledObject.transform.parent = transform;
            pooledObject.SetActive(false);
        }

        private void Preload()
        {
            for (int i = 0; i < ObjectPools.Length; i++)
            {
                ObjectPool objectPool = ObjectPools[i];
                prefabDict[objectPool.Name] = objectPool.Prefab;
                Add(objectPool);
            }
        }
    }
}