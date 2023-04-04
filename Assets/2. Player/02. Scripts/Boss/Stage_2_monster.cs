using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : Basic_Boss
{
    //public BoxCollider2D HitBox;
    public GameObject Attack_Skill_2, Ice_Arrow, Pre_Ice_Spike;
    public Transform self;
    public Transform Skill_pos_2, Ice_Arrow_pos;
    public AudioClip[] clip; // 0 = ���� ��Ÿ, 1 = ���� ����

    //public Transform self_tr;
    //public Vector2 monster_boxSize;
    //public BoxCollider2D mon_attack;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
        Ice_Arrow_pos = GameObject.FindGameObjectWithTag("Monster_Skill_Pos").GetComponent<Transform>();
    }

    protected override void Update()
    {
        base.Update();
        //StartCoroutine(MonsterChase());
       

        if (isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Run", true);
        }
        if (MonsterDie)
        {
            BoolManager.SecondStageBossDie = true;
        }
    }


    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //���� ���̿� ������ ���� �ð�
        if (!MonsterDie)
        {
            int ranPattern = Random.Range(0, 4);
            switch (ranPattern)
            {
                case 0:
                    StartCoroutine(TeleAttack());
                    break;
                case 1:
                    StartCoroutine(Second_Attack());
                    break;
                case 2:
                    StartCoroutine(BossDash());
                    break;
                case 3:
                    StartCoroutine(Ice_Bullet());
                    break;
               
            }
        }
    }

    IEnumerator Ice_Bullet()
    {
        base.LookPlayer();
        anim.SetBool("Attack", true); // �ִϸ��̼� ����
        SfxManger.instance.SfxPlay("Ice_Skill_1", clip[0]);
        yield return new WaitForSeconds(1f); // 1�ʵڿ�
        GameObject Skill_1_pos = Instantiate(Pre_Ice_Spike, Ice_Arrow_pos.position, Quaternion.Euler(0, 0, 0)); // �÷��̾� ��ġ�� �غ� ��ų�߰�
        yield return new WaitForSeconds(1f); // 1�ʵڿ�
        
        GameObject Skill_1 = Instantiate(Ice_Arrow, Skill_1_pos.transform.position, Quaternion.Euler(0, 0, 0)); // �÷��̾� ��ġ�� ��ų ��
        Destroy(Skill_1_pos); // �غ� ��ų ����
        Destroy(Skill_1, 1f); // 1�ʵڿ� ����
        anim.SetBool("Attack", false); // �ִϸ��̼� Idle��
        StartCoroutine(RandomPattern());
    }

    
    IEnumerator Second_Attack()
    {
        base.LookPlayer();
        
        anim.SetBool("Attack_2", true);
        SfxManger.instance.SfxPlay("Ice_Skill_explosion", clip[1]);
        yield return new WaitForSeconds(1f); // 1�� �ڿ�
        GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Skill_pos_2.rotation); //�ν��Ͻÿ���Ʈ
        Destroy(Skill_2, 2f);
        anim.SetBool("Attack_2", false);
        StartCoroutine(RandomPattern());
        
    }
    IEnumerator TeleAttack()
    {
        transform.position = Target.transform.position;
        yield return new WaitForSeconds(0.8f);
        base.LookPlayer();
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("Attack", false);
        StartCoroutine(RandomPattern());
    }

    IEnumerator BossDash()
    {
        base.LookPlayer();//�÷��̾� ���� �ٶ󺸱�
        isDash = true;
        DashPos.SetActive(true);
        yield return new WaitForSeconds(1.5f); //���� ���� �ð�
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime); // �������濡 DashDir��� �� ������Ʈ �����ؼ� ����(�������� �����ϰԲ�) Ÿ�� ���������� �ϸ� �̻��ϰ� �ȵ�
        yield return new WaitForSeconds(2.5f);
        isDash = false;
        anim.SetBool("Run", false);
        DashPos.SetActive(false);
        StartCoroutine(RandomPattern());
    }

    
    /*public void en_Attack()
    {
        mon_attack.enabled = true;
    }
    public void de_Attack()
    {
        mon_attack.enabled = false;
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(self_tr.position, monster_boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
            if (collider.tag == "Player")
            {
                AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
                if (player_Hp != null)
                {

                    player_Hp.TakeDamage(Monster_Damage);
                    // ü�� ����

                }
            }

    }*/

    private void OnDrawGizmos() // ���� ����
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
