using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim_Spear : Player_Anim
{
    //public GameObject Spear_skill; //��ų
    public Transform Skill_pos;

    // Start is called before the first frame update
    void Start()
    {
        Player_anim = GetComponent<Animator>();
        player_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Attack();
        Spear_skill();
    }
    void Spear_skill()
    {
        if (Input.GetKeyDown(KeyCode.A) && Skill_gauge >= 100) //��ų�������� 100�̰� AŰ�� ������
        {


            Player_anim.SetTrigger("Skill_spear");
            Instantiate(Sword_skill, Skill_pos.position, Quaternion.Euler(0, 0, 225.0f));
            Skill_gauge = 0; //������ 0���� �ʱ�ȭ

        }
    }

   
}
