using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class PlayerTurnState : State
{
    private GameManager gameManager;
    bool _currentTurnEnded;
    GameStateType turn = GameStateType.PlayerTurn;

    public PlayerTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Enter()
    {
        _currentTurnEnded = false;
        gameManager.lastTurn = turn;
    }

    public override void Update()
    {
        if (gameManager.player.HandleMovement())
            _currentTurnEnded = true;


        if (_currentTurnEnded)
            gameManager.stateMachine.SetState(GameStateType.MidTurn);

    }
}