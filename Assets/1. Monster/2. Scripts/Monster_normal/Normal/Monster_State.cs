using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public enum State { IDLE, RUN, ATTACK, DIE }
    Rigidbody2D rigid2D;
    Animator animator;

    Transform Player;

    public bool Attack = false;

    GameObject Parent;

    Normal_Monster normalMonster;
    public GameObject normal_Parent;
    AllUnits.Unit player_Hp;

    public Transform Attpos;
    public float AttSize;

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // 스크립트 비활성화
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Parent = transform.parent.gameObject;
        
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        normalMonster = normal_Parent.GetComponent<Normal_Monster>();
        player_Hp = Player.GetComponent<AllUnits.Unit>();

    }

    void AtkAct()
    {
        Debug.Log("공격");
        Collider2D coll = Physics2D.OverlapCircle(Attpos.position, AttSize,normalMonster.Layer_Chase);

        if (coll)
        {
            if (player_Hp != null)
            {
                StartCoroutine(Knockback());
                Debug.Log("PlayerHP" + (player_Hp.currentHealth - normalMonster.Monster_Damage));
                player_Hp.TakeDamage(normalMonster.Monster_Damage);
                // 체력 감소
            }
        }
       // normalMonster.AtkAction.Invoke();

    }

    void Anim_start()
    {
        if (normalMonster.Chase == true)
        {
            animator.SetBool("Run", true);
            if (Attack)
            {
                animator.SetBool("Run", false);
            }
            else
            {
                animator.SetBool("Run", true);
            }

        }
        else
        {
            animator.SetBool("Run", false);
            
        }
    }
    
    IEnumerator Knockback()
    {
        yield return null;
        
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
        Anim_start();
    }
}
