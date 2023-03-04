using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim_Shield : Player_Attack
{
    Animator Shield_Anim;
    GameObject enemy;
    public GameObject Shield_Skill;
    public GameObject player;
    public GameObject[] Shield_pos;

    //�˹�
    public float Knockback_speed = 3;
    //protected bool isKnockback;
    //public float Kb_delayTime = 2f;
    //protected float Kb_timer = 0f;

    //������
    //public float Skill_gauge = 0;

    //���� ����
    //public Transform pos;
    //public Vector2 player_boxSize;

    //�׽�Ʈ
    //public GameObject[] Enemy_Test;
    public GameObject[] Enemy_Test1; // ���� ��ų ��ġ ����


    // Start is called before the first frame update
    void Start()
    {
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Enemy"); 
        //Enemy_Test[0] = enemy;
        Shield_Anim = GetComponent<Animator>();
        //float dist = Vector3.Distance(transform.position, enemy.transform.position);
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Monster"); 
        Enemy_Test1 = GameObject.FindGameObjectsWithTag("Shield_Skill_pos"); //���� ��ų ��ġ ���� ��信 �±�

    }

    void Attack()
    {
        

        /*if (Input.GetKeyDown(KeyCode.X))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
            foreach (Collider2D collider in collider2Ds)
            {
                
                

                if (collider.tag == "Monster") //Monster �±׿� �浹�ϸ�
                {
                    Skill_gauge += 5;
                    Debug.Log("������ + 5");
                    foreach (GameObject monster in Enemy_Test)

                    if (transform.position.x >= monster.transform.position.x && !isKnockback)

                    {
                        isKnockback = true;
                        collider.transform.Translate(2.0f, 0.4f, 0);

                    }
                    else

                    {
                        isKnockback = true;
                        collider.transform.Translate(-2.0f, 0.4f, 0);

                    }
                    if (isKnockback) //�˹� Ÿ�̸�
                    {
                        Kb_timer += Time.deltaTime;
                        if (Kb_timer >= Kb_delayTime)
                        {
                            Kb_timer = 0f;
                            isKnockback = false;
                        }
                    }

                    
                }
            }

            Shield_Anim.SetTrigger("Attack_shield");
            //Vector2 dir = (transform.position - Enemy.transform.position).normalized;
            //player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
        }
        */




        //foreach (GameObject mob in Enemy_Test)
        {
            foreach (GameObject pos in Enemy_Test1)
            {
                float dist = Vector3.Distance(transform.position, pos.transform.position);
                if (Input.GetKeyDown(KeyCode.A) && dist <= 13.0f && Skill_gauge >= 100) //��ų�������� 100�̰� AŰ�� ������
                {

                    //float dist = Vector3.Distance(transform.position, mob.transform.position);
                    Shield_Anim.SetTrigger("Skill_shield");
                    GameObject She_ = Instantiate(Shield_Skill, pos.transform.position, transform.rotation);
                    Destroy(She_, 1f);
                    Skill_gauge = 0; //������ 0���� �ʱ�ȭ
                }
            }
            //Debug.Log("�Ÿ� " + dist);
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        
        //Debug.Log("�Ÿ�" + distance);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
