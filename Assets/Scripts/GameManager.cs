using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStateType
{
    PlayerTurn,
    EnemiesTurn,
    MidTurn
}



public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public StateMachine<GameStateType> stateMachine { get; } = new();

    [SerializeField] TextMeshProUGUI pointText;
    public TextMeshProUGUI blockText;

    public float timeBetweenTurn = 1;

    public List<Enemy> enemies { get; } = new List<Enemy>();
    [HideInInspector] public Player player;

    [HideInInspector] public int  block = 0;
    [HideInInspector] public GameStateType lastTurn;

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
        stateMachine.RegisterState(GameStateType.MidTurn, new MidTurnState(this));
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

    public void LoadLevel(Scene sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }

    
}

