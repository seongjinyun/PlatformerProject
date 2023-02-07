using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : MonoBehaviour
{
    Animator Mons_animator;

    // Start is called before the first frame update
    void Start()
    {
        Mons_animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �÷��̾� �±׸� ���� �ִϸ��̼� ����
        {
            //Debug.Log("�÷��̾� �ǰ�");
            Mons_animator.SetTrigger("2_Attack");
            //animator.SetBool("Run", false);

            if (!collision.gameObject.CompareTag("Player")) // ������ �ٽ� Run
            {
                Mons_animator.SetBool("2_Run", true);
            }
        }
    }
            // Update is called once per frame
            void Update()
            {

            }
        
    
}
