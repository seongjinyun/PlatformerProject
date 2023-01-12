using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Stage_Boss : Boss
{
    protected override void Update()
    {
        base.Update();
        StartCoroutine(MonsterChase());
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
                //Debug.Log(!collider2D.gameObject.CompareTag("Player"));
                if (transform.position.x < Target.transform.position.x)
                {
                    rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
                    anim.SetBool("Run", true);
                }
                else
                {
                    rb.velocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
                    anim.SetBool("Run", true);
                }
                //transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
    }
    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
