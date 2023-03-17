using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosnter_Repeat : Monster_Stats
{
    //반복 몬스터는 바로 스탯으로 연결

    Rigidbody2D rigid;
    public int nextMove;
    public float Speed = 1f;
    public LayerMask Ground_Layer;

    
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        //Invoke("Think", 5);
    }
    protected override void Update()
    {
        base.Update();
        anim.SetBool("Run", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove * Speed, rigid.velocity.y); // move

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, Ground_Layer);
        if (rayHit.collider == null)
        {
            nextMove *= -1; 
            CancelInvoke();

            //Invoke("Think", 5);

        }
        if (nextMove > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health 스크립트 가져오기
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (player_Hp != null)
            {
                
                player_Hp.TakeDamage(Monster_Damage);
                // 체력 감소
                
            }
        }
    }
    /*void Think()
    {
        nextMove = Random.Range(-1, 2);
        Debug.Log(nextMove = Random.Range(-1, 2));

        //Think();
    }*/
}
