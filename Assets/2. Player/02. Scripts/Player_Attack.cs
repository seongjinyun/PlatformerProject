using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Transform pos;
    GameObject[] Enemy_Test;
    public Vector2 player_boxSize;
    protected bool isKnockback;
    protected float Kb_timer = 0f;
    static public float Skill_gauge = 0;
    protected Animator Player_anim;
    public float Kb_delayTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
        Player_anim = GetComponent<Animator>();
    }

    public void Attack_gauge()
    {

        if (Input.GetKeyDown(KeyCode.X))
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

            Player_anim.SetTrigger("Attack");
            
        }
    }
        // Update is called once per frame
        void Update()
    {
            Attack_gauge();
    }
}
