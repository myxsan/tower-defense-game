using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int value = 50;
    public GameObject deathVFX;

    private Transform target;
    private int waypointIndex = 0;
    private void Start() {
        target = Waypoints.waypoints[0];
    }

    
    private void Update() {
        Vector3 direction = Vector3.Normalize(target.position - transform.position);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += value;
        
        GameObject vfxIns = (GameObject)Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(vfxIns, 5f);

        Destroy(gameObject);
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }


        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
