using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            gameObject.GetComponent<AudioSource>().Play();

            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
