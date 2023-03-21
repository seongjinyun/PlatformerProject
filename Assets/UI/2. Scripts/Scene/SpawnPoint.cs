using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string Spawnpoint;
    public CurMapName Player;
    void Start()
    {
        Player = FindObjectOfType<CurMapName>();
        if (Spawnpoint == Player.CurMapname)
        {
            Player.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
