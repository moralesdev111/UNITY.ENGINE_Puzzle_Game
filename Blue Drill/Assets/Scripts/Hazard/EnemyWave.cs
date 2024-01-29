using System.Collections;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;
    public bool canSpawn = true;


    void Start()
    {
        StartCoroutine(SpawnOneWave());
    }

    void Update()
    {
        // You can add other update logic here if needed
    }

    private IEnumerator SpawnOneWave()
{
    while (true)
    {
        while (!canSpawn)
        {
            // Wait until canSpawn is true before attempting to spawn
            yield return null;
        }

        int numberOfEnemiesToActivate = WaveSize();

        for (int i = 0; i < numberOfEnemiesToActivate; i++)
        {
            int randomIndex = Random.Range(0, objectPool.poolSize);
            if (!objectPool.pool[randomIndex].activeInHierarchy)
            {
                objectPool.pool[randomIndex].SetActive(true);
            }
        }

        // Wait for the specified time before starting a new wave
        yield return new WaitForSeconds(objectPool.spawnTimer);
    }
}




    private int WaveSize()
    {
        return Random.Range(1, objectPool.poolSize + 1);
    }
}
