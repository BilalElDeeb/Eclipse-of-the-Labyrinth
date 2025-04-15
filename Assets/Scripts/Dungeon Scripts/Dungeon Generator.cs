using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonLayoutGenerator dungeonlayoutGenerator;
    public List<GameObject> roomVariants;
    public GameObject bossRoom;
    public int doorSize;
    // Start is called before the first frame update
    void Start()
    {
        List<Room> dungeonlayout = dungeonlayoutGenerator.CreateDungeonLayout();

        Vector2Int BossRoom = GetBossRoom(dungeonlayout.ToList());
        
        foreach (Room newRoom in dungeonlayout)
        {
            if (newRoom.position == BossRoom)
            {
                CreateRoom(newRoom, bossRoom);
            }
            else
            {
                int targetRoom = Random.Range(0, roomVariants.Count);
                CreateRoom(newRoom, roomVariants[targetRoom]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateRoom(Room newRoom, GameObject roomVariant)
    {
        int sortingOrderOffset = -100;
    
        
        GameObject room = Instantiate(roomVariant,new Vector3((newRoom.position.x * 22), 
            (newRoom.position.y * 10), 0), Quaternion.identity);
        room.GetComponent<DoorPositionsManager>().CreateDoorPositions(newRoom.doorPositions, doorSize);

        List<TilemapRenderer> TilemapRenderer = room.GetComponentsInChildren<TilemapRenderer>().ToList();

        foreach (TilemapRenderer tilemapRenderer in TilemapRenderer)
        {
            tilemapRenderer.sortingOrder += -(newRoom.position.y) + sortingOrderOffset;
        }
    }
    

    Vector2Int GetBossRoom(List<Room> rooms)
    {
        Dictionary<Vector2Int, int> minimumDistanceToRoom = new Dictionary<Vector2Int, int>();

        foreach (Room room in rooms)
        {
            minimumDistanceToRoom.Add(room.position, int.MaxValue);
        }
        
        Room startRoom = rooms[0];
        
        rooms.Remove(startRoom);
        TraverseDungeon(startRoom, rooms, 0, minimumDistanceToRoom);
        
        return minimumDistanceToRoom.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
    }

    void TraverseDungeon(Room currentRoom, List<Room> rooms, int distance, Dictionary<Vector2Int, int> minimumDistanceToRoom)
    {
        if (minimumDistanceToRoom[currentRoom.position] < distance)
        {
            minimumDistanceToRoom[currentRoom.position] = distance;
        }
        
        List<Room> adjacentRooms = getAdjacentRooms(currentRoom, rooms);

        if (adjacentRooms.Count == 0)
        {
            return;
        }
        else
        {
            foreach (Room adjacentRoom in adjacentRooms)
            {
                List<Room> roomsCopy = rooms.ToList();
                roomsCopy.Remove(adjacentRoom);
                TraverseDungeon(adjacentRoom, roomsCopy, distance + 1, minimumDistanceToRoom);
            }
        }
    }

    List<Room> getAdjacentRooms(Room currentRoom, List<Room> rooms)
    {
        List<Room> adjacentRooms = new List<Room>();

        if (currentRoom.doorPositions.HasFlag(DoorPositions.North))
        {
            Room adjacentRoom = rooms.FirstOrDefault(room => room.position == currentRoom.position + new Vector2(0, 1));

            if (adjacentRoom != null)
            {
                adjacentRooms.Add(adjacentRoom);
            }
        }
        if (currentRoom.doorPositions.HasFlag(DoorPositions.South))
        {
            Room adjacentRoom = rooms.FirstOrDefault(room => room.position == currentRoom.position + new Vector2(0, -1));
            
            if (adjacentRoom != null)
            {
                adjacentRooms.Add(adjacentRoom);
            }
        }
        if (currentRoom.doorPositions.HasFlag(DoorPositions.East))
        {
            Room adjacentRoom = rooms.FirstOrDefault(room => room.position == currentRoom.position + new Vector2(1, 0));
            
            if (adjacentRoom != null)
            {
                adjacentRooms.Add(adjacentRoom);
            }
        }
        if (currentRoom.doorPositions.HasFlag(DoorPositions.West))
        {
            Room adjacentRoom = rooms.FirstOrDefault(room => room.position == currentRoom.position + new Vector2(-1, 0));
            
            if (adjacentRoom != null)
            {
                adjacentRooms.Add(adjacentRoom);
            }
        }
        
        return adjacentRooms;
    }
}
