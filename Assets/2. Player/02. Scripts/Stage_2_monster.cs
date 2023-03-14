using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : Boss
{
    //public BoxCollider2D HitBox;
    public bool Attack_State = false;
    public float Second_Attack_State = 5f;
    public bool Chase = false;
    public GameObject Attack_Skill_2;
    public Transform self;
    public Transform Skill_pos_2;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        StartCoroutine(MonsterChase());
        Attack();
        //StartCoroutine(Second_Attack());

        if (Chase == true) // 몬스터가 추적하지 않으면 러쉬 쿨타임은 멈춤
        {
            Second_Attack_State -= Time.deltaTime;


            if (Second_Attack_State <= 0f)
            {
                StartCoroutine(Second_Attack());
                Second_Attack_State = 5f;
            }
        }
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
                    Chase = true;
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
                    Chase = false;
                    anim.SetBool("Run", false);
                }
            }
        }


    }
    IEnumerator Second_Attack()
    {
        
        if (self.transform.rotation.eulerAngles.y == 0)
        {
            anim.SetTrigger("Attack2");
            yield return new WaitForSeconds(1f);
            GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Quaternion.Euler(0,0,0));

            Destroy(Skill_2, 1f);
        }
        else if(self.transform.rotation.eulerAngles.y <= -180)
        {
            anim.SetTrigger("Attack2");
            yield return new WaitForSeconds(1f);
            GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Quaternion.Euler(0, 180, 0));
            Destroy(Skill_2, 1f);
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
