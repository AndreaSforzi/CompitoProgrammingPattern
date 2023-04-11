using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            gameObject.GetComponentInParent<AudioSource>().Play();
            gameObject.GetComponentInParent<Door>().Open();        
            Destroy(gameObject);
        }
    }
}
