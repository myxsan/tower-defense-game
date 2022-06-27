using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    private void Start() 
    {
        target = Waypoints.waypoints[0];
        enemy = GetComponent<Enemy>();
    }

        private void Update() {
        Vector3 direction = Vector3.Normalize(target.position - transform.position);
        transform.Translate(direction * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
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
