using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Awake() {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandartTurret() // Can be reused to create another turret purchase method (Just copy-paste it)
    {
        Debug.Log("Standart Turret Select");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }
}
