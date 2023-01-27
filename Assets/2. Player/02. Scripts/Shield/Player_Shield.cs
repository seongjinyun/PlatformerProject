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
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
        Dash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mons_weapon"))
        {
            Player_Hp -= 10;
            if (Player_Hp <= 0)
            {
                Debug.Log("�ǰ�");
                //player die
            }
        }
    }

    /*protected override void move() // �θ�Ŭ����(Player_Move)�� �ִ� move �Լ��� ������ �� �� �ִ�. Ű����-->override
    {
        base.move();
    }*/
}
