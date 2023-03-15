using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Monster : Monster_Unit
{
    
    float Stun_CoolTime = 5f;
    public bool Chase = false; // 추적
    

    protected override void Update()
    {
        base.Update();
        StartCoroutine(MonsterChase());
        StartCoroutine(Boss_Jump());


    }
    public IEnumerator MonsterChase() // 범위 내 플레이어 추적
    {
        yield return null;
        if (!MonsterDie)
        {
            collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);

            //Debug.Log($"{Time.time}"+collider2D); // �ð����� �浹Ȯ��
            if (Child.Attack == false)
            {
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
            else
            {
                //Chase = false;
                //anim.SetBool("Run", false);
            }

        }
    }

    IEnumerator Boss_Jump() // 점프
    {

        if (!MonsterDie)
        {
            yield return null;

            if (!Physics2D.OverlapCircle(WallCheck[0].position, 0.01f, Layer_Wall) &&
                 Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) &&
                !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
            {
                //Debug.Log("벽 충돌");
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            }

            else if (Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall))
            {
                if (WallCheck[1].position.x < transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    rb.velocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

    }


}