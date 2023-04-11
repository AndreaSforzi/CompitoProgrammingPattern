using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
        GameManager.instance.GetComponent<AudioSource>().Stop();
        //fadeout
    }
}
