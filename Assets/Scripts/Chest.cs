using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    [SerializeField] int pointsToGive=0;

    Animator _animator;
    TextMeshPro textMesh;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        textMesh = gameObject.GetComponentInChildren<TextMeshPro>(true);
        textMesh.text = pointsToGive.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().Points = pointsToGive;
            textMesh.text = pointsToGive.ToString();
            gameObject.GetComponent<AudioSource>().Play();
            _animator.SetTrigger("Open"); 
        }
    }

    public void OnOpeningAnimationEnd()
    {
        Destroy(gameObject);
    }
}
