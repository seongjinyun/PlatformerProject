using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss_Move : Boss
{
    public GameObject[] Target;
    public Transform[] WallCheck;
    public GameObject Child_anim;
    Animator anim;

    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 2f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
    }

    protected void Update()
    {
        Rotate();
        Chase();

        if (!Physics2D.OverlapCircle(WallCheck[0].position, 0.01f, Layer_Wall) &&
            Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) &&
            !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
        {
            Debug.Log("º® Ãæµ¹");
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }

        else if (Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall))
        {
            if (WallCheck[1].position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
            }
        }
        //anim.SetBool("Run", false);
    }
    void Rotate()
    {
        if (transform.position.x < Target[0].transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    protected void Chase()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);
        if (collider2D.gameObject.CompareTag("Player")) // ??
        {
            if (transform.position.x < Target[0].transform.position.x)
            {
                rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
                //anim.SetBool("Run", true);
            }
            else
            {
                rb.velocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
                //anim.SetBool("Run", true);
            }
            //transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);
        }
        else
        {
            //anim.SetBool("Run", false);
        }
    }
}
