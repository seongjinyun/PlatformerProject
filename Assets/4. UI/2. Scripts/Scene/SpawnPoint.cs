using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string Spawnpoint;
    public CurMapName Player;
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Player = player.GetComponent<CurMapName>();

        if (Spawnpoint == Player.CurMapname)
        {
            Player.transform.position = transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
 
    }

}
