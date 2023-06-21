using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Pattern : MonoBehaviour
{   
    public enum Atk_Pattern { Bottom_Atk, Rush_Atk }

    private bool isAttacking = false;
    Vector3 playerPos;
    Vector3 whereToAtk;
    public GameObject warning;
    public GameObject Atk1;

    public bool Skill = false;

    public float ColTime = 20f;
    public float CurTime = 0f;

    void Update()
    {
        
        //Debug.Log(ColTime);
        if (ColTime <= CurTime)
        {
            ColTime = 5f;
            if (Skill == true)
            {
                StartCoroutine("BeforeAttack");
            }
        }
    }
    //몬스터 하위에 빈 프로젝트를 만들어 콜라이더를 넣고 범위를 지정

    private void OnTriggerStay2D(Collider2D other) // 플레이어 태그 접촉시 코루틴 실행
    {
        if (other.tag == "Monster_Skill_Pos")
        {
            playerPos = other.transform.position; // 접촉된 위치를 Pos에 넣어줌
            Skill = true;
            //            StartCoroutine("BeforeAttack");
            ColTime -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Monster_Skill_Pos")
        {
            Skill = false;
        }
    }
    // OntriggerStay는 프레임 단위로 실행되기 때문에 코루틴을 이용
    // isAttacking 변수를 이용해 false일때만 공격을 하도록 설정
    IEnumerator BeforeAttack()
    {
        if (isAttacking == false)
        {
            Atk_Pattern atk_Pattern = Atk_Pattern.Bottom_Atk;
            if (atk_Pattern == Atk_Pattern.Bottom_Atk)
            {
                whereToAtk = playerPos;
                isAttacking = true;
                //Debug.Log("감지한 위치 : " + whereToAtk);
                Instantiate(warning, whereToAtk, transform.rotation);
                // 생성 (warning 프리팹에 2초뒤 삭제되는 Destroy를 넣어줌 - pattern스크립트)
                yield return new WaitForSeconds(1f);
                StartCoroutine("Bottom_Attack");
            }
        }
    }

    IEnumerator Bottom_Attack() // 공격
    {
        Instantiate(Atk1, whereToAtk, transform.rotation);
        yield return new WaitForSeconds(1f);
        //Debug.Log("공격 끝남");
        isAttacking = false;
    }

}
