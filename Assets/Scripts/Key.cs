using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorType doorTypeToOpen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            gameObject.GetComponent<AudioSource>().Play();
            PubSub.Instance.SendMessage(MessageType.KeyCollected, this);     
            Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length);
        }
    }
}
