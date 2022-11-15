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

    //ȸ�� ����
    /*public float dodge_Distance;
    public float dodge_Time;
    public float dodge_NeedEnergy;
    private float dodge_TimeCheck;
    public float dodge_ButtonTime;          // ȸ�� ��ư�� 2�� ������ �Ǵ� �ð�
    private bool dodge;*/

    // �뽬 ����
    public float dash_Speed; //�뽬 �ӵ�
    private bool isDash;
    public float StartDashTimer;

    float CurrentDashTimer;
    float Dashdirection;
    float movX;

    public bool isDash_Delay = false;
    public float Dash_delayTime = 2f; //�뽬��Ÿ��
    public float Dash_timer = 0f;

    public int prHp = 100; //�÷��̾� ü��
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
            if (Input.GetKeyDown(KeyCode.Z) && movX != 0) //�÷��̾� �뽬
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
        if (isDash) //�뽬�� true�̸�
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
        /*if (isDash_Delay == true) //�뽬�����̰� true��
        {
                                             // �뽬Ÿ�̸Ӵ� Time.deltaTime ��ŭ ����
            if (Dash_timer >= Dash_delayTime) //�뽬Ÿ�̸Ӱ� �뽬 ������Ÿ�Ӻ��� Ŀ���ų� ��������
            {
                Dash_timer = 0f; //�ʱ�ȭ
                isDash_Delay = false; //�뽬������ false
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
                Debug.Log("�ǰ�");
                //player die
            }
        }
    }*/
}
