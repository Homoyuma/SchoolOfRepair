using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTower : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    public int damage = 50;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(target);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(Transform enemy)
    {
        MoveToWayPoint e = enemy.GetComponent<MoveToWayPoint>();
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
