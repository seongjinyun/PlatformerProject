using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Transform pos;
    GameObject[] Enemy_Test;
    public Vector2 player_boxSize;
    public bool isKnockback;
    protected float Kb_timer = 0f;
    static public float Skill_gauge = 0;
    protected Animator Player_anim;
    public float Kb_delayTime = 2f;
    protected float Max_Skill_gauge = 101;
    public bool is_delay = false;
    public Transform Parent;

    

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
        Player_anim = GetComponent<Animator>();
    }

    

    public void Attack_gauge()
    {

        if (Input.GetKeyDown(KeyCode.X) && !isKnockback)
        {


            StartCoroutine("Kb_Delay");
            Player_anim.SetTrigger("Attack");
            
        }
        
    }
    IEnumerator Kb_Delay()
    {
        isKnockback = true;
        yield return new WaitForSeconds(0.3f);

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //박스안에 놓여진 모든 오브젝트들을 collider2d[] 배열에 담음
            foreach (Collider2D collider in collider2Ds)
            {


                if (collider.tag == "Monster") //Monster 태그와 충돌하면
                {
                    Skill_gauge += 5;
                    Debug.Log("게이지 + 5");
                    foreach (GameObject monster in Enemy_Test)

                        if (Parent.transform.position.x > monster.transform.position.x /*&& monster.transform.rotation.y <= 0*/) //플레이어 위치가 몬스터위치보다 오른쪽

                        {
                            //isKnockback = true;
                            collider.transform.Translate(2.0f, 0.4f, 0); // 왼쪽 튕겨나감
                            is_delay = true;
                        }
                        else if(Parent.transform.position.x < monster.transform.position.x /*&& monster.transform.rotation.y > 0*/) //플레이어 위치가 몬스터위치보다 왼쪽

                        {
                            //isKnockback = true;
                            collider.transform.Translate(-2.0f, 0.4f, 0); //오른쪽으로 튕겨나감
                            is_delay = true;
                        }

                    //StartCoroutine("Kb_Delay");



                }
            }
            
            yield return new WaitForSeconds(0.5f);
        
        

        isKnockback = false;
    }

   

    // Update is called once per frame
    void Update()
    {
        if(Skill_gauge >= Max_Skill_gauge)
        {
            Skill_gauge = 100;
            //Debug.Log(Skill_gauge);
            

        }
            Attack_gauge();
    }
}
