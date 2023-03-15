using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : Basic_Boss
{
    //public BoxCollider2D HitBox;
    public bool Attack_State = false;
    public float Second_Attack_State = 5f;
    public bool Chase = false;
    public GameObject Attack_Skill_2;
    public Transform self;
    public Transform Skill_pos_2;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
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

        if (Chase == true) // 몬스터가 추적하지 않으면 러쉬 쿨타임은 멈춤
        {
            Second_Attack_State -= Time.deltaTime;


            if (Second_Attack_State <= 0f)
            {
                StartCoroutine(Second_Attack());
                Second_Attack_State = 5f;
            }
        }
    }


    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //패턴 사이에 나오는 경직 시간

        int ranPattern = Random.Range(0, 4);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(Second_Attack());
                break;
            case 1:
                StartCoroutine(BossDash());
                break;
            case 2:
                StartCoroutine(Ice_Bullet());
                break;
            case 3:
                StartCoroutine(TeleAttack());
                break;
        }
    }

    IEnumerator Ice_Bullet()
    {
        base.LookPlayer();
        yield return new WaitForSeconds(1f);

    }

    IEnumerator Second_Attack()
    {
        base.LookPlayer();
        if (self.transform.rotation.eulerAngles.y == 0)
        {
            anim.SetTrigger("Attack2");
            yield return new WaitForSeconds(1f);
            GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Quaternion.Euler(0,0,0));

            Destroy(Skill_2, 1f);
        }
        else if(self.transform.rotation.eulerAngles.y <= -180)
        {
            anim.SetTrigger("Attack2");
            yield return new WaitForSeconds(1f);
            GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Quaternion.Euler(0, 180, 0));
            Destroy(Skill_2, 1f);
        }
        

    }
    IEnumerator TeleAttack()
    {
        transform.position = Target.transform.position;
        yield return new WaitForSeconds(0.5f);
        base.LookPlayer();
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1.5f);
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
    
    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
