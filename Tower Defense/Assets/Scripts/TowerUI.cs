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

        Vector3 offset = new Vector3(0.2f, -0.5f, 0f);
        transform.position = towerPlace.GetBuildPosition() + offset;

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
}
