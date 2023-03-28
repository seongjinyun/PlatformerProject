using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosnter_Repeat : Monster_Stats
{
    //반복 몬스터는 바로 스탯으로 연결

    Rigidbody2D rigid;
    public int nextMove;
    public float Speed = 1f;
    public LayerMask Ground_Layer;

    public bool testAttacked = false;
    
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        //Invoke("Think", 5);
    }
    protected override void Update()
    {
        base.Update();
        anim.SetBool("Run", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MonsterDie)
        {
            rigid.velocity = new Vector2(nextMove * Speed, rigid.velocity.y); // move

            Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, Ground_Layer);
            if (rayHit.collider == null)
            {
                nextMove *= -1;
                CancelInvoke();

                //Invoke("Think", 5);

            }
            if (nextMove > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!MonsterDie)
        {
            if (collision.gameObject.CompareTag("Player")) // 플레이어가 데미지를 입는 것
            {
                // Health 스크립트 가져오기
                AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
                if (player_Hp != null)
                {

                    //Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - Monster_Damage));
                    //player_Hp.TakeDamage(Monster_Damage);
                    // 체력 감소

                    if(testAttacked == false)
                    {
                        Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - Monster_Damage));
                        player_Hp.TakeDamage(Monster_Damage);
                        
                        // 체력 감소
                        testAttacked = true;
                    }
                    else
                    {
                        Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - Zero_damage));
                        player_Hp.TakeDamage(Zero_damage);
                        StartCoroutine(Zero());
                    }


                }
                /*Monster_Stats stat = collision.gameObject.GetComponent<Monster_Stats>(); // 보스, 몬스터가 데미지 입는 것
                if (stat != null)
                {
                    stat.Monster_TakeDamage(damage);
                }*/

            }
        }
        
    }

    IEnumerator Zero()
    {
        yield return new WaitForSeconds(0.2f);
        testAttacked = false;
    }
    /*void Think()
    {
        nextMove = Random.Range(-1, 2);
        Debug.Log(nextMove = Random.Range(-1, 2));

        //Think();
    }*/
}
