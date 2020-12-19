using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToWayPoint : MonoBehaviour
{
    public float startSpeed = 1f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    public int worth = 30;

    public float health;

    public Image healthBar;
    public bool dead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        if (!dead)
        {
            dead = true;
            PlayerStats.Gold += worth;
            MobSpawn.enemiesAlive--;
            Destroy(gameObject);
            Debug.Log(gameObject);
        }
    }

    
}
