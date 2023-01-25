using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Stage_Boss : Boss
{
    public float Rush_CoolTime = 15f;
    bool Chase = false;
    protected override void Update()
    {
        base.Update();
        StartCoroutine(MonsterChase());

        if (Chase == true) // 몬스터가 추적하지 않으면 러쉬 쿨타임은 멈춤
        {
            Rush_CoolTime -= Time.deltaTime;
            if (Rush_CoolTime <= 0f)
            {
                StartCoroutine(Rush());
                Rush_CoolTime = 15f;
            }
        }
    }
    IEnumerator MonsterChase() // 범위 내 플레이어 추적
    {
        yield return null;
        if (!MonsterDie)
        {
            collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);
            //Debug.Log($"{Time.time}"+collider2D); // �ð����� �浹Ȯ��
            //if (true)
            if (collider2D)
            {
                Chase = true;
                //Debug.Log(!collider2D.gameObject.CompareTag("Player"));
                if (transform.position.x < Target.transform.position.x)
                {
                    rb.velocity = new Vector2(transform.localScale.x * speed * MoveSpeed, rb.velocity.y);
                    anim.SetBool("Run", true);
                }
                else
                {
                    rb.velocity = new Vector2(-transform.localScale.x * speed * MoveSpeed, rb.velocity.y);
                    anim.SetBool("Run", true);
                }
                //transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);
            }
            else
            {
                Chase = false;
                anim.SetBool("Run", false);
            }
        }
    }
    IEnumerator Rush() // 돌진 패턴
    {
        yield return new WaitForSeconds(0.1f);
        if (Chase == true)
        {
            //rb.AddForce(transform.right * 10000);
            speed = 3f;
        }
        yield return new WaitForSeconds(1f);
        speed = 0.1f;
    }


    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
