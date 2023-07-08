using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Stage_Boss : Basic_Boss
{
    //public BoxCollider2D HitBox;
    public GameObject EarthGrowSkill, Pre_EarthGrow; // 2번째 스킬
    public GameObject EarthGrow_1, EarthGrow_2, EarthGrow_3;
    Transform Player_Head;
    public Transform Earth_skill_pos_1, Earth_skill_pos_1_1, Earth_skill_pos_2, Earth_skill_pos_2_2, 
        Earth_skill_pos_3, Earth_skill_pos_3_3, Earth_Bullet_Pos; //락 스킬 올라오는 transform 1,2,3  // 바위 굴러가는 포지션
    public GameObject EarthBullet; // 바위

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
        if (MonsterDie)
        {
            BoolManager.FirstStageBossDie = true;
            isDash = false;
        }
        
    }

    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //패턴 사이에 나오는 경직 시간
        if (!MonsterDie)
        {
            int ranPattern = Random.Range(0, 1);
            switch (ranPattern)
            {
                case 0:
                    StartCoroutine(EarthRock());
                    break;
                case 1:
                    StartCoroutine(EarthGrow());
                    break;
                case 2:
                    StartCoroutine(BossDash());
                    break;
                case 3:
                    StartCoroutine(TeleAttack());
                    break;
            }
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
        SfxManger.instance.SfxPlay("Rock_Rush", clip[0]);
        DashPos.SetActive(true);
        yield return new WaitForSeconds(1.5f); //패턴 피할 시간
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime); // 보스전방에 DashDir라는 빈 오브젝트 생성해서 추적(전방으로 돌진하게끔) 타겟 포지션으로 하면 이상하게 안됨
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
        GameObject Skill_1_pos = Instantiate(EarthGrow_1, Earth_skill_pos_1.position, Quaternion.Euler(0, 0, 0)); // 첫번째 위치
        GameObject Skill_1_1_pos = Instantiate(EarthGrow_1, Earth_skill_pos_1_1.position, Quaternion.Euler(0, 0, 0)); // 첫번째 위치
        yield return new WaitForSeconds(0.5f); // 0.5초뒤에
        //Destroy(Skill_1_pos); // 준비 스킬 삭제
        GameObject Skill_2_pos = Instantiate(EarthGrow_2, Earth_skill_pos_2.position, Quaternion.Euler(0, 0, 0)); // 두번째 위치
        GameObject Skill_2_2_pos = Instantiate(EarthGrow_2, Earth_skill_pos_2_2.position, Quaternion.Euler(0, 0, 0)); // 두번째 위치
        yield return new WaitForSeconds(0.5f); // 0.5초뒤에
        GameObject Skill_3_pos = Instantiate(EarthGrow_3, Earth_skill_pos_3.position, Quaternion.Euler(0, 0, 0)); // 세번째 위치
        GameObject Skill_3_3_pos = Instantiate(EarthGrow_3, Earth_skill_pos_3_3.position, Quaternion.Euler(0, 0, 0)); // 세번째 위치

        //GameObject Skill_1 = Instantiate(EarthGrowSkill, Skill_1_pos.transform.position, Quaternion.Euler(0, 0, 0)); // 플레이어 위치에 스킬 뜸
        Destroy(Skill_1_pos, 0.5f);
        Destroy(Skill_1_1_pos, 0.5f);
        Destroy(Skill_2_pos, 0.5f);
        Destroy(Skill_2_2_pos, 0.5f);
        Destroy(Skill_3_pos, 0.5f);
        Destroy(Skill_3_3_pos, 0.5f);
        //Destroy(Skill_1, 2f); // 1초뒤에 삭제
        anim.SetBool("Attack_2", false); // 애니메이션 Idle로
        StartCoroutine(RandomPattern());

    }

    IEnumerator EarthRock()
    {
        base.LookPlayer();
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.3f);
        GameObject Skill_Bullet = Instantiate(EarthBullet, Attack_Pos.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Attack", false);
        Destroy(Skill_Bullet, 3.5f);
        StartCoroutine(RandomPattern());
    }
   
    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
