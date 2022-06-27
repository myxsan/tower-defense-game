using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    public GameObject standartTurretPrefab;
    public GameObject missleLauncherPrefab;
    public GameObject buildVFX;
    
    private void Awake() {
        if(instance != null) return;

        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null;} }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;} }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost) return; // TODO: Not enaough money warning

        PlayerStats.Money -= turretToBuild.cost;
        Debug.Log(PlayerStats.Money);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject vfxIns = (GameObject)Instantiate(buildVFX, node.GetBuildPosition(), Quaternion.identity);
        Destroy(vfxIns, 5f);
    }
}
