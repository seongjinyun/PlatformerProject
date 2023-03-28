using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postion : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player_Move.Player_Hp += 20;

            Destroy(gameObject);
        }
    }
}
