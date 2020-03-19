using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_PoolingManager : MonoBehaviour
{
    //Pooling
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static Gameplay_PoolingManager Instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {
        //if (!PoolDictionary.ContainsKey(tag))
        //{
        //    Debug.LogError("Pool does not contain that tag");
        //    return null;
        //}

        GameObject ojectToSpawn = PoolDictionary[tag].Dequeue();

        ojectToSpawn.SetActive(true);
        ojectToSpawn.transform.position = pos;
        ojectToSpawn.transform.rotation = rot;

        PoolDictionary[tag].Enqueue(ojectToSpawn);

        return ojectToSpawn;
    }
}
