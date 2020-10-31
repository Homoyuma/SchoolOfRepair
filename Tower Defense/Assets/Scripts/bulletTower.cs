using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTower : MonoBehaviour
{
    public float speed;
    public Transform target;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime*speed);
    }
}
