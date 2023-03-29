using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Stage_Boss : Basic_Boss
{
    //public BoxCollider2D HitBox;
    public GameObject EarthGrowSkill, Pre_EarthGrow;
    Transform Player_Head;
    public Transform Earth_skill_pos;

    public AudioClip[] clip; // 0 = 돌진, 1 = 스킬

    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
        Player_Head = GameObject.FindGameObjectWithTag("Monster_Skill_Pos").GetComponent<Transform>();

    }

    protected override void Update()
    {
        base.Update();
        if (isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Run", true);
        }

    }

    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //패턴 사이에 나오는 경직 시간

        int ranPattern = Random.Range(0, 1);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(TeleAttack());
                break;
            case 1:
                StartCoroutine(BossDash());
                break;
            case 2:
                StartCoroutine(EarthGrow());
                break;
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
        SfxManger.instance.SfxPlay("Rock_Rush", clip[0]);
        yield return new WaitForSeconds(2.5f);
        isDash = false;
        anim.SetBool("Run", false);
        DashPos.SetActive(false);
        StartCoroutine(RandomPattern());
    }

    IEnumerator EarthGrow()
    {
        base.LookPlayer();
        anim.SetBool("Attack_2", true); // 애니메이션 실행
        SfxManger.instance.SfxPlay("Rock_Skill_1", clip[1]);
        yield return new WaitForSeconds(1f); // 1초뒤에
        GameObject Skill_1_pos = Instantiate(Pre_EarthGrow, Earth_skill_pos.position, Quaternion.Euler(0, 0, 0)); // 플레이어 위치에 준비 스킬뜨고
        yield return new WaitForSeconds(1f); // 1초뒤에
        //Destroy(Skill_1_pos); // 준비 스킬 삭제
        GameObject Skill_1 = Instantiate(EarthGrowSkill, Skill_1_pos.transform.position, Quaternion.Euler(0, 0, 0)); // 플레이어 위치에 스킬 뜸
        Destroy(Skill_1_pos);
        Destroy(Skill_1, 1f); // 1초뒤에 삭제
        anim.SetBool("Attack_2", false); // 애니메이션 Idle로
        StartCoroutine(RandomPattern());

    }
   
    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
