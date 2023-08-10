using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : AllUnits.Unit
{
    

    //���ַ�Ʈ ��ü
    public GameObject Unit_anim;


    //����
    public static float Max_hp = 101f; // �ִ� ü��
    public static float Player_Hp; //�÷��̾� ü��

    // public SpriteRenderer sr;
    //public  float speed;
    
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
    public float downjump_power;


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

    //����
    public AudioClip[] clip;

    //�ϴ� ����
    int Player_Layer, Ground_Layer;

    public GameObject shadow;

    public GameObject Me;

    // Start is called before the first frame update

    public float dash_gravity;

    bool dash = true;

    protected override void Start()
    {
        base.Start();
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();       
        sprite = GetComponent<SpriteRenderer>();
        Player_Layer = LayerMask.NameToLayer("Player");
        Ground_Layer = LayerMask.NameToLayer("Ground");
        move_animator = Unit_anim.GetComponent<Animator>();
        

    }

    /*protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground" || jump_delay == true)
        {
            jump_Count = 2;
            
        }
    }*/

    
    
    protected virtual void Jump() 
    {
        //���� ���� üũ
        int layer_mask = (1 << 6) | (1 << 9); // Ground, Monster ���̾�

        if (Player_rigid.velocity.y <= 0) // �������� ���϶�
        {
            RaycastHit2D hit = Physics2D.Raycast(Player_rigid.position, Vector2.down, 1f, layer_mask);
            Debug.DrawRay(gameObject.transform.position, Vector2.down, Color.green); // ������ ���
            if (hit.collider != null && hit.distance <= 0.5) // �������� ���̾ ������
            {
                //Debug.Log("������ �Ÿ�" + hit.distance);
                jump_Count = 2; // ����ī��Ʈ 2 
                //jump_delay = true;
            }
        }

        // ���� ī��Ʈ
        if (jump_Count == 2)
        {
            isGround = true;
        }
        else
            isGround = false;
        if (isGround)
        {
            doubleJumpState = true;
            //jump_Count = 2;
        }

        if (isGround)
        {
            shadow.SetActive(true);
        }
        else
            shadow.SetActive(false);

        if (isGround && Input.GetKeyDown(KeyCode.Space)) //����
        {
            SfxManger.instance.SfxPlay("Player_Jump", clip[0]);
            Player_rigid.velocity = new Vector2(Player_rigid.velocity.x, jumpPower);
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            
        }else if (doubleJumpState && Input.GetKeyDown(KeyCode.Space)) //��������
        {
            SfxManger.instance.SfxPlay("Player_Jump", clip[0]);
            Player_rigid.velocity = new Vector2(Player_rigid.velocity.x, jumpPower);
            doubleJumpState = false;
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            
        }



        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetButton("Vertical")) //�ϴ� ����
            {
                isGround = false;
                SfxManger.instance.SfxPlay("Player_Jump", clip[0]);
                //effecter.rotationalOffset = 180;
                //Debug.Log("�Ʒ�����");
                GameObject[] Ground_Layer = GameObject.FindGameObjectsWithTag("Downplatform");//.GetComponent<Down_Platform>().ChangeLayer(); // �Ʒ�Ű + ����Ű ������
                Player_rigid.AddForce(Vector2.down * downjump_power, ForceMode2D.Impulse);
                //Debug.Log("22");
                if (Ground_Layer != null)
                {
                    //Debug.Log("ã��1");
                }
                else
                {
                    //Debug.Log("��ã��1");
                }
                foreach (GameObject layer in Ground_Layer)
                {
                    if(layer != null)
                    {
                        layer.GetComponent<Down_Platform>().ChangeLayer();
                    }
                }
                // �÷��̾�� Downplatform �±׸� ���� ������Ʈ�� ã�Ƽ� �� ������Ʈ�� �ȿ� ��ũ��Ʈ�� �ִ� ChangeLayer�Լ��� �����´�
            }

        }
    }
    
    void NotJump() //���� ���� �ȵǰ� (�̷θ�)
    {
        if (GameObject.FindGameObjectWithTag("JumpNot"))
        {
            doubleJumpState = false;
            dash = false;
        }

    }

    


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
        transform.position += speed * Time.deltaTime * new Vector3(h, 0, 0);

    }
    

    

    

    protected virtual void Dash()
    {
        movX = Input.GetAxisRaw("Horizontal");

        Dash_timer -= Time.deltaTime;

        
        if (Dash_timer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && movX != 0) //�÷��̾� �뽬
            {
                GameObject[] monster_change = GameObject.FindGameObjectsWithTag("Monster");
                isDash = true;
                //�뽬ȸ��
                foreach (GameObject test in monster_change)
                {
                    test.GetComponent<Dash>().Change_dash();
                } 
                

                
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
            StartCoroutine(dash_dash());
            
        }
           
            CurrentDashTimer -= Time.deltaTime;

            if(CurrentDashTimer <= 0)
            {
                isDash = false;
            }
            
        }
    
    IEnumerator dash_dash()
    {
        SfxManger.instance.SfxPlay("Player_Dash", clip[1]);
        Player_rigid.velocity = transform.right * Dashdirection * dash_Speed * movX * -1;
        GameObject dash_ef = Instantiate(Dash_effect, dash_transform.position, transform.rotation);
        Destroy(dash_ef, 0.5f);

        float original = Player_rigid.gravityScale;
        Player_rigid.gravityScale = 0f;
        yield return new WaitForSeconds(dash_gravity);
        Player_rigid.gravityScale = original;
    }

    


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Player_UsingItem.UsingActiveSpeed == true)
        {
            speed = 14;
        }
        else
        {
            speed = 11;
        }

        if(currentHealth < 1)
        {
            BoolManager.PlayerDie = true;
        }
        else if(currentHealth > 1)
        {
            BoolManager.PlayerDie = false;
        }
        NotJump();
        move();
        Jump();
        if (dash)
        {
            Dash();
        }

        if (BoolManager.Ending == true) // 엔딩씬일때 스크립트 중지
        {
            this.GetComponent<Player_Move>().enabled = false;
        }


        //Player_anim(h); //�ִϸ��̼�
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            // Health ��ũ��Ʈ ��������
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("���� �ǰ�" + Monster_Hp.Monster_currentHp);
                Monster_Hp.Monster_TakeDamage(damage);
                // ü�� ����

            }
        }
    }*/

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster_Attack"))
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
    }*/
}
