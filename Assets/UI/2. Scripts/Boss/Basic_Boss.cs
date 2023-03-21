using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Boss : Monster_Stats
{
    //public float Monster_Hp = 10f;//체력
    //public float Monster_Damage = 1f; // 공격력
    public GameObject DashPos; // 대쉬할때 생기는 콜라이더(보스 전방에만 생김)
    public float speed; //대쉬 속도 변수 
    //public GameObject Child_anim;
    public bool isDash;

    //public Animator anim;
    public Transform Target, DashDir;

    protected override void Start()
    {
        base.Start();
        //anim = Child_anim.GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DashDir = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void LookPlayer()
    {
        if (transform.position.x < Target.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
}
