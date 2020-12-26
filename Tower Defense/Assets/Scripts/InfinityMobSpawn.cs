using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfinityMobSpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float countdown = 2f;
    public float timeBetweenWaves;
    private int waveIndex = 0;
    
    public Transform spawnPoint;
    public Transform[] WayPoints;
    public static int enemyCount = 0;
    public static int enemiesAlive = 0;
    public manager mng;

    void Start()
    {
        enemyCount = 0;
        MoveToWayPoint.score = 0; 
    }

    void Update()
    {
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;
        }
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        enemyCount++;
        enemiesAlive++;
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<EnemyMovement>().waypoints = WayPoints;
    }
}
