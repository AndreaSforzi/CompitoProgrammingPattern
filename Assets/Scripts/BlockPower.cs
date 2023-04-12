using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPower : MonoBehaviour
{
    [SerializeField] int turnsToBlock = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            GameManager.instance.block = turnsToBlock;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length);
        }
    }
}
