using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missleLauncher;

    private BuildManager buildManager;

    private void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTurret() // Can be reused to create another turret purchase method (Just copy-paste it)
    {
        Debug.Log("Standart Turret Selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
}
