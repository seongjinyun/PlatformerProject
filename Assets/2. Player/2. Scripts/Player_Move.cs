using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    // public SpriteRenderer sr;
    public float speed;
    public float jumpPower;
    Rigidbody2D Player_rigid;
    Transform Player_tr;
    bool doubleJumpState = false;
    bool isGround = true;

    //회피 변수
    /*public float dodge_Distance;
    public float dodge_Time;
    public float dodge_NeedEnergy;
    private float dodge_TimeCheck;
    public float dodge_ButtonTime;          // 회피 버튼을 2번 눌러야 되는 시간
    private bool dodge;*/

    // 대쉬 변수
    public float dash_Speed; //대쉬 속도
    private bool isDash;
    public float StartDashTimer;

    float CurrentDashTimer;
    float Dashdirection;
    float movX;

    public bool isDash_Delay = false;
    public float Dash_delayTime = 2f; //대쉬쿨타임
    public float Dash_timer = 0f;

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
        
               
    }

    void Dash()
    {
        movX = Input.GetAxis("Horizontal");
        Dash_timer -= Time.deltaTime;

        if (Dash_timer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Z) && movX != 0) //플레이어 대쉬
            {
                isDash = true;
                CurrentDashTimer = StartDashTimer;
                Player_rigid.velocity = Vector2.zero;
                Dashdirection = (int)movX;
                /*if (!isDash_Delay)
                {
                    isDash_Delay = true;
                }*/
                //isDash_Delay = true;
                Dash_timer = 5f;
            }
        }
        if (isDash) //대쉬가 true이면
        {
            
            if (transform.rotation.y <= 0)
            { 
                Player_rigid.velocity = transform.right * Dashdirection * dash_Speed; 
            }
            else
            {
                Player_rigid.velocity = transform.right * Dashdirection * dash_Speed * -1;
            }
            CurrentDashTimer -= Time.deltaTime;

            if(CurrentDashTimer <= 0)
            {
                
                isDash = false;
            }
            
        }
        /*if (isDash_Delay == true) //대쉬딜레이가 true면
        {
                                             // 대쉬타이머는 Time.deltaTime 만큼 증가
            if (Dash_timer >= Dash_delayTime) //대쉬타이머가 대쉬 딜레이타임보다 커지거나 같아지면
            {
                Dash_timer = 0f; //초기화
                isDash_Delay = false; //대쉬딜레이 false
            }
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
        Dash();
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
