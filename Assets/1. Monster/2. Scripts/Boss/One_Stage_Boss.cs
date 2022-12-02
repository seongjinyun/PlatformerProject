using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Stage_Boss : Boss
{
    //public BoxCollider2D HitBox;
    public Vector2 size;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Chase();
        Attack();
    }
    protected virtual void Chase()
    {
        collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);
        //Debug.Log($"{Time.time}"+collider2D); // �ð����� �浹Ȯ��
        //if (true)
        if (collider2D)
        {
            //Debug.Log(!collider2D.gameObject.CompareTag("Player"));
            if (transform.position.x < Target[0].transform.position.x)
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
    protected virtual void Attack()
    {
        Collider2D Hit = Physics2D.OverlapBox(transform.position, size, Layer_Chase);
        if (Hit.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            anim.SetBool("Run", false);
            Debug.Log(Hit.gameObject.CompareTag("Player"));
        }
        else
        {
            anim.SetBool("Run", true);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);

    }
}
