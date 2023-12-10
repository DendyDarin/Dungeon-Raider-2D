using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonLevel", menuName = "Scriptable Objects/Dungeon/Dungeon Level")]
public class DungeonLevelSO : ScriptableObject
{
    #region Header BASIC LEVEL DETAILS
    [Space(10)]
    [Header("BASIC LEVEL DETAILS")]
    #endregion

    #region Tooltip
    [Tooltip("The name for the level")]
    #endregion

    public string levelName;

    #region Header ROOM TEMPLATES FOR LEVEL
    [Space(10)]
    [Header("ROOM TEMPLATES FOR LEVEL")]
    #endregion

    #region Tooltip
    [Tooltip("Populate the list with room templates to be part of the level. We need to ensure that room templates are included for all room node types (specified in Room Node Graphs for the level)")]
    #endregion Tooltip

    public List<RoomTemplateSO> roomTemplateList;

    #region ROOM NODE GRAPHS FOR THE LEVEL
    [Header("ROOM NODE GRAPHS FOR THE LEVEL")]
    #endregion

    #region Tooltip
    [Header("Populate this list with the room node graphs which should be randomly selected for the level")]
    #endregion

    public List<RoomNodeGraphSO> roomNodeGraphList;

    #region Validation
#if UNITY_EDITOR

    // validate scriptable object detail entered
    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(levelName), levelName);

        if (HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomTemplateList), roomTemplateList)) return;
        if(HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomNodeGraphList), roomNodeGraphList)) return;

        // check to make sure that room templates are specified for all the node types in the specified node graphs

        // first check if north/south east/west corridor and entrance types has been specified
        bool isEWCorridor = false;
        bool isNSCorridor = false;
        bool isEntrance = false;

        // loop through all room templates to check
        foreach (RoomTemplateSO roomTemplateSO in roomTemplateList)
        {
            if (roomTemplateSO == null) return;

            if (roomTemplateSO.roomNodeType.isCorridorEW) isEWCorridor = true;

            if (roomTemplateSO.roomNodeType.isCorridorNS) isNSCorridor = true;

            if (roomTemplateSO.roomNodeType.isEntrance) isEntrance = true;
        }

        if (isEWCorridor == false)
        {
            Debug.Log("In " + this.name.ToString() + " : No E/W Corridor Room Type specified");
        }

        if (isNSCorridor == false)
        {
            Debug.Log("In " + this.name.ToString() + " : No N/S Corridor Room Type specified");
        }

        if (isEntrance == false)
        {
            Debug.Log("In " + this.name.ToString() + " : No Entrance Corridor Room Type specified");
        }

        // loop through all room node graphs
        foreach (RoomNodeGraphSO roomNodeGraph in roomNodeGraphList)
        {
            if (roomNodeGraph == null) return;

            // loop through all nodes in node graph
            foreach (RoomNodeSO roomNodeSO in roomNodeGraph.roomNodeList)
            {
                if (roomNodeSO == null) continue;

                // check the room template has been specified for each room nodes

                // corridors and entrance has been checked
                if (roomNodeSO.roomNodeType.isEntrance || roomNodeSO.roomNodeType.isCorridorEW || roomNodeSO.roomNodeType.isCorridorNS || roomNodeSO.roomNodeType.isCorridor || roomNodeSO.roomNodeType.isNone) continue;

                bool isRoomNodeTypeFound = false;

                // loop through all room templates to check that this node types has been specified
                foreach (RoomTemplateSO roomTemplateSO in roomTemplateList)
                {
                    if (roomTemplateSO == null) continue;

                    if (roomTemplateSO.roomNodeType == roomNodeSO.roomNodeType)
                    {
                        isRoomNodeTypeFound = true;
                        break;
                    }
                }

                if (!isRoomNodeTypeFound)
                {
                    Debug.Log("In " + this.name.ToString() + " : No room template " + roomNodeSO.roomNodeType.name.ToString() + " found for node graph " + roomNodeGraph.name.ToString());
                }
            }
        }
    }
#endif
    #endregion
}
