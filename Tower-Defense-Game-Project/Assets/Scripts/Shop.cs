using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] BuildManager buildManager;

    private void Start() {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandartTurret() // Can be reused to create another turret purchase method (Just copy-paste it)
    {
        Debug.Log("Standart Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }

    public void PurchaseMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.SetTurretToBuild(buildManager.missleLauncherPrefab);
    }
}
