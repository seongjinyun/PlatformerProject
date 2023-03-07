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
    public static float Player_Hp = 100f; //플레이어 체력

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

    //회피 변수
    /*public float dodge_Distance;
    public float dodge_Time;
    public float dodge_NeedEnergy;
    private float dodge_TimeCheck;
    public float dodge_ButtonTime;          // 회피 버튼을 2번 눌러야 되는 시간
    private bool dodge;*/

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


    //하단 점프
    int Player_Layer, Ground_Layer;

    
    

    protected SpriteRenderer sprite;
    // Start is called before the first frame update
    protected override void Start()
    {       
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

        RaycastHit2D hit = Physics2D.Raycast(Player_rigid.position, Vector2.down, 1f, layer_mask);
        Debug.DrawRay(gameObject.transform.position, Vector2.down * hit.distance, Color.green);
        //Player_rigid.velocity.y == 0
        if (hit.collider != null) // 
        {
            if (Player_rigid.velocity.y == 0) // 
            {
                if (hit.distance <= 0) // hit 거리가 0보다 작거나 같으면
                {
                    jump_Count = 2; // 점프카운트 2 
                }
                //jump_delay = true;
            }
        }

        // 점프 카운트
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
        


        if (isGround && Input.GetKeyDown(KeyCode.C)) //점프
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            
        }else if (doubleJumpState && Input.GetKeyDown(KeyCode.C)) //더블점프
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJumpState = false;
            GameObject jump_ef = Instantiate(jump_effect, effect_Pos.position, effect_Pos.rotation);
            Destroy(jump_ef, 0.5f);
            jump_Count--;
            

            
        }
        


        if (Input.GetKeyDown(KeyCode.C) && Input.GetButton("Vertical")) //하단 점프
        {
            //effecter.rotationalOffset = 180;
            Debug.Log("아래점프");
            GameObject[] Ground_Layer = GameObject.FindGameObjectsWithTag("Downplatform");//.GetComponent<Down_Platform>().ChangeLayer(); // 아래키 + 점프키 누르면

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
                if (layer.GetComponent<Down_Platform>())
                {
                    Debug.Log("찾음2");
                }
                else
                {
                    Debug.Log("못찾음2");
                }
                layer.GetComponent<Down_Platform>().ChangeLayer();
                
            }
            // 플레이어는 Downplatform 태그를 붙은 오브젝트를 찾아서 그 오브젝트에 안에 스크립트에 있는 ChangeLayer함수를 가져온다
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
        transform.position += speed * Time.deltaTime * new Vector3(h, v, 0);
        
        
               
    }
    

    

    

    protected virtual void Dash()
    {
        movX = Input.GetAxis("Horizontal");

        Dash_timer -= Time.deltaTime;

        
        if (Dash_timer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Z) && movX != 0) //플레이어 대쉬
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
        //Player_anim(h); //애니메이션
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mons_weapon"))
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
    }
}
