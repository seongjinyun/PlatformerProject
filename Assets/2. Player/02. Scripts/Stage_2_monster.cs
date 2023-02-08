using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster : MonoBehaviour
{
    Animator Mons_animator;
    Transform Player;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Mons_animator = GetComponent<Animator>();
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
    }
        
    
}
