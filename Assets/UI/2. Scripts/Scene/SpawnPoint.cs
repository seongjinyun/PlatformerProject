using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string Spawnpoint;
    private HeroKnight player;
    void Start()
    {
        player = FindObjectOfType<HeroKnight>();
        if (Spawnpoint == player.currentmapname)
        {
            player.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
