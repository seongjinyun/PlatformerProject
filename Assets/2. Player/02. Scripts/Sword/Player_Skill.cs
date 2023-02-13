using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    private Rigidbody2D rigid_bullet;
    public float skill_speed = 5.0f;
    GameObject[] Enemys;
    protected bool isKnockback;

    // Start is called before the first frame update
    void Start()
    {
        rigid_bullet = GetComponent<Rigidbody2D>();
        Enemys = GameObject.FindGameObjectsWithTag("Monster");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            foreach (GameObject monster in Enemys)
            {
                if (transform.position.x >= monster.transform.position.x && !isKnockback)

                {
                    isKnockback = true;
                    monster.transform.Translate(2.0f, 0.4f, 0);

                }
                else

                {
                    isKnockback = true;
                    monster.transform.Translate(-2.0f, 0.4f, 0);

                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //rigid_bullet.velocity = transform.right *-1 * skill_speed;
        Destroy(gameObject,0.5f);
    }
    
}
