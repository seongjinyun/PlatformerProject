using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : Basic_Boss
{
    //public BoxCollider2D HitBox;
    public GameObject Attack_Skill_2, Ice_Arrow, Pre_Ice_Spike;
    public Transform self;
    public Transform Skill_pos_2, Ice_Arrow_pos;
    public AudioClip[] clip; // 0 = 얼음 강타, 1 = 얼음 슬램

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
        yield return new WaitForSeconds(2.0f); //패턴 사이에 나오는 경직 시간
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
        anim.SetBool("Attack", true); // 애니메이션 실행
        SfxManger.instance.SfxPlay("Ice_Skill_1", clip[0]);
        yield return new WaitForSeconds(1f); // 1초뒤에
        GameObject Skill_1_pos = Instantiate(Pre_Ice_Spike, Ice_Arrow_pos.position, Quaternion.Euler(0, 0, 0)); // 플레이어 위치에 준비 스킬뜨고
        yield return new WaitForSeconds(1f); // 1초뒤에
        
        GameObject Skill_1 = Instantiate(Ice_Arrow, Skill_1_pos.transform.position, Quaternion.Euler(0, 0, 0)); // 플레이어 위치에 스킬 뜸
        Destroy(Skill_1_pos); // 준비 스킬 삭제
        Destroy(Skill_1, 1f); // 1초뒤에 삭제
        anim.SetBool("Attack", false); // 애니메이션 Idle로
        StartCoroutine(RandomPattern());
    }

    
    IEnumerator Second_Attack()
    {
        base.LookPlayer();
        
        anim.SetBool("Attack_2", true);
        SfxManger.instance.SfxPlay("Ice_Skill_explosion", clip[1]);
        yield return new WaitForSeconds(1f); // 1초 뒤에
        GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Skill_pos_2.rotation); //인스턴시에이트
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
        base.LookPlayer();//플레이어 방향 바라보기
        isDash = true;
        DashPos.SetActive(true);
        yield return new WaitForSeconds(1.5f); //패턴 피할 시간
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime); // 보스전방에 DashDir라는 빈 오브젝트 생성해서 추적(전방으로 돌진하게끔) 타겟 포지션으로 하면 이상하게 안됨
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
                    // 체력 감소

                }
            }

    }*/

    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
