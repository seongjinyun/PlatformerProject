using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
   // public SpriteRenderer sr;
    public float speed = 3f;
    public float jumpPower;
    Rigidbody2D Player_rigid;
    Transform Player_tr;
    bool doubleJumpState = false;
    bool isGround = true;

    // 대쉬 변수
    private bool canDash = true;
    private bool isDash;
    private float dashPower = 20.0f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;


    
    
    public int prHp = 100; //플레이어 체력
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();
        
        sprite = GetComponent<SpriteRenderer>();
    }


    void Jump() 
    {
        if (Player_rigid.velocity.y == 0)
            isGround = true;
        else
            isGround = false;
        if (isGround)
            doubleJumpState = true;


        if (isGround && Input.GetKeyDown(KeyCode.C))
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }else if (doubleJumpState && Input.GetKeyDown(KeyCode.C))
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJumpState = false;
        }
    }
    

    void move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += speed * Time.deltaTime * new Vector3(h, v, 0);

        if (Input.GetKeyDown(KeyCode.Z)) //플레이어 대쉬
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ENEMY"))
        {
            prHp -= 10;
            if (prHp <= 0)
            {
                Debug.Log("피격");
                //player die
            }
        }
    }*/
}
