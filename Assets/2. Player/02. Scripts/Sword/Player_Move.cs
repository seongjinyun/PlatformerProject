using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : AllUnits.Unit
{
    

    //유닛루트 객체
    public GameObject Unit_anim;


    //스텟
    public static float Max_hp = 101f; // 최대 체력
    public static float Player_Hp; //플레이어 체력

    // public SpriteRenderer sr;
    //public  float speed;
    
    protected Rigidbody2D Player_rigid;
    protected Transform Player_tr;
    

    //점프
    public bool doubleJumpState = false;
    public bool isGround = true;
    public float jumpPower;
    public GameObject jump_effect; //점프 이펙트
    public Transform effect_Pos;
    public float jump_Count = 2;
    public bool jump_delay;
    public float downjump_power;


    //유닛루트 애니메이터
    public Animator move_animator;

    // 대쉬 변수
    public float dash_Speed; //대쉬 속도
    public bool isDash;
    public float StartDashTimer;

    protected float CurrentDashTimer = 10f;
    protected float Dashdirection;
    protected float movX;

    public bool isDash_Delay = false;
    public float Dash_delayTime = 2f; //대쉬쿨타임
    static public float Dash_timer = -5f;

    public bool Time_end = false;

    public GameObject Dash_effect; // 대쉬이펙트
    public Transform dash_transform;

    //사운드
    public AudioClip[] clip;

    //하단 점프
    int Player_Layer, Ground_Layer;

    public GameObject shadow;

    protected SpriteRenderer sprite;
    // Start is called before the first frame update


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
        //점프 착지 체크
        int layer_mask = (1 << 6) | (1 << 9); // Ground, Monster 레이어

        if (Player_rigid.velocity.y <= 0) // 떨어지는 중일때
        {
            RaycastHit2D hit = Physics2D.Raycast(Player_rigid.position, Vector2.down, 1f, layer_mask);
            Debug.DrawRay(gameObject.transform.position, Vector2.down, Color.green); // 레이저 쏘고
            if (hit.collider != null && hit.distance <= 0.5) // 레이저가 레이어에 닿으면
            {
                //Debug.Log("레이저 거리" + hit.distance);
                jump_Count = 2; // 점프카운트 2 
                //jump_delay = true;
            }
        }

        // 점프 카운트
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

        if (isGround && Input.GetKeyDown(KeyCode.C)) //점프
        {
            SfxManger.instance.SfxPlay("Player_Jump", clip[0]);
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            
        }else if (doubleJumpState && Input.GetKeyDown(KeyCode.C)) //더블점프
        {
            SfxManger.instance.SfxPlay("Player_Jump", clip[0]);
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJumpState = false;
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            
        }



        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.C) && Input.GetButton("Vertical")) //하단 점프
            {
                SfxManger.instance.SfxPlay("Player_Jump", clip[0]);
                //effecter.rotationalOffset = 180;
                Debug.Log("아래점프");
                GameObject[] Ground_Layer = GameObject.FindGameObjectsWithTag("Downplatform");//.GetComponent<Down_Platform>().ChangeLayer(); // 아래키 + 점프키 누르면
                Player_rigid.AddForce(Vector2.down * downjump_power, ForceMode2D.Impulse);
                Debug.Log("22");
                if (Ground_Layer != null)
                {
                    Debug.Log("찾음1");
                }
                else
                {
                    Debug.Log("못찾음1");
                }
                foreach (GameObject layer in Ground_Layer)
                {
                    if(layer != null)
                    {
                        layer.GetComponent<Down_Platform>().ChangeLayer();
                    }
                }
                // 플레이어는 Downplatform 태그를 붙은 오브젝트를 찾아서 그 오브젝트에 안에 스크립트에 있는 ChangeLayer함수를 가져온다
            }

        }
    }
    
    void NotJump()
    {
        if (GameObject.FindGameObjectWithTag("JumpNot"))
        {
            doubleJumpState = false;
        }

    }

    


    protected virtual void move() //부모 클래스에서 자식에게 상속하는것 protected virtual--> 가상함수 부모에서 이미 만들었지만 자식클래스에서 수정가능
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
        movX = Input.GetAxis("Horizontal");

        Dash_timer -= Time.deltaTime;

        
        if (Dash_timer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Z) && movX != 0) //플레이어 대쉬
            {

                

                GameObject[] monster_change = GameObject.FindGameObjectsWithTag("Monster");

              //대쉬회피
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
        if (isDash) //대쉬가 true이면
        {
            SfxManger.instance.SfxPlay("Player_Dash", clip[1]);
            Player_rigid.velocity = transform.right * Dashdirection * dash_Speed * movX * -1;
            GameObject dash_ef = Instantiate(Dash_effect, dash_transform.position, transform.rotation);
            Destroy(dash_ef, 0.5f);
        }
           
            CurrentDashTimer -= Time.deltaTime;

            if(CurrentDashTimer <= 0)
            {
                
                isDash = false;
                
            }
            
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
        NotJump();
        move();
        Jump();
        Dash();
        
        //Player_anim(h); //애니메이션
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            // Health 스크립트 가져오기
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("몬스터 피격" + Monster_Hp.Monster_currentHp);
                Monster_Hp.Monster_TakeDamage(damage);
                // 체력 감소

            }
        }
    }*/

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster_Attack"))
        {
            Player_Hp -= 10;
            Debug.Log("피격" + Player_Hp);
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
