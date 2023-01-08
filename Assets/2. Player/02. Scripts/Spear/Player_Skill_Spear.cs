using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Spear : MonoBehaviour
{
    private Rigidbody2D rigid_spear;
    public float skill_speed = 5.0f;

    //public GameObject explo;

    

    //float x = 1;
    //float y = -1f;
    //private float angle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        rigid_spear = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigid_spear.AddTorque(angle);
        rigid_spear.velocity = transform.right* -1 * skill_speed;
        Destroy(gameObject, 3f);
        //rigid_spear.velocity = new Vector2(1, -1); // 대각선 창
        //rigid_spear.AddForce(Vector2.left * skill_speed);
        
    }
    
    
}
