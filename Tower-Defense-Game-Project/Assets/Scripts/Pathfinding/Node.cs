using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turretPrefab;
    public Vector3 turretPositionOffset;

    [Header("Optional")]
    public GameObject turret;
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
        if(!buildManager.CanBuild) return;

        if(turret != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(!buildManager.CanBuild) return;
        
        rend.material.color = hoverColor;    
    }

    private void OnMouseExit() 
    {
        rend.material.color = startColor;    
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + turretPositionOffset;
    }
}
