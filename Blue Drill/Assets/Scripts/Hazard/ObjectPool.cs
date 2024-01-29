using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public int poolSize = 10;
    public float spawnTimer = 12f;
    
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
            pool[i] = Instantiate(enemy,this.transform);
            pool[i].SetActive(false);
        }
    }
    
}
