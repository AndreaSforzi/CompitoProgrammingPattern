internal class EnemiesTurnState : State
{
    private GameManager gameManager;
    bool _currentTurnEnded;
    int _enemyToMove;
    GameStateType turn = GameStateType.EnemiesTurn;

    public EnemiesTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Enter()
    {
        _enemyToMove = 0;
        _currentTurnEnded = false;
        gameManager.lastTurn = turn;
    }

    public override void Update()
    {
        if (gameManager.enemies[_enemyToMove].HandleMovement())
        {
            _enemyToMove++;
            if (_enemyToMove == gameManager.enemies.Count)
                _currentTurnEnded = true;
        }

        if (_currentTurnEnded)
            gameManager.stateMachine.SetState(GameStateType.MidTurn);

    }
}