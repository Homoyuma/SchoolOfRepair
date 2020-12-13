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
    private TowerPlace selectedTower;

    public TowerUI towerUI;
    public bool CanBuild { get { return towerToBuild != null;  } }

    public void SelectTower(TowerPlace sTower)
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

    void OnMouseDown()
    {
        if (!CanBuild)
            return;
        Vector3 offset = new Vector3(0, 0.30f, 0f);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        
        Vector3Int cellPosition = tilemap.WorldToCell(pz);
        foreach (Tile tile in tiles)
        {
            if (tile.position != cellPosition)
            {
                continue;
            }
            if(tile.empty)
            {
                if (PlayerStats.Gold < towerToBuild.cost)
                {
                    Debug.Log("Not enough money");
                    return;
                }
                PlayerStats.Gold -= towerToBuild.cost;

                tile.tower = Instantiate(towerToBuild.prefab, tilemap.CellToWorld(tile.position) + offset, Quaternion.identity);
                tile.empty = false;
                Debug.Log("Money left: " + PlayerStats.Gold);
            }
            else
            {
                SelectTower(this);
            }
        }
    }
}