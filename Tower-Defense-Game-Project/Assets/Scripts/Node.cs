using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turretPrefab;
    public Vector3 turretPositionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretPositionOffset, transform.rotation);


        // turret = turretPrefab; 

        // Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        // Instantiate(turretPrefab, spawnPos, Quaternion.identity);

    }
    private void OnMouseEnter() 
    {
        rend.material.color = hoverColor;    
    }
    private void OnMouseExit() 
    {
        rend.material.color = startColor;    
    }
}
