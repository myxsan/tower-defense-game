using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;
    public GameObject standartTurretPrefab;
    public GameObject missleLauncherPrefab;

    
    private void Awake() {
        instance = this;
    }

    private void Start() {
        turretToBuild = standartTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
