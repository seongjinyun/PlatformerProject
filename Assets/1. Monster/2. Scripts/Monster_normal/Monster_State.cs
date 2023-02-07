using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public enum State { IDLE, RUN, ATTACK, DIE }
    Rigidbody2D rigid2D;
    Animator animator;

    Transform Player;


    public bool longAtk = false; // 원거리 공격
    public bool Attack = false;

    float cur = 1f;
    float coolT = 3f;

    GameObject Parent;
    Final_Stage_Boss Parent2;

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // 스크립트 비활성화
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Parent = transform.parent.gameObject;
        Parent2 = Parent.GetComponent<Final_Stage_Boss>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 플레이어 태그면 어택 애니메이션 실행
        {
            //Debug.Log("플레이어 피격");
            Attack = true;
            animator.SetTrigger("Attack");

            animator.SetBool("Run", false);

            cur -= Time.deltaTime;
            if (cur <= 0) // 넉백
            {
                if (Parent.transform.position.x > Player.transform.position.x)
                {
                    Player.transform.Translate(-1f, 0.5f, 0);
                    cur = coolT;
                }
                else if (Parent.transform.position.x < Player.transform.position.x)
                {
                    Player.transform.Translate(1f, 0.5f, 0);
                    cur = coolT;
                }

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // Radius 수치 변경하면 여기서도 변경해줘야함
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Attack = false;
            animator.SetBool("Run", true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        long_Atk();
        //melee_Atk();
    }
    void long_Atk()
    {
        if (longAtk == true)
        { 
            Monster_chase_far monster_chase_far = GameObject.Find("Monster2").GetComponent<Monster_chase_far>(); // 오브젝트를 찾아 스크립트를 가져옴
            if (monster_chase_far.Monster_longAtk == true)  // 몬스터 longAtk가 true시 공격 애니메이션 발동
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}
