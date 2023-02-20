using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    

    //���ַ�Ʈ ��ü
    public GameObject Unit_anim;


    //����
    public static float Max_hp = 101f; // �ִ� ü��
    public static float Player_Hp = 100f; //�÷��̾� ü��

    // public SpriteRenderer sr;
    public  float speed;
    
    protected Rigidbody2D Player_rigid;
    protected Transform Player_tr;
    

    //����
    public bool doubleJumpState = false;
    public bool isGround = true;
    public float jumpPower;
    public GameObject jump_effect; //���� ����Ʈ
    public Transform effect_Pos;
    public float jump_Count = 2;
    public bool jump_delay;

    //ȸ�� ����
    /*public float dodge_Distance;
    public float dodge_Time;
    public float dodge_NeedEnergy;
    private float dodge_TimeCheck;
    public float dodge_ButtonTime;          // ȸ�� ��ư�� 2�� ������ �Ǵ� �ð�
    private bool dodge;*/

    //���ַ�Ʈ �ִϸ�����
    public Animator move_animator;

    // �뽬 ����
    public float dash_Speed; //�뽬 �ӵ�
    public bool isDash;
    public float StartDashTimer;

    protected float CurrentDashTimer = 10f;
    protected float Dashdirection;
    protected float movX;

    public bool isDash_Delay = false;
    public float Dash_delayTime = 2f; //�뽬��Ÿ��
    static public float Dash_timer = -5f;

    public bool Time_end = false;

    public GameObject Dash_effect; // �뽬����Ʈ
    public Transform dash_transform;


    //�ϴ� ����
    int Player_Layer, Ground_Layer;

    
    

    protected SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {       
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();       
        sprite = GetComponent<SpriteRenderer>();
        Player_Layer = LayerMask.NameToLayer("Player");
        Ground_Layer = LayerMask.NameToLayer("Ground");
        move_animator = Unit_anim.GetComponent<Animator>();
        
        
        //status = new Stat(); //�����ڵ� �ּ� ���� �����Ǹ� �ٽ� Ȱ��ȭ
        //status = status.SetUnitStat(unit_Code); //�����ڵ� �ּ� ���� �����Ǹ� �ٽ� Ȱ��ȭ
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground" || jump_delay == true)
        {
            jump_Count = 2;
            
        }
    }

    /*public void Jump_t()
    {
        if(jump_Count==0)
        StartCoroutine("JumpDelay");
    }*/
    
    protected virtual void Jump() 
    {
        

        if (jump_Count == 2)
        {
            isGround = true;
            jump_delay = false;
        }
        else
            isGround = false;
        if (isGround)
        {
            doubleJumpState = true;
            //jump_Count = 2;
        }
        


        if (isGround && Input.GetKeyDown(KeyCode.C)) //����
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            
        }else if (doubleJumpState && Input.GetKeyDown(KeyCode.C)) //��������
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJumpState = false;
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            //jump_delay = true;

            if (jump_Count == 0)
            {
                StartCoroutine("JumpDelay");
                //jump_Count = 2;
            }
        }
        


        if (Input.GetKeyDown(KeyCode.C) && Input.GetButton("Vertical")) //�ϴ� ����
        {
            //effecter.rotationalOffset = 180;
            Debug.Log("�Ʒ�����");
            GameObject[] Ground_Layer = GameObject.FindGameObjectsWithTag("Downplatform");//.GetComponent<Down_Platform>().ChangeLayer(); // �Ʒ�Ű + ����Ű ������

            if (Ground_Layer != null)
            {
                Debug.Log("ã��1");
            }
            else
            {
                Debug.Log("��ã��1");
            }
            foreach (GameObject layer in Ground_Layer)
            {
                if (layer.GetComponent<Down_Platform>())
                {
                    Debug.Log("ã��2");
                }
                else
                {
                    Debug.Log("��ã��2");
                }
                layer.GetComponent<Down_Platform>().ChangeLayer();
                
            }
            // �÷��̾�� Downplatform �±׸� ���� ������Ʈ�� ã�Ƽ� �� ������Ʈ�� �ȿ� ��ũ��Ʈ�� �ִ� ChangeLayer�Լ��� �����´�
        }
        

    }
    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(1.8f);
        jump_delay = true;
        //jump_Count = 2;
    }


    /*private void OnTriggerEnter2D(Collider2D collision) // ĳ���Ϳ� ���� �߰��� �ڽ��ݶ��̴��� ���� �浹�ϸ� ĳ���Ͱ� ���� ĸ���ݶ��̴� Ʈ���Ű� true 
    {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision) //���� �߰��� �ڽ��ݶ��̴� Ʈ���Ű� ������ ĸ���ݶ��̴� Ʈ���Ű� false 
    {
        GetComponent<CapsuleCollider2D>().isTrigger = false; 
    }*/


    protected virtual void move() //�θ� Ŭ�������� �ڽĿ��� ����ϴ°� protected virtual--> �����Լ� �θ𿡼� �̹� ��������� �ڽ�Ŭ�������� ��������
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);
            move_animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            move_animator.SetBool("Run", true);
        }
        else
        {
            move_animator.SetBool("Run", false);
        }
    

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += speed * Time.deltaTime * new Vector3(h, v, 0);
        
        
               
    }
    

    

    

    protected virtual void Dash()
    {
        movX = Input.GetAxis("Horizontal");

        Dash_timer -= Time.deltaTime;

        
        if (Dash_timer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Z) && movX != 0) //�÷��̾� �뽬
            {
                /*StartCoroutine(DashCoolTime(5f));

                IEnumerator DashCoolTime(float dash_cool)
                {
                    while(dash_cool > 1.0f)
                    {
                        dash_cool -= Time.deltaTime;
                        yield return new WaitForFixedUpdate();
                    }
                }*/

                GameObject[] monster_change = GameObject.FindGameObjectsWithTag("Monster");

              //�뽬ȸ��
                foreach (GameObject test in monster_change)
                {
                    test.GetComponent<Dash>().Change_dash();
                } 
                

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
                GameObject dash_ef = Instantiate(Dash_effect, dash_transform.position, transform.rotation);
                Destroy(dash_ef, 0.5f);
            }
            else
            {
                Player_rigid.velocity = transform.right * Dashdirection * dash_Speed * -1;
                GameObject dash_ef = Instantiate(Dash_effect, dash_transform.position, transform.rotation);
                Destroy(dash_ef, 0.5f);
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
        if (Player_UsingItem.UsingActiveSpeed == true)
        {
            speed = 12;
        }
        else
        {
            speed = 7;
        }

        move();
        Jump();
        Dash();
        //Player_anim(h); //�ִϸ��̼�
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mons_weapon"))
        {
            Player_Hp -= 10;
            Debug.Log("�ǰ�" + Player_Hp);
            if (Player_Hp <= 0)
            {
                Player_Hp = 100;
                move_animator.SetTrigger("Die");
                //player die
            }
            if(Player_Hp >= Max_hp)
            {
                Player_Hp = 100;
            }
        }
    }
}
