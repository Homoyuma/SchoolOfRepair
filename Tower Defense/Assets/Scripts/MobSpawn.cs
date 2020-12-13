﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobSpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float countdown = 2f;
    public float timeBetweenWaves;
    private int waveIndex = 0;
    
    public Transform spawnPoint;
    public Transform[] WayPoints;
    public static int enemyCount = 0;
    public static int enemiesAlive = 0;
    public int MobCount;
    public manager mng;

    void Start()
    {

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
            if (enemiesAlive == 0 && enemyCount == MobCount && PlayerStats.Lives > 0)
             {
                 mng.WinLevel();
             }
        }
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            if (enemyCount != MobCount) 
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
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
