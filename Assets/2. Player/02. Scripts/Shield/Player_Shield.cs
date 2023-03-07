using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shield : Player_Move
{
    // Start is called before the first frame update
    protected override void Start()
    {
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        move();
        Jump();
        Dash();
    }

    

    /*protected override void move() // �θ�Ŭ����(Player_Move)�� �ִ� move �Լ��� ������ �� �� �ִ�. Ű����-->override
    {
        base.move();
    }*/
}