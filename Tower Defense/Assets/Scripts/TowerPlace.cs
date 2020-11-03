using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlace : MonoBehaviour
{
    public GameObject Tower;
    public GameObject curTower;
    public bool empty = true;
    public Tilemap tilemap;
    public bool[,] tileFill;
    public List<Tile> tiles;
    
    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(position))
            {
                continue;
            }
        }
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

    void OnMouseDown()
    {
        Vector3 offset = new Vector3(0, 0.30f, 0f);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        
        Vector3Int cellPosition = tilemap.WorldToCell(pz);
        foreach (Tile tile in tiles)
        {
            if(tile.position != cellPosition)
            {
                continue;
            }
            if(tile.empty)
            {
                tile.tower = Instantiate(Tower, tilemap.CellToWorld(tile.position)+offset,Quaternion.identity);
                tile.empty = false;
            }
            else
            {
                Destroy(tile.tower);
                tile.empty = true;
            }
        }
    }
}