using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : MonoBehaviour
{
    Animator Mons_animator;
    Transform Player;
    public bool Attack_state = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Mons_animator = GetComponent<Animator>();
    }

    void Attack()
    {
        if (Attack_state)
        {
            Mons_animator.SetTrigger("Attack");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, transform.position) <= 10f)
        {
            Mons_animator.SetBool("2_Run", true);
        }
        else
        {
            Mons_animator.SetBool("2_Run", false);
        }


        Attack();
    }
        
    
}
