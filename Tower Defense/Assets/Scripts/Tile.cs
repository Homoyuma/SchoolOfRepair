using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public bool empty = true;
    public GameObject tower;
    public Vector3Int position;
    public Tile(Vector3Int _position)
    {
        position = _position;
    }
}
