using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim_Shield : Player_Attack
{
    Animator Shield_Anim;
    public GameObject Shield_Skill;
    public GameObject player;
    protected Rigidbody2D player_rigid;

    public float skillRange = 13f;
    //넉백
    //public float Knockback_speed = 3;
    //protected bool isKnockback;
    //public float Kb_delayTime = 2f;
    //protected float Kb_timer = 0f;

    //게이지
    //public float Skill_gauge = 0;

    //공격 범위
    //public Transform pos;
    //public Vector2 player_boxSize;


    //테스트
    //public GameObject[] Enemy_Test;
    public GameObject[] Enemy_Test1; // 쉴드 스킬 위치 조정


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Enemy");
        player_rigid = GetComponent<Rigidbody2D>();
        Shield_Anim = GetComponent<Animator>();
    }

    void Attack()
    {
        /*if (Input.GetKeyDown(KeyCode.X))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //박스안에 놓여진 모든 오브젝트들을 collider2d[] 배열에 담음
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Monster") //Monster 태그와 충돌하면
                {
                    Skill_gauge += 5;
                    Debug.Log("게이지 + 5");
                    foreach (GameObject monster in Enemy_Test)

                    if (transform.position.x >= monster.transform.position.x && !isKnockback)

                    {
                        isKnockback = true;
                        collider.transform.Translate(2.0f, 0.4f, 0);
                    }
                    else
                    {
                        isKnockback = true;
                        collider.transform.Translate(-2.0f, 0.4f, 0);
                    }
                    if (isKnockback) //넉백 타이머
                    {
                        Kb_timer += Time.deltaTime;
                        if (Kb_timer >= Kb_delayTime)
                        {
                            Kb_timer = 0f;
                            isKnockback = false;
                        }
                    }
                }
            }
            Shield_Anim.SetTrigger("Attack_shield");
            //Vector2 dir = (transform.position - Enemy.transform.position).normalized;
            //player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
        }
        */
        


        Enemy_Test1 = GameObject.FindGameObjectsWithTag("Shield_Skill_pos"); //쉴드 스킬 위치 몬스터 태그
        //List<GameObject> targets = new List<GameObject>(); // 범위 안에 들어온 게임오브젝트 리스트
        if (Input.GetKeyDown(KeyCode.A) && Skill_gauge >= 100)
        {
            bool skillApplied = false; // 스킬이 적용됐는지 확인하는 변수

            foreach (GameObject pos in Enemy_Test1)
            {
                float dist = Vector2.Distance(transform.position, pos.transform.position);

                if (dist <= skillRange)
                {
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, skillRange); // 스킬 범위

                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.CompareTag("Monster"))
                        {
                            Monster_Stats Monster_Hp = collider.gameObject.GetComponent<Monster_Stats>();
                            if (Monster_Hp.Monster_currentHp > 0)
                            {
                                Shield_Anim.SetTrigger("Skill_shield");
                                GameObject She_ = Instantiate(Shield_Skill, pos.transform.position, transform.rotation);
                                Destroy(She_, 1f);
                                skillApplied = true; // 스킬이 적용됐음을 표시
                            }
                        }
                    }
                }
            }

            if (skillApplied)
            {
                Skill_gauge = 0; // 스킬이 한 번 이상 적용됐을 때에만 게이지 초기화
            }
        }






    }




    //Debug.Log("거리 " + dist);



    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Attack();
        //Debug.Log("거리" + distance);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(this.transform.position, skillRange);
    }
}
