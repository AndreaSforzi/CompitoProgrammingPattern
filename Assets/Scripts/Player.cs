using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;

    Vector2 _nextPosition;
    [SerializeField] LayerMask wallMask;
    

    int _pointsCounter;

    public int Points
    {
        get => _pointsCounter;
        set
        {
            _pointsCounter += value;
            
            PubSub.Instance.SendMessage(MessageType.PointsCollected, _pointsCounter);
        }
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    

    public bool HandleMovement()
    {
        InputManager();

        if (_nextPosition != Vector2.zero)
        {
            
            if (Physics2D.Raycast(transform.position, _nextPosition - new Vector2(transform.position.x, transform.position.y), 1, wallMask))
                return false;
            

            Move(_nextPosition);
            _nextPosition = Vector2.zero;
            return true;
        }

        return false;
    }

    private void InputManager()
    {
        if (Input.GetAxis("Horizontal") > 0)
            _nextPosition = new Vector2(transform.position.x + 1, transform.position.y);
        else if (Input.GetAxis("Horizontal") < 0)
            _nextPosition = new Vector2(transform.position.x - 1, transform.position.y);
        else if (Input.GetAxis("Vertical") > 0)
            _nextPosition = new Vector2(transform.position.x, transform.position.y + 1);
        else if (Input.GetAxis("Vertical") < 0)
            _nextPosition = new Vector2(transform.position.x, transform.position.y - 1);
    }

    private void Move(Vector2 newPosition)
    {
        gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
}