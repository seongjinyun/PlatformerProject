using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public enum State { IDLE, RUN, ATTACK, DIE }

    Animator animator;

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // 스크립트 비활성화
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnCollisionStay2D(Collision2D collision)
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run", true);
    }
}
