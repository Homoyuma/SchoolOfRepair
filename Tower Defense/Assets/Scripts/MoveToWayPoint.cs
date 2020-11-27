using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToWayPoint : MonoBehaviour
{
    public float Speed;
    public Transform[] waypoints;
    int curWaypointIndex = 0;


    public float startHealth = 100;
    private float health;

    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        MobSpawn.enemiesAlive--;
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        MobSpawn.enemiesAlive--;
        Destroy(gameObject);
    }

    void Update()
    {
        if (curWaypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * Speed);
            //transform.LookAt(waypoints[curWaypointIndex].position);
            if (Vector2.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f)
            {
                curWaypointIndex++;
            }
        }
        else {
            EndPath();
        }
    }
}
