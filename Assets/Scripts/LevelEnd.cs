using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
        //GameManager.instance.Fadeout(SceneManager.GetSceneByName("Level2"));
    }
}
