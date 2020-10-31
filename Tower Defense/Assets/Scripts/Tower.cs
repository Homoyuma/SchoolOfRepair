using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform shootElem;
    public float dmg = 10;
    public GameObject bullet;
    public Transform target;
    public float shootDelay;
    bool isShoot;
    
    void Update()
    {
        if (target)
        {
            if (!isShoot)
            {
                StartCoroutine(shoot());
            }
        }
    }
    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootDelay);
        GameObject b = GameObject.Instantiate(bullet, shootElem.position, Quaternion.identity) as GameObject;
        b.GetComponent<bulletTower>().target = target;
        isShoot = false;
    }
}
