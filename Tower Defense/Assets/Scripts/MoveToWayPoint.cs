using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    
    public static int score;
    public static int record = 0;

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
            record = PlayerPrefs.GetInt("savescores"); 
            score++;
            if (score>record) {
                PlayerPrefs.SetInt("savescores", score);
                PlayerPrefs.Save();
            }
            Debug.Log(gameObject);
        }
    }
}
