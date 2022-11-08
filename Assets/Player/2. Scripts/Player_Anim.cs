using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Anim : MonoBehaviour
{
    Animator Player_anim;
    public Transform pos;
    public Vector2 player_boxSize;
    public GameObject enemy;
    
    Rigidbody2D player_rigid;
    private float str = 16;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim = GetComponent<Animator>();
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
                   
                }
            }
            
            Player_anim.SetTrigger("Attack");
            //Vector2 dir = (transform.position - Enemy.transform.position).normalized;
            //player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Player_anim.SetTrigger("Skill");
        }

    }
    public void Nb()
    {
        Vector2 dir = (transform.position - enemy.transform.position).normalized;
        player_rigid.AddForce(dir * str, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        Nb();
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
