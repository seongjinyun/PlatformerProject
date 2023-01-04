using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Shield : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigid_shield;
    public float skill_speed;

    public GameObject enemy;
    protected bool isKnockback;
    void Start()
    {
        rigid_shield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Attack");
            if (transform.position.x >= enemy.transform.position.x && !isKnockback)

            {
                isKnockback = true;
                enemy.transform.Translate(0.5f, 0.2f, 0);

            }
            else

            {
                isKnockback = true;
                enemy.transform.Translate(-0.5f, 0.2f, 0);

            }
        }
    }
}
