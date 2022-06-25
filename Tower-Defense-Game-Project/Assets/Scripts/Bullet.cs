using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactVFX;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }

    private void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactVFX, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}
