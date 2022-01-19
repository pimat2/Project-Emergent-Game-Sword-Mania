using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefabs;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 10f;

    private float countdown = 10f;

    //public Text waveCountdownText;

    private int waveNumber = 0;

    //public Text currentWave;

     void Update()
    {
        if(countdown <= 0f)
        {
            
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //waveCountdownText.text = string.Format("{0:00.0}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
       // currentWave.text = PlayerStats.Rounds.ToString();
        PlayerStats.Rounds++;
        for (int i = 0; i < waveNumber; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);

        }
    }
    
    void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[Random.Range(0, 3)], spawnPoints[Random.Range(0,2)].position, spawnPoints[Random.Range(0,2)].rotation);
    }

}
