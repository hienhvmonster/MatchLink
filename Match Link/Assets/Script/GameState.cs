using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    private static GameStateID currentState = GameStateID.move;

    public static GameStateID GetGameState()
    {
        return currentState;
    }

    public static void SetGameState(GameStateID gameState)
    {
        currentState = gameState;
    }
}

public enum GameStateID
{
    deleteBlock,
    blockFall,
    move
}
