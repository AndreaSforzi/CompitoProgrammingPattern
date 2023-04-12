using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] LayerMask wallMask;

    Vector2 _nextPosition;

    Animator _animator;

    int _pointsCounter;

    bool _alive = true;

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
        GameManager.instance.player = this;

        PubSub.Instance.RegisterFunction(MessageType.Die, OnDie);

        _animator = gameObject.GetComponent<Animator>();
    }

    

    public bool HandleMovement()
    {
        if (!_alive)
            return false;

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

    public void OnDie(object content)
    {
        _animator.SetTrigger("Die");
        _alive = false;
        GameManager.instance.GetComponent<AudioSource>().Stop();
    }

    public void OnDieAnimationEnd()
    {
        GameManager.instance.LoadLevel(SceneManager.GetActiveScene());
    }
}
