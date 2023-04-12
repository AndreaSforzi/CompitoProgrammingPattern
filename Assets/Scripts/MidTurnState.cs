using UnityEngine;

internal class MidTurnState : State
{
    private GameManager gameManager;
    float timeForNextTurn=0;

    public MidTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Enter()
    {
        timeForNextTurn = gameManager.timeBetweenTurn;
    }

    public override void Update()
    {
        if (timeForNextTurn > 0)
        {
            timeForNextTurn -= Time.deltaTime;
            return;
        }

        if (gameManager.lastTurn == GameStateType.PlayerTurn)
        {
            if(gameManager.block>0)
            {
                gameManager.stateMachine.SetState(GameStateType.PlayerTurn);
                gameManager.blockText.text = gameManager.block.ToString();
                gameManager.block--;
            }
            else
            {
                gameManager.blockText.text = "";
                gameManager.stateMachine.SetState(GameStateType.EnemiesTurn);
            }
        }
        else
            gameManager.stateMachine.SetState(GameStateType.PlayerTurn);
    }
}