using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class PlayerTurnState : State
{
    private GameManager gameManager;
    bool _currentTurnEnded;

    public PlayerTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Enter()
    {
        _currentTurnEnded = false;
    }

    public override void Update()
    {
        if (Player.Instance.HandleMovement())
            _currentTurnEnded = true;




        if (_currentTurnEnded)
            gameManager.stateMachine.SetState(GameStateType.EnemiesTurn);

    }
}