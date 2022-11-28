using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    private Rigidbody2D rigid_bullet;
    public float skill_speed = 5.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid_bullet = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rigid_bullet.velocity = transform.right *-1 * skill_speed;

    }
}
