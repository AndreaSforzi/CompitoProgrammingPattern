using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageType
{
    PointsCollected,
    Die
}

public class PubSub : MonoBehaviour
{
    static PubSub _instance;

    public static PubSub Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            GameObject pubSubObject = new GameObject("PubSub");
            _instance = pubSubObject.AddComponent<PubSub>();
            return _instance;
        }
    }

    private Dictionary<MessageType, List<Action<object>>> _registeredFunctions = new();

    public void RegisterFunction(MessageType messageType, Action<object> function)
    {
        if (_registeredFunctions.ContainsKey(messageType))
            _registeredFunctions[messageType].Add(function);
        else
        {
            List<Action<object>> newList = new();
            newList.Add(function);

            _registeredFunctions.Add(messageType, newList);
        }

    }

    public void SendMessage(MessageType messageType,object messageContent)
    {
        foreach (Action<object> function in _registeredFunctions[messageType])
            function.Invoke(messageContent);
    }
}
