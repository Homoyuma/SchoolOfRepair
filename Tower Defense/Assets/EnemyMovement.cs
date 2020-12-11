using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveToWayPoint))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    int curWaypointIndex = 0;
    public Transform[] waypoints;
    Animator anim;
    private MoveToWayPoint enemy;

    private void Start()
    {
        enemy = GetComponent<MoveToWayPoint>();
        anim = GetComponent<Animator>();
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        MobSpawn.enemiesAlive--;
        Destroy(gameObject);
    }
    void Update()
    {
        if (curWaypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * enemy.speed);
            //transform.LookAt(waypoints[curWaypointIndex].position);
            if (Vector2.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f)
            {
                curWaypointIndex++;
                if (curWaypointIndex >= waypoints.Length)
                    return;
                if (waypoints[curWaypointIndex].position.x > waypoints[curWaypointIndex - 1].position.x
                        && waypoints[curWaypointIndex].position.y > waypoints[curWaypointIndex - 1].position.y)
                {
                    anim.SetInteger("Move", 0);
                }
                else if (waypoints[curWaypointIndex].position.x < waypoints[curWaypointIndex - 1].position.x
                    && waypoints[curWaypointIndex].position.y < waypoints[curWaypointIndex - 1].position.y)
                {
                    anim.SetInteger("Move", 1);
                }
                else if (waypoints[curWaypointIndex].position.x > waypoints[curWaypointIndex - 1].position.x
                    && waypoints[curWaypointIndex].position.y < waypoints[curWaypointIndex - 1].position.y)
                {
                    anim.SetInteger("Move", 0);
                }
                else if (waypoints[curWaypointIndex].position.x < waypoints[curWaypointIndex - 1].position.x
                    && waypoints[curWaypointIndex].position.y > waypoints[curWaypointIndex - 1].position.y)
                {
                    anim.SetInteger("Move", 1);
                }
            }
        }
        else
        {
            EndPath();
        }

        enemy.speed = enemy.startSpeed;
    }
}
