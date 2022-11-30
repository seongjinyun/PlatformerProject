using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // virtual - 자식 오브젝트가 받을 수 있게 해줌
    // Override - 부모에서 virtual이 선언되면 오버라이드를 해야함
    // protected - 상속된 스크립트에서만 접근 가능
    public GameObject[] Target;
    public Transform[] WallCheck;
    public GameObject Child_anim;
    public Animator anim;

    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 10f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;

    protected virtual void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        
        Rotate();


        if (!Physics2D.OverlapCircle(WallCheck[0].position, 0.01f, Layer_Wall) &&
            Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) &&
            !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
        {
            //Debug.Log("벽 충돌");
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
}
