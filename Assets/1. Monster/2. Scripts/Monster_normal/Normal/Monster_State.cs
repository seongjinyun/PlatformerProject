using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public enum State { IDLE, RUN, ATTACK, DIE }
    Rigidbody2D rigid2D;
    Animator animator;

    Transform Player;


    public bool longAtk = false; // ���Ÿ� ����
    public bool Attack = false;

    GameObject Parent;
    public bool Damage_chk = false;
    float AttackDelay = 1f; // ���� ������
    float nextAttackTime = 0f; // ���� ���� �ð�

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Parent = transform.parent.gameObject;
        
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

/*    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ) // �÷��̾� �±׸� ���� �ִϸ��̼� ����
        {
            
            //Debug.Log("�÷��̾� �ǰ�");
            if (Time.time >= nextAttackTime)
            {
                if (!Attack)
                {
                    animator.SetTrigger("Attack");
                    animator.SetBool("Run", false);
                    Attack = true;
                    Debug.Log("�÷��̾� ����");
                    StartCoroutine(Knockback());
                }
            }
            else
            {
                Attack = false;

                nextAttackTime = Time.time + AttackDelay;

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Attack = true;
            animator.SetBool("Run", true);
        }
    }*/
    private void isAttack()
    {
        // ���� �ִϸ��̼� ����
        
        Debug.Log("�÷��̾� ����");
        animator.SetTrigger("Attack");
        StartCoroutine(ResetAttack());
        StartCoroutine(Knockback());

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            // �̵� ����
            animator.SetBool("Run", false);
            StartCoroutine(Knockback());
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Attack)
        {
            animator.SetBool("Run", false);
            Attack = true;
            Invoke("isAttack",AttackDelay);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack = false;
            CancelInvoke("isAttack");
            animator.SetBool("Run", true);
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(AttackDelay);
        Attack = false;

    }

    IEnumerator Knockback()
    {
        yield return new WaitForSeconds(0.5f);
        Damage_chk = true;
        if (Parent.transform.position.x < Player.transform.position.x && Player.transform.rotation.y == 0)
        {
            Player.transform.Translate(1.4f, 0.5f, 0);
        }
        else
        {
            Player.transform.Translate(1.4f, 0.5f, 0);
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
            Monster_chase_far monster_chase_far = GameObject.Find("Monster2").GetComponent<Monster_chase_far>(); // ������Ʈ�� ã�� ��ũ��Ʈ�� ������
            if (monster_chase_far.Monster_longAtk == true)  // ���� longAtk�� true�� ���� �ִϸ��̼� �ߵ�
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}
