using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Anim : Player_Attack
{
    public GameObject self;


    //protected Animator Player_anim;
    //public Transform pos;
    //public Vector2 player_boxSize;
    //public GameObject enemy;

    public GameObject Sword_pos;

    //넉백
    public float Knockback_speed = 3;
    //protected bool isKnockback;
    //public float Kb_delayTime = 2f;

    //protected float Kb_timer = 0f;

    //스킬
    public GameObject Sword_skill;

    //게이지
    //public float Skill_gauge = 0;


    //GameObject[] Enemy_Test;

    protected Rigidbody2D player_rigid;




    public float speed;
    protected Animator move_animator;
    protected SpriteRenderer sprite;
    //private float str = 16;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim = GetComponent<Animator>();
        player_rigid = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
        move_animator = GetComponent<Animator>();
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
    }

    protected virtual void Attack()
    {

        /*if (Input.GetKeyDown(KeyCode.X))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //박스안에 놓여진 모든 오브젝트들을 collider2d[] 배열에 담음
            foreach(Collider2D collider in collider2Ds)
            {
                
                if (collider.tag=="Monster") //Monster 태그와 충돌하면
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
                        if(Kb_timer >= Kb_delayTime)
                        {
                            Kb_timer = 0f;
                            isKnockback = false;
                        }
                    }

                    
                }
            }
            
            Player_anim.SetTrigger("Attack");
            //Vector2 dir = (transform.position - Enemy.transform.position).normalized;
            //player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
        }
        */
        
        if (Input.GetKeyDown(KeyCode.A) /*&& Skill_gauge >= 100*/) //스킬게이지가 100이고 A키를 누르면
        {

            if (self.transform.rotation.eulerAngles.y > 0) // 오른쪽으로 스킬
            {
                Player_anim.SetTrigger("Skill");
                Instantiate(Sword_skill, pos.position, Quaternion.Euler(0, 0, 0));
                Skill_gauge = 0; //게이지 0으로 초기화
            }
            else if(self.transform.rotation.eulerAngles.y == 0) //왼쪽으로 스킬
            {


                Player_anim.SetTrigger("Skill");
                Instantiate(Sword_skill, pos.position, Quaternion.Euler(180, 0, 180));
                Skill_gauge = 0; //게이지 0으로 초기화
            }
            
        }

    }

    


    /*public void Nb()
    {
        Vector2 dir = (transform.position - enemy.transform.position).normalized;
        player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
    }*/
    // Update is called once per frame
    void Update()
    {
        
        //Nb();
        Attack();
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
