using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoint : MonoBehaviour
{
    public float Speed;
    public Transform[] waypoints;
    int curWaypointIndex = 0;

    public int health = 100;

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
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
