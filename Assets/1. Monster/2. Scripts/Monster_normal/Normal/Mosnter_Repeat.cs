using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosnter_Repeat : Monster_Stats
{
    //�ݺ� ���ʹ� �ٷ� �������� ����

    Rigidbody2D rigid;
    public int nextMove;
    public float Speed = 1f;
    public LayerMask Ground_Layer;
    public Transform WallCheck;

    float delay = 0;

    public Sprite[] sp_head; // 4��
    public Sprite[] sp_armor; // 4��
    public SpriteRenderer[] Spr; // 0 = ���, 1 = �Ƹ�,
    int random;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spChange();
    }
    void spChange()
    {
        random = Random.Range(0, 3);
        if (random == 1)
        {
            int rand = Random.Range(0, 4);
            Spr[0].sprite = sp_head[rand];
            Spr[1].sprite = sp_armor[rand];
        }
        else if (random == 2)
        {
            int rand = Random.Range(0, 4);
            Spr[0].sprite = sp_head[rand];
            Spr[1].sprite = sp_armor[rand];
        }
        else if (random == 3)
        {
            Spr[0].sprite = null;
            Spr[1].sprite = null;
        }
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

        if (MonsterDie)
        {
            this.gameObject.layer = 8;
            Destroy(gameObject, 1.5f);
        }

        delay -= Time.deltaTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MonsterDie)
        {
            rigid.velocity = new Vector2(nextMove * Speed, rigid.velocity.y); // move

            Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, Ground_Layer);

            if (rayHit.collider == null || Physics2D.OverlapCircle(WallCheck.position, 0.01f, Ground_Layer))
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
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!MonsterDie)
        {
            if (collision.gameObject.CompareTag("Player")) // �÷��̾ �������� �Դ� ��
            {
                // Health ��ũ��Ʈ ��������
                AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
                if (player_Hp != null)
                {
                    //Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - Monster_Damage));
                    //player_Hp.TakeDamage(Monster_Damage);
                    // ü�� ����
                    if (delay <= 0f)
                    {
                        Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - Monster_Damage));
                        player_Hp.TakeDamage(Monster_Damage);
                        delay = 1f;
                    }
                }
                /*Monster_Stats stat = collision.gameObject.GetComponent<Monster_Stats>(); // ����, ���Ͱ� ������ �Դ� ��
                if (stat != null)
                {
                    stat.Monster_TakeDamage(damage);
                }*/
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
