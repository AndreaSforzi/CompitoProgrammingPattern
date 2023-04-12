using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    Red,Blue,Green,Yellow
}

public class Door : MonoBehaviour
{
    [SerializeField] DoorType doorColor;

    private void Start()
    {
        PubSub.Instance.RegisterFunction(MessageType.KeyCollected, OnKeyCollected);
    }
    void OnKeyCollected(object content)
    {
        if (content is not Key)
            return;
        Key key = (Key)content;

        if (key.doorTypeToOpen == doorColor)
            Destroy(gameObject);
    }
}
