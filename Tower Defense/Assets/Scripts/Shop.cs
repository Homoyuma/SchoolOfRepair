using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint FireTower;
    public TowerBlueprint WaterTower;

    public void SelectFireTower()
    {
        TowerPlace.instance.SelectTowerToBuild(FireTower);
    }
    public void SelectWaterTower()
    {
        TowerPlace.instance.SelectTowerToBuild(WaterTower);
    }
}