using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum GameStateType
{
    PlayerTurn,
    EnemiesTurn
}



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Enemy> enemies=new List<Enemy>();

    public StateMachine<GameStateType> stateMachine { get; } = new();

    [SerializeField] TextMeshProUGUI pointText;

    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PubSub.Instance.RegisterFunction(MessageType.PointsCollected, OnPointCollected);
        pointText.text = "0";

        stateMachine.RegisterState(GameStateType.PlayerTurn, new PlayerTurnState(this));
        stateMachine.RegisterState(GameStateType.EnemiesTurn, new EnemiesTurnState(this));
        stateMachine.SetState(GameStateType.PlayerTurn);

        
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.StateUpdate();
    }

    void OnPointCollected(object content)
    {
        if (content is not int)
            return;

        pointText.text = content.ToString();
    }
}

