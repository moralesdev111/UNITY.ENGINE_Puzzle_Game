using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheSettings : MonoBehaviour, IRandomNumberGenerateable
{
    [SerializeField] ObjectPool objectPool;
   

    void Start()
    {
        EnablePool();
    }

    void Update()
    {
        
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(0,objectPool.poolSize + 1);
       
    }
    public void EnablePool()
    {
        int randomNumberGenerated = GenerateRandomNumber();
        for(int i = 0; i < objectPool.pool.Length; i++)
        {
            objectPool.pool[i].SetActive(i <randomNumberGenerated);
        }
    }
}
