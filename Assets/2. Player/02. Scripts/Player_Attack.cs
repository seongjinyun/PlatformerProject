using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Transform pos;
    GameObject[] Enemy_Test;
    public Vector2 player_boxSize;
    protected float Kb_timer = 0f;
    static public float Skill_gauge = 0;
    protected Animator Player_anim;
    public float Kb_delayTime = 2f;
    protected float Max_Skill_gauge = 101;

    public Transform Parent;

    protected float Atk_curTime;


    public float Atk_coolTime = 1f;
    //public float Atk_speed = 1f;

    AllUnits.Unit Player_Dam;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
        Player_anim = GetComponent<Animator>();
        Player_Dam = GetComponentInParent<AllUnits.Unit>();
    }



    public void Attack_gauge()
    {

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
        foreach (Collider2D collider in collider2Ds)

        if (collider.tag == "Monster") //Monster �±׿� �浹�ϸ�
        {
            Gauge();
            // Health ��ũ��Ʈ ��������
            Monster_Stats Monster_Hp = collider.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                 Debug.Log("���� �ǰ�" + (Monster_Hp.Monster_currentHp - Player_Dam.damage));
                 Monster_Hp.Monster_TakeDamage(Player_Dam.damage);
                  // ü�� ����
            }
        }
    }


    public void Gauge()
    {
        Skill_gauge += 10;
        Debug.Log("������ + " + Skill_gauge);
    }






    /*IEnumerator Kb_Delay()
    {
        isKnockback = true;
        yield return new WaitForSeconds(0.41f);

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Monster") //Monster �±׿� �浹�ϸ�
                {
                    Skill_gauge += 5;
                    Debug.Log("������ + 5");
                    foreach (GameObject monster in Enemy_Test)

                    if (Parent.transform.position.x > monster.transform.position.x && monster.transform.rotation.y == 0) //�÷��̾� ��ġ�� ������ġ���� ������
                    {
                        //isKnockback = true;
                        collider.transform.Translate(-2.0f, 0.4f, 0); // ���� ƨ�ܳ���
                        is_delay = true;
                    }
                    else if (Parent.transform.position.x < monster.transform.position.x && monster.transform.rotation.eulerAngles.y <= 180) //�÷��̾� ��ġ�� ������ġ���� ����
                    {
                        //isKnockback = true;
                        collider.transform.Translate(-2.0f, 0.4f, 0); //���������� ƨ�ܳ���
                        is_delay = true;
                    }
                    else if (Parent.transform.position.x < monster.transform.position.x && monster.transform.rotation.eulerAngles.y <= -180) //�÷��̾� ��ġ�� ������ġ���� ����
                    {
                        //isKnockback = true;
                        collider.transform.Translate(2.0f, 0.4f, 0); //���������� ƨ�ܳ���
                        is_delay = true;
                    }
                }
            }
            
            yield return new WaitForSeconds(0.5f);
            isKnockback = false;
    }
    */


    // Update is called once per frame
    protected virtual void Update()
    {
        if (Skill_gauge >= Max_Skill_gauge)
        {
            Skill_gauge = 100;
            //Debug.Log(Skill_gauge);
        }
        atk_Anim();
    }
    void atk_Anim()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Player_anim.SetTrigger("Attack");

        }

    }
}