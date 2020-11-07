using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void PurchaseFireTower()
    {
        Debug.Log("Fire Tower");
        TowerPlace.instance.SetTowerToBuild(TowerPlace.instance.FireTowerPrefab);
    }
    public void PurchaseWaterTower()
    {
        Debug.Log("Water Tower");
        TowerPlace.instance.SetTowerToBuild(TowerPlace.instance.WaterTowerPrefab);
    }
}