using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabToSpawn;      
    public Transform[] spawnPoints;       
    private int[] waveCounts = { 5, 10, 15, 20, 88 }; 
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < waveCounts.Length)
        {
            int count = waveCounts[currentWave];
            Debug.Log($"Волна {currentWave + 1} {count}");

            for (int i = 0; i < count; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
            }

            currentWave++;
            yield return new WaitForSeconds(40f);
        }

       
    }
}


