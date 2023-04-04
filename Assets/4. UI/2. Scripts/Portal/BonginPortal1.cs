using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonginPortal1 : MonoBehaviour
{
    public GameObject BongSpawn;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = BongSpawn.transform.position;
        }
    }
}

