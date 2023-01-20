using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim_Shield : MonoBehaviour
{
    Animator Shield_Anim;
    public GameObject enemy;
    public GameObject Shield_Skill;
    public GameObject player;
    public GameObject Shield_pos;

    //넉백
    public float Knockback_speed = 3;
    protected bool isKnockback;
    public float Kb_delayTime = 2f;
    protected float Kb_timer = 0f;

    //게이지
    public float Skill_gauge = 100;

    //공격 범위
    public Transform pos;
    public Vector2 player_boxSize;

    //테스트
    public GameObject[] Enemy_Test;

    

    // Start is called before the first frame update
    void Start()
    {
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Enemy"); 
        //Enemy_Test[0] = enemy;
        Shield_Anim = GetComponent<Animator>();
        float dist = Vector3.Distance(transform.position, enemy.transform.position);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        /*foreach (GameObject mob in Enemy_Test)
        {
            float distance = Vector3.Distance(transform.position, mob.transform.position);
            Debug.Log(this.name + "와 " + mob.name + "의 거리 : " + distance); //거리 구하기
        }*/
    }

    void Attack()
    {

        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //박스안에 놓여진 모든 오브젝트들을 collider2d[] 배열에 담음
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy") //Enemy 태그와 충돌하면
                {
                    Debug.Log("Enemy Attack");
                    if (transform.position.x >= enemy.transform.position.x && !isKnockback)

                    {
                        isKnockback = true;
                        enemy.transform.Translate(0.5f, 0.2f, 0);

                    }
                    else

                    {
                        isKnockback = true;
                        enemy.transform.Translate(-0.5f, 0.2f, 0);

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

                    Skill_gauge += 5;
                    Debug.Log("게이지 + 5");
                }
            }

            Shield_Anim.SetTrigger("Attack_shield");
            //Vector2 dir = (transform.position - Enemy.transform.position).normalized;
            //player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A) && distance <= 13.0f /*&& Skill_gauge >= 100*/ ) //스킬게이지가 100이고 A키를 누르면
        {

            
            Shield_Anim.SetTrigger("Skill_shield");
            GameObject She_ =  Instantiate(Shield_Skill, enemy.transform.position, transform.rotation);
            Destroy(She_, 1f);
            Skill_gauge = 0; //게이지 0으로 초기화
            

        }

        Debug.Log("거리" + distance);
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        
        //Debug.Log("거리" + distance);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
