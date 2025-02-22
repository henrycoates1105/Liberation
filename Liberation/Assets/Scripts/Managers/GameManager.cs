using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    // Game manager Instance
    void Awake()
    {
        Instance = this;
    }

    // Start first GameState
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    // Game state logic and switch function
    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;

            case GameState.SpawnUnits:
                UnitManager.Instance.GetTileAmount();
                UnitManager.Instance.SpawnUnits();
                break;

            case GameState.HumanTurn:
                break;

            case GameState.OrcTurn:
                break;                                

            case GameState.ElfTurn:
                break;
                
            case GameState.DemonTurn:
                break;                                                                

            case GameState.DwarfTurn:
                break;            

            case GameState.EndGame:
                break; 

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

// 'Flow' of game
public enum GameState
{
    GenerateGrid,
    SpawnUnits,
    HumanTurn,
    OrcTurn,
    ElfTurn,
    DemonTurn,
    DwarfTurn,
    EndGame

}
