using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public int WaveSize;
    public GameObject EnemyPrefab;
    public float EnemyInterval;
    public Transform spawnPoint;
    public float startTime;
    public Transform[] WayPoints;
    public string gateTag;
    public static int enemyCount = 0;
    public static int enemiesAlive = 0;
    public manager mng;

    void Start()
    {
        
        InvokeRepeating("SpawnEnemy", startTime, EnemyInterval);
    }

    void Update()
    {
        if (enemyCount == WaveSize)
        {
            CancelInvoke("SpawnEnemy");

        }
        if (enemiesAlive == 0 && enemyCount == 10 && PlayerStats.Lives > 0)
        {
            mng.WinLevel();
        }
    }

    void SpawnEnemy()
    {
        enemyCount++;
        enemiesAlive++;
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<MoveToWayPoint>().waypoints = WayPoints;
    }
}
