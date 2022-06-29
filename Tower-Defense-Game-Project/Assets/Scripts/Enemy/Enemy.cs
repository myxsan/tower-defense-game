using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float startHealth = 100;
    public float health;
    public int worth = 50;
    public GameObject deathVFX;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }

    private void Die()
    {
        PlayerStats.Money += worth;
        
        GameObject vfxIns = (GameObject)Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(vfxIns, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
