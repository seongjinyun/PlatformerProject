using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    Animator Player_anim;
    // Start is called before the first frame update
    void Start()
    {
        Player_anim = GetComponent<Animator>();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Player_anim.SetTrigger("Attack");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
