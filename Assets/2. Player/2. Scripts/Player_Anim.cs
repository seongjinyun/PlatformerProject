using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Anim : MonoBehaviour
{
    Animator Player_anim;
    public Transform pos;
    public Vector2 player_boxSize;
    public GameObject enemy;

    //넉백
    public float Knockback_speed = 3;
    private bool isKnockback;
    public float Kb_delayTime = 2f;

    float Kb_timer = 0f;

    //스킬
    public GameObject Sword_skill;
    
    

    Rigidbody2D player_rigid;
    private float str = 16;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim = GetComponent<Animator>();
        player_rigid = GetComponent<Rigidbody2D>();
        
    }

    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //박스안에 놓여진 모든 오브젝트들을 collider2d[] 배열에 담음
            foreach(Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy")
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
                    if (isKnockback)
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            
                Player_anim.SetTrigger("Skill");
                Instantiate(Sword_skill, pos.position, transform.rotation);
            
           
            
               
            
            

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
