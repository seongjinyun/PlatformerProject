using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    Rigidbody2D rigid;
    float MeteorPw = 10;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag == "Ground")
        {
            Destroy(this.gameObject);

        }
        if (collision.tag == "Player")
        {   
            //데미지 주고 삭제 
            Destroy(this.gameObject);

        }
    }
}

