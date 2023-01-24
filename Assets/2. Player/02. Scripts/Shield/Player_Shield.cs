using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shield : Player_Move
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
        Jump();
        Dash();
    }

    /*protected override void move() // 부모클래스(Player_Move)에 있는 move 함수를 재정의 할 수 있다. 키워드-->override
    {
        base.move();
    }*/
}
