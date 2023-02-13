using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Shield : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigid_shield;
    public float skill_speed;

    public GameObject enemy;
    

    GameObject[] Enemys;
    protected bool isKnockback;
    void Start()
    {
        rigid_shield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 0.5f);
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
                    collision.transform.Translate(2.0f, 0.4f, 0);

                }
                else

                {
                    isKnockback = true;
                    collision.transform.Translate(-2.0f, 0.4f, 0);

                }
            }

        }
    }
}
