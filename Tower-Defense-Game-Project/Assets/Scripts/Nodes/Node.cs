using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public GameObject turretPrefab;
    public Vector3 turretPositionOffset;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;
    private BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    private void Start() {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost) return;

        PlayerStats.Money -= blueprint.cost;
        Debug.Log(PlayerStats.Money);

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        GameObject vfxIns = (GameObject)Instantiate(buildManager.buildVFX, GetBuildPosition(), Quaternion.identity);
        Destroy(vfxIns, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost) return;

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret); // destroy old turret

        // instantiate an upgraded one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject vfxIns = (GameObject)Instantiate(buildManager.buildVFX, GetBuildPosition(), Quaternion.identity);
        Destroy(vfxIns, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject vfxIns = (GameObject)Instantiate(buildManager.sellVFX, GetBuildPosition(), Quaternion.identity);
        Destroy(vfxIns, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(turret != null)
        {
            buildManager.SelecteNode(this);
            return;
        }


        if(!buildManager.CanBuild) return;


        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(!buildManager.CanBuild) return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;    
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
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
