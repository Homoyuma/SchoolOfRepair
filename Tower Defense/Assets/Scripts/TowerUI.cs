using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public GameObject ui;
    private Tower target;
    [SerializeField]
    private TowerPlace towerPlace;

    public void SetTarget(Tower _target)
    {
        target = _target;

        Vector3 offset = new Vector3(4, -2, 0f);
        transform.position =  offset;

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeT()
    {
        towerPlace.UpgradeTower(target);
        TowerPlace.instance.DeselectTower();
    }

    public void SellT()
    {
        towerPlace.SellTower(target);
        TowerPlace.instance.DeselectTower();
    }
}
