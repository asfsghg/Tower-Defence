using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    [SerializeField] private int Wave1Time;
    [SerializeField] private int Wave2Time;
    [SerializeField] private int Wave3Time;
    
    [SerializeField] private int SpawnTime1;
    [SerializeField] private int SpawnTime2;
    [SerializeField] private int SpawnTime3;
    
    [SerializeField] private Transform SpawnPrefab;
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private GameObject Enemy4;

    [SerializeField] private musicWL musicPlayer;

    private Coroutine currentWave;

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        currentWave = StartCoroutine(Wave1());
        yield return new WaitForSeconds(Wave1Time);
        StopCoroutine(currentWave);
        
        currentWave = StartCoroutine(Wave2());
        yield return new WaitForSeconds(Wave2Time);
        StopCoroutine(currentWave);
        
        currentWave = StartCoroutine(Wave3());
        yield return new WaitForSeconds(Wave3Time);
        StopCoroutine(currentWave);
        
        currentWave = StartCoroutine(Wave4());
    }

    IEnumerator Wave1()
    {
        while (true)
        {
            Instantiate(Enemy1, SpawnPrefab.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime1);
        }
    }

    IEnumerator Wave2()
    {
        while (true)
        {
            Instantiate(Enemy2, SpawnPrefab.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime2);
        }
    }

    IEnumerator Wave3()
    {
        while (true)
        {
            Instantiate(Enemy3, SpawnPrefab.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime3);
        }
    }


    IEnumerator Wave4()
    {
        GameObject enemy = Instantiate(Enemy4, SpawnPrefab.position, Quaternion.identity);

        yield return new WaitUntil(() => enemy == null);
        MenuManager.NextGame++;
        winPanel.SetActive(true);
        Time.timeScale = 0.1f;
        musicPlayer.PlayVictoryMusic();
        
    }
}

