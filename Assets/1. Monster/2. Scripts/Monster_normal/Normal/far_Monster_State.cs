using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class far_Monster_State : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    //Transform Player;

    GameObject Parent;
    
    Far_Monster far;
    public GameObject far_Parent;

    //gameObject.GetComponent<Monster_chase_Test>().enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Parent = transform.parent.gameObject;
        //Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        far = far_Parent.GetComponent<Far_Monster>();
    }

    void AtkAct()
    {
        Debug.Log("���Ÿ� ����");
        far.AtkAction.Invoke();
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