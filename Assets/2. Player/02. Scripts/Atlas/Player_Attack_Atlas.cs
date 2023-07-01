using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Atlas : Player_Attack
{
    //public GameObject Spear_skill; //스킬
    public Transform Skill_pos;
    Animator Spear_anim;

    //public Transform pos;
    //public Vector2 player_boxSize;
    public GameObject enemy;

    //넉백
    public float Knockback_speed = 3;
    //protected bool isKnockback;
    //public float Kb_delayTime = 2f;

    //protected float Kb_timer = 0f;

    //스킬
    public GameObject Spear_skill;

    //게이지
    //public float Skill_gauge = 0;

    //GameObject[] Enemy_Test;


    protected Rigidbody2D player_rigid;
    //private float str = 16;

    Quaternion quaternion = Quaternion.Euler(0, 0, -90);

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Spear_anim = GetComponent<Animator>();
        player_rigid = GetComponent<Rigidbody2D>();
        //Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Attack();
        //Spear_skill(); //상속 사용 안할 시 함수
    }
   

    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.A) && Skill_gauge >= 100) //스킬게이지가 100이고 A키를 누르면
        {


            Spear_anim.SetTrigger("Skill_spear");
            Instantiate(Spear_skill, pos.position, transform.rotation);
            Skill_gauge = 0; //게이지 0으로 초기화


        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, player_boxSize);
    }
}
