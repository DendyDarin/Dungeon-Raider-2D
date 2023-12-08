using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room_", menuName = "Scriptable Objects/Dungeon/Room")]
public class RoomTemplateSO : ScriptableObject
{
    [HideInInspector] public string guid;

    #region Header ROOM PREFAB
    [Header("ROOM PREFAB")]
    #endregion Header ROOM PREFAB

    #region Tooltip
    [Tooltip("The game object prefab for the room (this will contain all the tilemaps for the room and environment game objects)")]
    #endregion Tooltip

    public GameObject prefab;

    [HideInInspector] public GameObject previousPrefab; // used to regenerate the GUID if SO is copied and the prefab has changed

    #region Header ROOM CONFIGURATION
    [Space(10)]
    [Header("ROOM CONFIGURATION")]
    #endregion Header ROOM CONFIGURATION

    #region Tooltip
    [Tooltip("The room node type SO.")]
    #endregion Tooltip
    public RoomNodeTypeSO roomNodeType;
}
