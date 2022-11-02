using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public enum State { IDLE, RUN, ATTACK, DIE }

    Animator animator;

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �÷��̾� �±׸� ���� �ִϸ��̼� ����
        {
            Debug.Log("�÷��̾� �ǰ�");
            animator.SetBool("Run", false);
            animator.SetTrigger("Attack");
            if (!collision.gameObject.CompareTag("Player")) // ������ �ٽ� Run
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
