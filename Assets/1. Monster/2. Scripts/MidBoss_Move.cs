using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss_Move : MonoBehaviour
{
    public GameObject[] Target;
    public Transform[] WallCheck;
    public float speed = 0.5f;
    public float Radius = 2f;
    public float JumpPower = 3f;
    Rigidbody2D rb;
    public LayerMask Layer_Wall;
    public LayerMask Layer_Chase;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);
        if (collider2D.gameObject.CompareTag("Player"))
        {
            transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);
        }

        //transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);


        if (!Physics2D.OverlapCircle(WallCheck[0].position, 0.01f, Layer_Wall) &&
            Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) &&
            !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
        {
            Debug.Log("º® Ãæµ¹");
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }

        else if (Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall))
        {/*
            if (transform.position.x > Target[0].transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }*/
        }
    }
}
