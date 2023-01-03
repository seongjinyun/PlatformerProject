using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Spear : MonoBehaviour
{
    private Rigidbody2D rigid_spear;
    public float skill_speed = 5.0f;

    public GameObject explo;

    public GameObject SpawnPos1, SpawnPos2, SpawnPos3, SpawnPos4;
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
        //rigid_spear.velocity = new Vector2(1, -1); // 대각선 창
        //rigid_spear.AddForce(Vector2.left * skill_speed);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explo, SpawnPos1.transform.position, transform.rotation);
            Instantiate(explo, SpawnPos2.transform.position, transform.rotation);
            Instantiate(explo, SpawnPos3.transform.position, transform.rotation);
            Instantiate(explo, SpawnPos4.transform.position, transform.rotation);
            Destroy(gameObject, 1.0f);
            
        }
    }
    
}
