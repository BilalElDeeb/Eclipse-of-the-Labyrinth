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

    List<Vector2Int> FetchDoorPostions(DoorPositions doorPositions, int doorSize)
    {
        List<Vector2Int> doorPositionsList = new List<Vector2Int>();
        int halfDoorSize = doorSize / 2;
        
        if (doorPositions.hasFlag(DoorPositions.North))
        {
            for (int i = (roomWidth/2) - halfDoorSize; i < (roomWidth/2) + halfDoorSize; i++)
            {
                doorPositionsList.Add(new Vector2Int(i, roomHeight - 1));
            }
        }
        
        if (doorPositions.hasFlag(DoorPositions.South))
        {
            for (int i = (roomWidth/2) - halfDoorSize; i < (roomWidth/2) + halfDoorSize; i++)
            {
                doorPositionsList.Add(new Vector2Int(i, 0));
            }
        }
        
        if (doorPositions.hasFlag(DoorPositions.East))
        {
            for (int i = (roomHeight/2) - halfDoorSize; i < (roomHeight/2) + halfDoorSize; i++)
            {
                doorPositionsList.Add(new Vector2Int(roomWidth - 1, i));
            }
        }
        
        if (doorPositions.hasFlag(DoorPositions.West))
        {
            for (int i = (roomHeight/2) - halfDoorSize; i < (roomHeight/2) + halfDoorSize; i++)
            {
                doorPositionsList.Add(new Vector2Int(0, i));
            }
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

    public void CreateDoorPositions(DoorPositions doorPositions, int doorSize)
    {
        SetDoorPositions(FetchDoorPostions(doorPositions, doorSize));
    }
    // Start is called before the first frame update
    void Start() 
    {
        
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