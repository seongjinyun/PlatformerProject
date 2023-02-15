using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{

    [SerializeField]
    protected int Attack_power;
    [SerializeField]
    protected float Special_Attack;
    [SerializeField]
    protected float Move_speed;


    public int Attack { get { return Attack_power; } set { Attack_power = value; } }
    public float SpecialAttack { get { return Special_Attack; } set { Special_Attack = value; } }
    public float MoveSpeed { get { return Move_speed; } set { Move_speed = value; } }



    // Start is called before the first frame update
    void Start()
    {
        Attack_power = 1;
        Special_Attack = 3.0f;
        Move_speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
