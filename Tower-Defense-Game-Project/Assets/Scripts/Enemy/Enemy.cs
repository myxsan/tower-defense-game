using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

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

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }


        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
