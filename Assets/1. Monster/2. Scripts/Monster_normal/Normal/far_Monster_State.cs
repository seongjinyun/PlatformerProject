using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class far_Monster_State : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    Transform Player;

    GameObject Parent;
    Far_Monster far_monster;

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // 스크립트 비활성화
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Parent = transform.parent.gameObject;
        far_monster = Parent.GetComponent<Far_Monster>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    /*void Update()
    {
        Atk_anim();

    }

    void Atk_anim()
    {
        if (far_monster.canAttack == true)
        {
            animator.SetTrigger("Attack");

        }
    }*/

}
