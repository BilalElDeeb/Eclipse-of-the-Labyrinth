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
    // Start is called before the first frame update
    void Start()
    {
        List<Room> dungeonlayout = dungeonlayoutGenerator.CreateDungeonLayout();
        
        foreach (Room newRoom in dungeonlayout)
        {
            CreateRoom(newRoom);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateRoom(Room newRoom)
    {
        int sortingOrderOffset = -100;
    
        int targetRoom = Random.Range(0, roomVariants.Count);
        GameObject room = Instantiate(roomVariants[targetRoom],new Vector3((newRoom.position.x * 22), 
            (newRoom.position.y * 10), 0), Quaternion.identity);
        room.GetComponent<DoorPositionsManager>().CreateDoorPositions(newRoom.doorPositions);

        List<TilemapRenderer> TilemapRenderer = room.GetComponentsInChildren<TilemapRenderer>().ToList();

        foreach (TilemapRenderer tilemapRenderer in TilemapRenderer)
        {
            tilemapRenderer.sortingOrder += -(newRoom.position.y) + sortingOrderOffset;
        }
    }
}
