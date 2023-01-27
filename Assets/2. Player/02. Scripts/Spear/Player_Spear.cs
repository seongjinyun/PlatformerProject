using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spear : Player_Move
{
    // Start is called before the first frame update
    void Start()
    {
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        move_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Dash();
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mons_weapon"))
        {
            Player_Hp -= 10;
            if (Player_Hp <= 0)
            {
                Debug.Log("ÇÇ°Ý");
                //player die
            }
        }
    }
}
