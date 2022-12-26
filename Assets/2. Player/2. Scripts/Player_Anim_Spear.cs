using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim_Spear : MonoBehaviour
{
    //public GameObject Spear_skill; //��ų
    public Transform Skill_pos;
    Animator Spear_anim;

    public Transform pos;
    public Vector2 player_boxSize;
    public GameObject enemy;

    //�˹�
    public float Knockback_speed = 3;
    protected bool isKnockback;
    public float Kb_delayTime = 2f;

    protected float Kb_timer = 0f;

    //��ų
    public GameObject Sword_skill;

    //������
    public float Skill_gauge = 100;




    protected Rigidbody2D player_rigid;
    //private float str = 16;

    Quaternion quaternion = Quaternion.Euler(0, 0, -90);

    // Start is called before the first frame update
    void Start()
    {
        Spear_anim = GetComponent<Animator>();
        player_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        //Spear_skill(); //��� ��� ���� �� �Լ�
    }
    //void Spear_skill()
    //{
       // if (Input.GetKeyDown(KeyCode.A)/* && Skill_gauge >= 100*/) //��ų�������� 100�̰� AŰ�� ������
       /* {


            Player_anim.SetTrigger("Skill_spear");
            //Instantiate(Sword_skill, Skill_pos.position, Quaternion.Euler(0, 0, 225.0f)); // �밢�� â
            Instantiate(Sword_skill, pos.position, quaternion);
            Skill_gauge = 0; //������ 0���� �ʱ�ȭ

        }
    }*/

    void Attack()
    {
        

        if (Input.GetKeyDown(KeyCode.X))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy") //Enemy �±׿� �浹�ϸ�
                {
                    Debug.Log("Enemy Attack");
                    if (transform.position.x >= enemy.transform.position.x && !isKnockback)

                    {
                        isKnockback = true;
                        enemy.transform.Translate(0.5f, 0.2f, 0);

                    }
                    else

                    {
                        isKnockback = true;
                        enemy.transform.Translate(-0.5f, 0.2f, 0);

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

                    Skill_gauge += 5;
                    Debug.Log("������ + 5");
                }
            }

            Spear_anim.SetTrigger("Attack_spear");
            //Vector2 dir = (transform.position - Enemy.transform.position).normalized;
            //player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A) /*&& Skill_gauge >= 100*/) //��ų�������� 100�̰� AŰ�� ������
        {


            Spear_anim.SetTrigger("Skill_spear");
            Instantiate(Sword_skill, pos.position, transform.rotation);
            Skill_gauge = 0; //������ 0���� �ʱ�ȭ


        }
    }

}
