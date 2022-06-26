using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turretPrefab;
    public Vector3 turretPositionOffset;

    private GameObject turret;
    private BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    private void Start() {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(buildManager.GetTurretToBuild() == null) return;

        if(turret != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretPositionOffset, transform.rotation);

    }
    private void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(buildManager.GetTurretToBuild() == null) return;
        
        rend.material.color = hoverColor;    
    }
    private void OnMouseExit() 
    {
        rend.material.color = startColor;    
    }
}
