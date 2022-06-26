using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;
    public GameObject standartTurretPrefab;

    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start() {
        turretToBuild = standartTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    
    {
        return turretToBuild;
    }
}
