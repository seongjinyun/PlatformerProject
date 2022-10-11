using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Player_maxSpeed;
    public float Player_jumpPower;
    Rigidbody2D Player_rigid;
    Transform Player_transform;
    //SpriteRenderer Player_spriteRenderer;
    Animator Player_anim;
    private float Player_maxjump = 2;
    private float Player_jumpcount;
    bool Player_isjumping;
   
    private void Awake()
    {
        Player_rigid = GetComponent<Rigidbody2D>();
        //Player_spriteRenderer = GetComponent<SpriteRenderer>();
        Player_anim = GetComponent<Animator>();
        Player_transform = GetComponent<Transform>();
    }
    private void Update()
    {

        Jump();

        //공격
        if (Input.GetKeyDown("x"))
        {
            Player_anim.SetTrigger("isAttack");
        }

        //멈추는 속도
        if (Input.GetButtonUp("Horizontal"))
        {           
            Player_rigid.velocity = new Vector2(Player_rigid.velocity.normalized.x * 0.5f, Player_rigid.velocity.y);
        }

        //방향 전환
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Player_spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; 
            Player_transform.localScale = new Vector3(-2, 2, 2);
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player_transform.localScale = new Vector3(2, 2, 2);
        }
        

            //애니메이션
            if (Mathf.Abs(Player_rigid.velocity.x) < 0.3)
        {
            Player_anim.SetBool("isWalking", false);
        }
        else
        {
            Player_anim.SetBool("isWalking", true);
        }
    }
    void Jump()
    {
        //점프
        if (Input.GetButtonDown("Jump"))
        {
            if (Player_isjumping == false)
            {
                if (Player_jumpcount > 0)
                {
                    Player_rigid.AddForce(Vector2.up * Player_jumpPower, ForceMode2D.Impulse);
                    Player_isjumping = true;
                   
                    Player_jumpcount--;
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Player_isjumping = false;
            Player_jumpcount = Player_maxjump;
        }
    }
    /*private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(Player_rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        Debug.DrawRay(Player_rigid.position, Vector3.down * 0.1f, Color.red);

        if (Physics2D.Raycast(Player_rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform")))
        {
            if(hit.transform.tag != null)
            {
                ground = true;
                return;
            }
        }
        ground = false;

    }*/


    private void FixedUpdate()
    {
        //움직이기
        float h = Input.GetAxis("Horizontal");
        Player_rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        
        if(Player_rigid.velocity.x > Player_maxSpeed) //Right Max Speed
        {
            Player_rigid.velocity = new Vector2(Player_maxSpeed, Player_rigid.velocity.y);
        }else if (Player_rigid.velocity.x < Player_maxSpeed * (-1))
        {
            Player_rigid.velocity = new Vector2(Player_maxSpeed * (-1), Player_rigid.velocity.y);

            //Landing platform
            if(Player_rigid.velocity.y < 0)
            {
                Debug.DrawRay(Player_rigid.position, Vector3.down, new Color(0, 1, 0));

                RaycastHit2D rayHit = Physics2D.Raycast(Player_rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

                if (rayHit.collider != null)
                {
                    
                        
                }
                
            }
            
        }
    }
}
