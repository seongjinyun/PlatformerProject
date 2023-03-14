using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Boss : Basic_Boss
{   
    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
    }

    // Update is called once per frame
    protected override void Update()
    {
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
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Attack", false);
        StartCoroutine(RandomPattern());
    }
    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //패턴 사이에 나오는 경직 시간

        int ranPattern = Random.Range(0, 2);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(BossDash());
                break;
            case 1:
                StartCoroutine(TeleAttack());
                break;
        }
    }
}
