using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Anim : Player_Attack
{
    public GameObject self;


    //protected Animator Player_anim;
    //public Transform pos;
    //public Vector2 player_boxSize;
    //public GameObject enemy;

    public Transform Sword_pos;
   //public Transform Sword_pos_2; // ��ų ��ȭ ����

    //�˹�
    public float Knockback_speed = 3;
    //protected bool isKnockback;
    //public float Kb_delayTime = 2f;

    //protected float Kb_timer = 0f;

    //��ų
    public GameObject Sword_skill;
    public GameObject Sword_skill_2; // ��ų ��ȭ ����

    //������
    //public float Skill_gauge = 0;


    //GameObject[] Enemy_Test;

    protected Rigidbody2D player_rigid;




    public float speed;
    protected Animator move_animator;
    protected SpriteRenderer sprite;
    //private float str = 16;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Player_anim = GetComponent<Animator>();
        player_rigid = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
        move_animator = GetComponent<Animator>();
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
        
    }

    protected virtual void Attack()
    {

        
        if (Input.GetKeyDown(KeyCode.A) && Skill_gauge >= 100) //��ų�������� 100�̰� AŰ�� ������
        {

            if (self.transform.rotation.eulerAngles.y > 0) // ���������� ��ų
            {
                Player_anim.SetTrigger("Skill");
                Instantiate(Sword_skill, Sword_pos.position, Quaternion.Euler(0, 0, 0));
                //Instantiate(Sword_skill_2, Sword_pos.position, Quaternion.Euler(0, 0, 0)); //��ų ��ȭ
                Skill_gauge = 0; //������ 0���� �ʱ�ȭ
            }
            else if(self.transform.rotation.eulerAngles.y == 0) //�������� ��ų
            {

                Player_anim.SetTrigger("Skill");
                Instantiate(Sword_skill, Sword_pos.position, Quaternion.Euler(180, 0, 180));
                //Instantiate(Sword_skill_2, Sword_pos.position, Quaternion.Euler(180, 0, 180)); //��ų ��ȭ
                Skill_gauge = 0; //������ 0���� �ʱ�ȭ
            }
            
        }

    }




    /*public void Nb()
    {
        Vector2 dir = (transform.position - enemy.transform.position).normalized;
        player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
    }*/
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //Nb();
        Attack();
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
