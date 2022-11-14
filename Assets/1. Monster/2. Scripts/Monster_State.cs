using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public enum State { IDLE, RUN, ATTACK, DIE }
    Rigidbody2D rigid2D;
    Animator animator;

    public GameObject Player;

    public bool longAtk = false;

    float cur = 1f;
    float coolT = 3f;

    GameObject Parent;
    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // 스크립트 비활성화
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Parent = transform.parent.gameObject;
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 플레이어 태그면 어택 애니메이션 실행
        {
            Debug.Log("플레이어 피격");

            animator.SetBool("Run", false);
            animator.SetTrigger("Attack");

            if (!collision.gameObject.CompareTag("Player")) // 없으면 다시 Run
            {
                animator.SetBool("Run", true);
            }

            cur -= Time.deltaTime;
            if (cur <= 0)
            {
                if (Parent.transform.position.x > Player.transform.position.x)
                {
                    Player.transform.Translate(-0.5f, 0.3f, 0);
                    cur = coolT;
                }
                else if (Parent.transform.position.x < Player.transform.position.x)
                {
                    Player.transform.Translate(0.5f, 0.3f, 0);
                    cur = coolT;
                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run", true);

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
