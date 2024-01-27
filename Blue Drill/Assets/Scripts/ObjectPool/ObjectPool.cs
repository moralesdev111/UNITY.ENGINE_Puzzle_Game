using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject avalancheObjectPrefab;
    public int poolSize = 5;
    [SerializeField] Transform spawnPosition;
    public GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(avalancheObjectPrefab,spawnPosition);
            pool[i].SetActive(false);
        }
    }
}
