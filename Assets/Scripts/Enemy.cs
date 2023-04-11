using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] LayerMask wallMask;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool HandleMovement()
    {
        List<Vector2> _directions = new List<Vector2>() { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        // scegli direzione 

        Vector2 _directionToMove = _directions[Random.Range(0, _directions.Count)];

        Vector2 _nextPosition = new Vector2(transform.position.x, transform.position.y)+_directionToMove;

        if (Physics2D.Raycast(transform.position, _nextPosition - new Vector2(transform.position.x, transform.position.y), 1, wallMask))
            return false;

        gameObject.GetComponent<Rigidbody2D>().MovePosition(_nextPosition);
        return true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
