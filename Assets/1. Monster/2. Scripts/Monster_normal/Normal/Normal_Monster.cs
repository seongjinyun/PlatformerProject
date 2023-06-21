using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Monster : Monster_Unit
{
    public bool Chase = false; // 추적
    public Transform Attpos;
    public float AttSize;
    public Sprite[] sp_head; // 4개
    public Sprite[] sp_armor; // 4개
    public SpriteRenderer[] Spr; // 0 = 헤드, 1 = 아머,
    int random;
    protected override void Start()
    {
        base.Start();

        spChange();

    }

    void spChange()
    {
        random = Random.Range(0, 3);
        if (random == 1)
        {
            int rand = Random.Range(0, 4);
            Spr[0].sprite = sp_head[rand];
            Spr[1].sprite = sp_armor[rand];
        }
        else if (random == 2)
        {
            int rand = Random.Range(0, 4);
            Spr[0].sprite = sp_head[rand];
            Spr[1].sprite = sp_armor[rand];
        }
        else if (random == 3)
        {
            Spr[0].sprite = null;
            Spr[1].sprite = null;
        }
    }
    protected override void Update()
    {
        base.Update();
        StartCoroutine(MonsterChase());
        StartCoroutine(Boss_Jump());
        Attack_anim();

    }
    public IEnumerator MonsterChase() // 범위 내 플레이어 추적
    {
        yield return null;
        if (!MonsterDie)
        {
            collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);

            //Debug.Log($"{Time.time}"+collider2D); // �ð����� �浹Ȯ��

            if (collider2D)
            {
                if (!Child.Attack)
                {
                    Chase = true;
                    //Debug.Log(!collider2D.gameObject.CompareTag("Player"));
                    if (transform.position.x < Target.transform.position.x)
                    {
                        rb.velocity = new Vector2(transform.localScale.x * speed * 0.1f, rb.velocity.y);
                        //anim.SetBool("Run", true);
                    }
                    else
                    {
                        rb.velocity = new Vector2(-transform.localScale.x * speed * 0.1f, rb.velocity.y);
                        //anim.SetBool("Run", true);
                    }
                    //transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);
                }

            }
            else
            {
                Chase = false;
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
                 Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) )
                //!Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
            {
                Debug.Log("벽 충돌");
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            }

            /*else if (Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall))
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
            }*/
        }
    }

    void Attack_anim() // 몬스터 공격 애님 실행되면 -> Monster_State의 AtkAct()함수가 실행됨
    {
        Collider2D coll = Physics2D.OverlapCircle(Attpos.position, AttSize, Layer_Chase);

        if (!MonsterDie)
        {
            if (coll)
            {
                Child.Attack = true;
                anim.SetTrigger("Attack");

            } // 범위 안에 들어오면 어택 - > 
            else
            {
                Child.Attack = false;
                anim.ResetTrigger("Attack");
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attpos.position, AttSize);
    }
}