using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Test : Status_test
{

    public Transform Monster_Pos;
    public Vector2 Pos_size;
    public float attack_Delay = 0f;

    public LayerMask layer;
    Transform Target;
    Rigidbody2D rb;
    Animator anim;
    bool Mons_Attack = false;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Rotate();
        Monster_Attack();

    }

    void Rotate()
    {
        //for (int i = 0; i < Target.Length; i++)

        if (transform.position.x < Target.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Monster_Attack()
    {
        attack_Delay -= Time.deltaTime;
        if (attack_Delay < 0) attack_Delay = 0;

        Collider2D coll = Physics2D.OverlapBox(Monster_Pos.position, Pos_size, 0, layer);
        if (!Die)
        {
            if (coll)
            {
                if (attack_Delay == 0)
                {
                    Mons_Attack = true;
                    Attack();
                }
            }
        }
    }
    void Attack()
    {
        StartCoroutine(Att());
        //anim.SetTrigger("Attack");
        Debug.Log("플레이어가 공격범위에 들어옴");
        attack_Delay = atkSpeed;
    }
    IEnumerator Att()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Attack");
        Debug.Log("공격");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Monster_Pos.position, Pos_size);
    }
}
