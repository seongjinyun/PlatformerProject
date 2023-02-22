using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Stage_Boss : Boss
{
    //public BoxCollider2D HitBox;
    public bool Attack_State = false;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        StartCoroutine(MonsterChase());
        Attack();
    }

    IEnumerator MonsterChase() // 범위 내 플레이어 추적
    {
        yield return null;
        if (!Attack_State)
        {
            if (!MonsterDie)
            {
                collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);
                //Debug.Log($"{Time.time}"+collider2D); 
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
        

    }

    protected virtual void Attack()
    {
        if (Attack_State)
        {
            anim.SetTrigger("Attack");
            anim.SetBool("Run", false);
        }
        else
        {
            
        }


    }
    private void OnDrawGizmos() // 추적 범위
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
