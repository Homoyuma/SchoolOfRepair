using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void PurchaseFireTower()
    {
        TowerPlace.instance.SetTowerToBuild(TowerPlace.instance.FireTowerPrefab);
    }
    public void PurchaseWaterTower()
    {
        TowerPlace.instance.SetTowerToBuild(TowerPlace.instance.WaterTowerPrefab);
    }
}