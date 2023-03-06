using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_test : MonoBehaviour
{

    public float Monster_Hp = 10f;
    public float Monster_Damage = 1f;
    public float atkSpeed = 4f;

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
