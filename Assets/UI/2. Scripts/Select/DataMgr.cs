using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Sword, Spear, Shield
}
public class DataMgr : MonoBehaviour
{
    public string presentScene;


    public static DataMgr instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }
    public Character currentCharacter;

    private void Update()
    {
        if(presentScene == "UI_Main")
        {
            Destroy(this.gameObject);
        }
    }
}
