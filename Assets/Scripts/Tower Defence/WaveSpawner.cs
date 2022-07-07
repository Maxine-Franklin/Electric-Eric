using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float workersPerSecond = 0.05f; //Workers spawning every second
    private float workersToSpawn = 0; //Tracker for when a worker should be spawned
    public float workerIncreasePerSecond = 0.05f; //Increase in spawn rates of workers over time
    public float workerIncreaseAcceleration = 0.001f; //Increases the increase rate of workers over time

    public float timeBetweenWaves = 5;
    public float currentSpeed = 10f;
    private float countdown = 2f;
    private int waveNumber = 0;

    void Start()
    {
        currentSpeed = 15f;
    }

    private void FixedUpdate()
    {
        workersToSpawn += workersPerSecond * Time.deltaTime;
        while (workersToSpawn > 1)
        {
            workersToSpawn -= 1;
            SpawnEnemy();
        }
        workersPerSecond += workerIncreasePerSecond * Time.deltaTime;
        workerIncreasePerSecond += workerIncreaseAcceleration * Time.deltaTime;
    }

    /*void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        //Currently spawns 2 enemys on wave 2 and more on 3 ect
            waveNumber++;
            currentSpeed++;
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
    }*/

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
