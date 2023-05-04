using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Transform pos;
    static protected GameObject[] Enemy_Test;
    public Vector2 player_boxSize;
    protected float Kb_timer = 0f;
    static public float Skill_gauge = 0;
    protected Animator Player_anim;
    public float Kb_delayTime = 2f;
    protected float Max_Skill_gauge = 101;

    public GameObject Attacked_Effect;

    public GameObject[] Enemy_Effect_Pos;

    public AudioClip[] clip; // 0 = Sword_Attack, 1 = Spear_Attack, 2 = Shield_Attack, 3 = Monster_Attacked

    AllUnits.Unit Player_Dam;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        Player_anim = GetComponent<Animator>();
        Player_Dam = GetComponentInParent<AllUnits.Unit>();
        if (GameObject.FindGameObjectWithTag("Gauge_Chk"))
        {
            Skill_gauge = 0;
        }
    }


    public void Attack_gauge()
    {
        
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
        foreach (Collider2D collider in collider2Ds)
        {
            Monster_Stats Monster_Hp = collider.gameObject.GetComponent<Monster_Stats>();
            if (collider.tag == "Monster" && Monster_Hp.Monster_currentHp > 0) //Monster �±׿� �浹�ϸ�
            {
                // Health ��ũ��Ʈ ��������
                //Monster_Stats Monster_Hp = collider.gameObject.GetComponent<Monster_Stats>();
                if (Monster_Hp != null)
                {
                    foreach(GameObject ef_pos in Enemy_Effect_Pos)
                    {
                        Debug.Log("���� �ǰ�" + (Monster_Hp.Monster_currentHp - Player_Dam.damage)); // ����hp - �÷��̾� ������
                        Monster_Hp.Monster_TakeDamage(Player_Dam.damage);
                        GameObject Atk_Ef = Instantiate(Attacked_Effect, ef_pos.transform.position, ef_pos.transform.rotation); // ����Ʈ ���� �ν��ϼ���Ʈ
                        Destroy(Atk_Ef, 1f);
                        SfxManger.instance.SfxPlay("Monster_Attacked", clip[3]);
                        Gauge();
                        // ü�� ����
                    }

                }

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
        Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
        Enemy_Effect_Pos = GameObject.FindGameObjectsWithTag("Hit_Effect");
    }
    void atk_Anim()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Player_anim.SetTrigger("Attack");
        }

    }

    void atk_Sound()
    {
        if (GameObject.Find("Player_Sword(Clone)"))
        {
            SfxManger.instance.SfxPlay("Sword_Attack", clip[0]);
        }
        else if (GameObject.Find("Player_Spear(Clone)"))
        {
            SfxManger.instance.SfxPlay("Spear_Attack", clip[1]);
        }
        else if (GameObject.Find("Player_shield(Clone)"))
        {
            SfxManger.instance.SfxPlay("Shield_Attack", clip[2]);
        }
    }
}