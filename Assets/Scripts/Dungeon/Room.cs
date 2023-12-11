using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string id;
    public string templateID;
    public GameObject prefab;
    public RoomNodeTypeSO roomNodeType;
    public Vector2 lowerBounds;
    public Vector2 upperBounds;
    public Vector2 templateLowerBounds;
    public Vector2 templateUpperBounds;
    public Vector2[] spawnPositionArray;
    public List<string> childRoomIDList;
    public string parentRoomID;
    public List<Doorway> doorwayList;
    public bool isPositioned = false;
    public InstantiatedRoom instantiatedRoom;
    public bool isLit = false;
    public bool isClearedOfEnemies = false;
    public bool isPreviouslyVisited = false;

    // constructors
    public Room()
    {
        childRoomIDList = new List<string>();
        doorwayList = new List<Doorway>();
    }
}
