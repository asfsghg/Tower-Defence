using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private Transform SpawnPrefab;
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private GameObject Enemy4;

    private Coroutine currentWave;

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        // Волна 1
        currentWave = StartCoroutine(Wave1());
        yield return new WaitForSeconds(20f);
        StopCoroutine(currentWave);

        // Волна 2
        currentWave = StartCoroutine(Wave2());
        yield return new WaitForSeconds(30f);
        StopCoroutine(currentWave);

        // Волна 3
        currentWave = StartCoroutine(Wave3());
        yield return new WaitForSeconds(50f);
        StopCoroutine(currentWave);

        // Волна 4 (один раз)
        Wave4();
    }

    IEnumerator Wave1()
    {
        while (true)
        {
            Instantiate(Enemy1, SpawnPrefab.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator Wave2()
    {
        while (true)
        {
            Instantiate(Enemy2, SpawnPrefab.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator Wave3()
    {
        while (true)
        {
            Instantiate(Enemy3, SpawnPrefab.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    private void Wave4()
    {
        Instantiate(Enemy4, SpawnPrefab.position, Quaternion.identity);
    }
}

