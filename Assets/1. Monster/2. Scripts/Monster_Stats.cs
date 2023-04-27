using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Stats : MonoBehaviour
{

    public GameObject Child_anim;
    public Animator anim;
    public Monster_State Child;

    public int Zero_damage = 0;
    public int Monster_Damage = 1;
    public int Monster_hpMax = 10;
    public int Monster_currentHp;

    public bool MonsterDie = false;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
        Child = Child_anim.GetComponent<Monster_State>();

        //Monster_currentHp = Monster_hpMax;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       
    }

    
    public void Monster_TakeDamage(int damage) // 플레이어의 데미지를 받아와서 몬스터의 현재 체력을 깎음
    {
        Monster_currentHp -= damage;
        if (Monster_currentHp <= 0)
        {
            MonsterDie = true;
            anim.SetTrigger("Die");
            //Destroy(gameObject, 1.2f);
            //DIe 애님 실행 및 삭제
            Debug.Log("사망");
        }
    }
}
