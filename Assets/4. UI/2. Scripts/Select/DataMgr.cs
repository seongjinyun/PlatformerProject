using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Sword, Spear, Shield
}
public class DataMgr : MonoBehaviour
{


    public static DataMgr instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
    }
    public Character currentCharacter;

    private void Update()
    {
    }
}
