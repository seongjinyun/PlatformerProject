using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Animator Player_anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //АјАн
        if (Input.GetKeyDown("x"))
        {
            Player_anim.SetTrigger("isAttack");
        }
    }
}
