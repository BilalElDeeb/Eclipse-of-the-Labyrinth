using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

//NumberOfRooms = 3.33 × FloorDepth + 5-6 (maximum of 20)
public class DungeonLayoutGenerator : MonoBehaviour
{
    public int dungeonDifficulty;
    public int dungeonDepth;
    private int numberOfRooms;
    NetworkManager networkManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        numberOfRooms = (int)Math.Ceiling(((3.33*dungeonDepth) + (3.33*dungeonDifficulty)) + Random.Range(3,9));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<Vector2Int> CreateRoomPositions()
    {
        List<Vector2Int> roomPositions = new List<Vector2Int>();
        List<Vector2Int> possibleRoomPositions = new List<Vector2Int>();
        List<Vector2Int> possiblePositions = new List<Vector2Int>();
        
        possibleRoomPositions.Add(new Vector2Int(0, 0));

        while (roomPositions.Count < numberOfRooms)
        {
            int i =Random.Range(0, (possibleRoomPositions.Count - 1));
            Vector2Int roomToAdd = possibleRoomPositions[i]; 
            roomPositions.Add(roomToAdd);
            
            Vector2Int UpRoomPosition = roomToAdd + Vector2Int.up;
            Vector2Int DownRoomPosition = roomToAdd + Vector2Int.down;
            Vector2Int LeftRoomPosition = roomToAdd + Vector2Int.left;
            Vector2Int RightRoomPosition = roomToAdd + Vector2Int.right;
            
            possiblePositions.Add(UpRoomPosition);
            possiblePositions.Add(DownRoomPosition);
            possiblePositions.Add(LeftRoomPosition);
            possiblePositions.Add(RightRoomPosition);

            foreach (Vector2Int roomPosition in possiblePositions)
            {
                if (!roomPositions.Contains(roomPosition) && !possibleRoomPositions.Contains(roomPosition))
                {
                    possibleRoomPositions.Add(roomPosition);
                }
            }
            possiblePositions.Clear();
            
            possibleRoomPositions.Remove(roomToAdd);
        }

        return roomPositions;
    }
    
    public List<Room> CreateDungeonLayout()
    {
        List<Room> rooms = new List<Room>();
        List<Vector2Int> roomPositions = CreateRoomPositions();

        rooms.Add(new Room()
        {
            position = roomPositions[0],
            doorPositions = 0
        });
        
        for (int i = 1; i < roomPositions.Count; i++)
        {
            Room newRoom = new Room()
            {
                position = roomPositions[i],
                doorPositions = 0
            };
            Room adjacentRoom = FindAdjacentRoom(newRoom, rooms);
            if (newRoom.position.x < adjacentRoom.position.x)
            {
                newRoom.doorPositions |= DoorPositions.East;
                adjacentRoom.doorPositions |= DoorPositions.West;
            }
            else if (newRoom.position.x > adjacentRoom.position.x)
            {
                newRoom.doorPositions |= DoorPositions.West;
                adjacentRoom.doorPositions |= DoorPositions.East;
            }
            else if (newRoom.position.y < adjacentRoom.position.y)
            {
                newRoom.doorPositions |= DoorPositions.North;
                adjacentRoom.doorPositions |= DoorPositions.South;
            }
            else if (newRoom.position.y > adjacentRoom.position.y)
            {
                newRoom.doorPositions |= DoorPositions.South;
                adjacentRoom.doorPositions |= DoorPositions.North;
            }
           
            rooms.Add(newRoom);
        }
        return rooms;
    }

    Room FindAdjacentRoom(Room roomToCheck, List<Room> rooms)
    {
        rooms = rooms.OrderBy(room => Random.value).ToList();
        
        return rooms.FirstOrDefault(room => (room.position - roomToCheck.position).magnitude == 1);
    }
}

public class Room
{
    public Vector2Int position;
    public DoorPositions doorPositions;
}


