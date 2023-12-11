using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : SingletonMonobehaviour<GameManager>
{
    #region Header DUNGEON LEVELS
    [Space(10)]
    [Header("DUNGEON LEVELS")]
    #endregion

    #region Tooltip
    [Tooltip("Populate with dungeon levels scriptable objects")]
    #endregion
    [SerializeField] private List<DungeonLevelSO> dungeonLevelList;

    #region Tooltip
    [Tooltip("Populate with starting dungeon level for testing, first level = 0")]
    #endregion
    [SerializeField] private int currentDungeonLevelListIndex = 0;
    [HideInInspector] public GameState gameState;

    private void Start() 
    {
        gameState = GameState.gameStarted;
    }

    private void Update()
    {
        HandleGameState();

        // test
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameState = GameState.gameStarted;
        }
    }

    // handle game states
    private void HandleGameState()
    {
        switch(gameState)
        {
            case GameState.gameStarted:
                // play first level
                PlayDungeonLevel(currentDungeonLevelListIndex);
                gameState = GameState.playingLevel;
                break;
        }
    }

    // play current dungeon level
    private void PlayDungeonLevel(int currentDungeonLevelListIndex)
    {

    }

    #region Validation
#if UNITY_EDITOR
    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
    }
#endif
    #endregion

}
