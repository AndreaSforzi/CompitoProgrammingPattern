using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] LayerMask wallMask;

    List<Vector2> _directions;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemies.Add(this);
        _directions = new List<Vector2>() { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    }

    


    public bool HandleMovement()
    {

        if (_directions.Count <= 0)
            return true;

        Vector2 _directionToMove = _directions[Random.Range(0, _directions.Count)];

        Vector2 _nextPosition = new Vector2(transform.position.x, transform.position.y)+_directionToMove;

        if (Physics2D.Raycast(transform.position, _nextPosition - new Vector2(transform.position.x, transform.position.y), 1, wallMask))
        {
            _directions.Remove(_directionToMove);
            return false;
        }

        gameObject.GetComponent<Rigidbody2D>().MovePosition(_nextPosition);
        _directions = new List<Vector2>() { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        return true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}
