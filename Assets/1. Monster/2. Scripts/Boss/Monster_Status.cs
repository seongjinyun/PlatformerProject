using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Status : MonoBehaviour
{

    public float Monster_Hp = 10f;
    public float Monster_Damage = 1f; // 공격력
    public float atkSpeed = 4f; // 공격 딜레이

    public bool Die = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Monster_DIe();
    }
    protected virtual void Monster_DIe()
    {
        if (Monster_Hp <= 0)
        {
            Die = true;
        }
    }
}
