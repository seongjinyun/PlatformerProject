using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Boss : Basic_Boss
{
    public Transform BreathPos, MeteorPos;
    public GameObject BreathPrepab, MeteorPrepab;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());

    }
    protected override void Update()
    {
        base.Update();
        if (isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Dash", true);
        } 
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
        anim.SetBool("Dash", false);
        DashPos.SetActive(false);
        StartCoroutine(RandomPattern());
    }
    IEnumerator TeleAttack()
    {
        transform.position = Target.transform.position;
        yield return new WaitForSeconds(0.5f);
        base.LookPlayer();
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("Attack", false);
        StartCoroutine(RandomPattern());
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
                    StartCoroutine(FireBreath());
                    break;
                case 1:
                    StartCoroutine(BossDash());
                    break;
                case 2:
                    StartCoroutine(FireMeteor());
                    break;
                case 3:
                    StartCoroutine(TeleAttack());
                    break;
            }
            
        }
    }
    IEnumerator FireBreath()
    {
        LookPlayer();

        anim.SetBool("Breath", true);
        yield return new WaitForSeconds(0.3f);
        GameObject Breath = Instantiate(BreathPrepab, BreathPos.position, BreathPos.rotation);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("Breath", false);
        StartCoroutine(RandomPattern());

    }

    IEnumerator FireMeteor()
    {
        anim.SetBool("Meteor", true);
        GameObject Breath = Instantiate(MeteorPrepab, MeteorPos.position, MeteorPos.rotation);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("Meteor", false);
        StartCoroutine(RandomPattern());


    }
}
