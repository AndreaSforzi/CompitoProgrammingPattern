using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPower : MonoBehaviour
{
    [SerializeField] int turnsToBlock = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.block = turnsToBlock;
        Destroy(gameObject);
    }
}
