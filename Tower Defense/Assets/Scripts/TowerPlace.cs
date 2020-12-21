using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlace : MonoBehaviour
{
    public Tilemap tilemap;
    public bool[,] tileFill;
    public List<Tile> tiles;

    public static TowerPlace instance;
    private TowerBlueprint towerToBuild;
    private Tower selectedTower;

    [HideInInspector]
    public GameObject tower;
    public TowerBlueprint towerBlueprint;

    public TowerUI towerUI;
    public bool CanBuild { get { return towerToBuild != null;  } }

    public void SelectTower(Tower sTower)
    {
        if(selectedTower == sTower)
        {
            DeselectTower();
            return;
        }
        selectedTower = sTower;
        towerToBuild = null;

        towerUI.SetTarget(sTower);
    }

    public void DeselectTower()
    {
        selectedTower = null;
        towerUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;

        DeselectTower();
    }

    private void Start()
    {
        instance = this;
        tilemap = GetComponent<Tilemap>();
        
        FillArray();

    }

    private void FillArray()
    {
        tiles = new List<Tile>();
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(position))
            {
                continue;
            }
            tiles.Add(new Tile(position));
        }
    }

    public Vector3 GetBuildPosition()
    {
        Vector3 offset = new Vector3(0, 0.30f, 0f);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;

        Vector3Int cellPosition = tilemap.WorldToCell(pz);
        return tilemap.CellToWorld(cellPosition) + offset;
    }
    
    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;

        Vector3Int cellPosition = tilemap.WorldToCell(pz);
        foreach (Tile tile in tiles)
        {
            if (tile.position != cellPosition)
            {
                continue;
            }
            if (tile.empty)
            {
                if (PlayerStats.Gold < blueprint.cost)
                {
                    Debug.Log("Not enough money");
                    return;
                }
                PlayerStats.Gold -= blueprint.cost;

                tile.tower = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
                tile.empty = false;
                towerBlueprint = blueprint;
                Debug.Log("Money left: " + PlayerStats.Gold);
                Debug.Log("build"+GetBuildPosition());
            }
            else
            {
                SelectTower(tile.tower.GetComponent<Tower>());
            }
        }

    }

    public void UpgradeTower(Tower target)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(target.transform.position);
        foreach (Tile tile in tiles)
        {
            if (tile.position != cellPosition)
            {
                continue;
            }

            if (PlayerStats.Gold < towerBlueprint.upgradeCost)
            {
                Debug.Log("Not enough money");
                return;
            }

            if (tile.isUpgraded)
            {
                return;
            }

            Vector3 pos = target.transform.position;
            Destroy(target.gameObject);
            PlayerStats.Gold -= towerBlueprint.upgradeCost;
            tile.tower = Instantiate(towerBlueprint.upgradedPrefab, pos, Quaternion.identity);
            tile.isUpgraded = true;
            Debug.Log("Money left: " + PlayerStats.Gold);
        }
    }

    public void SellTower(Tower target)
    {
        int sellAmount = towerBlueprint.cost / 2;
        Vector3Int cellPosition = tilemap.WorldToCell(target.transform.position);
        foreach (Tile tile in tiles)
        {
            if (tile.position != cellPosition)
            {
                continue;
            }
            Destroy(target.gameObject);
            tile.empty = true;
            Debug.Log("Money left: " + PlayerStats.Gold);
            if (tile.isUpgraded)
            {
                sellAmount += towerBlueprint.upgradeCost/2;
            }
            PlayerStats.Gold += sellAmount;
            towerBlueprint = null;
            tile.isUpgraded = false;
        }
    }

    void OnMouseDown()
    {
        BuildTower(GetTowerToBuild());
    }

}