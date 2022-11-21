using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerData : MonoBehaviour
{
    public static _PlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<_PlayerData>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("_PlayerData");
                    instance = instanceContainer.AddComponent<_PlayerData>();
                }
            }
            return instance;
        }

    }
    private static _PlayerData instance;

    public GameObject Player;
}
