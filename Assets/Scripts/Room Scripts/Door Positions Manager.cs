using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorPositionsManager : MonoBehaviour
{
    public Tilemap wallTilemap;
    public Tilemap floorTilemap;
    public TileBase wallTile;
    public TileBase floorTile;
    public int roomHeight;
    public int roomWidth;
    public DoorPositions doorPositions;

    List<Vector2Int> FetchDoorPostions(DoorPositions doorPositions)
    {
        List<Vector2Int> doorPositionsList = new List<Vector2Int>();
        
        if (doorPositions.hasFlag(DoorPositions.North))
        {
            doorPositionsList.Add(new Vector2Int(roomWidth/2, roomHeight - 1));
            doorPositionsList.Add(new Vector2Int((roomWidth/2) - 1, roomHeight - 1));
        }
        
        if (doorPositions.hasFlag(DoorPositions.South))
        {
            doorPositionsList.Add(new Vector2Int(roomWidth/2, 0));
            doorPositionsList.Add(new Vector2Int((roomWidth/2) - 1, 0));
        }
        
        if (doorPositions.hasFlag(DoorPositions.East))
        {
            doorPositionsList.Add(new Vector2Int(roomWidth - 1, roomHeight/2));
            doorPositionsList.Add(new Vector2Int(roomWidth - 1,(roomHeight/2) - 1));
        }
        
        if (doorPositions.hasFlag(DoorPositions.West))
        {
            doorPositionsList.Add(new Vector2Int(0, roomHeight/2));
            doorPositionsList.Add(new Vector2Int(0, (roomHeight/2) - 1));
        }
        
        return doorPositionsList;
    }
    
    void SetDoorPositions(List<Vector2Int> doorPositionsList)
    {
        foreach (Vector2Int doorPosition in doorPositionsList)
        {
            wallTilemap.SetTile(new Vector3Int(doorPosition.x ,doorPosition.y ,0),null);
            floorTilemap.SetTile(new Vector3Int(doorPosition.x ,doorPosition.y,0), floorTile);
        }
    }
    // Start is called before the first frame update
    void Start() 
    {
        SetDoorPositions(FetchDoorPostions(doorPositions));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Flags]
public enum DoorPositions
{
    North = 1,
    South = 2,
    East  = 4,
    West  = 8
}