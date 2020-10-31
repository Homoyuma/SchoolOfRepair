using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoint : MonoBehaviour
{
    public float Speed;
    public Transform[] waypoints;
    int curWaypointIndex = 0;

    void Suicide()
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
            Suicide();
        }
    }
}
