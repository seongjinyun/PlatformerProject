using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chase_far : MonoBehaviour
{

    [SerializeField] // == public �ٵ� �ܺ� ��ũ��Ʈ���� ��������
    GameObject face;

    [SerializeField]
    Transform castPoint; 

    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange; // ��׷ι���

    [SerializeField]
    float moveSpeed; //�̵��ӵ� 


    [SerializeField]
    float Monster_atkDistance; // ���� ���Ÿ� ���� ��Ÿ�

    [SerializeField]
    GameObject Monster_bullet;// ���� �ҷ� or ��ų

    public Transform Bullet_pos; //�ҷ� or ��ų ���� ��ġ
    public float Monster_cool; //��Ÿ��
    public float Monster_cur;
    public bool Monster_longAtk = false;

    public Animator Child_Anim;
    public GameObject Child;
    public bool Move_Run = false;

    Rigidbody2D rb2d;

    bool isFacingLeft;

    private bool isAgro = false;
    private bool isSearching;

    public int Monster_HP;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Child_Anim = Child.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            isAgro = true;
            Child_Anim.SetBool("Run", true);
        }
        else
        {
            if (isAgro)
            {
                if (isSearching)
                {
                    isSearching = true;
                }
                Invoke("StopChasingPlayer", 3);
            }

        }

        if (isAgro)
        {
            ChasePlayer();
        }

    }

    bool CanSeePlayer(float distnace)
    {
        bool val = false;
        float castDist = distnace;

        if (isFacingLeft)
        {
            castDist = -distnace;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player")); // �÷��̾� ���̾� ����

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player")) // �÷��̾��϶� ���Ÿ� ����.
            {
                val = true;
                moveSpeed = 0f;
                if (Vector2.Distance(transform.position, hit.collider.transform.position) < Monster_atkDistance)
                {
                    if (Monster_cur <= 0)
                    {
                        Instantiate(Monster_bullet, Bullet_pos.position, transform.rotation);
                        Child_Anim.SetTrigger("Attack");
                        Monster_cur = Monster_cool;
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * moveSpeed);
                    }
                    Monster_cur -= Time.deltaTime;
                    Monster_longAtk = true; // ���� �� true

                }
                else
                {
                    Monster_longAtk = false; // �ƴϸ� false
                }
            }
            else
            {
                val = false;
            }

            Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }
        moveSpeed = 2f;
        return val;
    }

    void ChasePlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            // enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            //transform.localScale = new Vector2(2, 2); //ũ��
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingLeft = false;
        }
        else
        {
            // enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            //transform.localScale = new Vector2(-2, 2);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingLeft = true;
        }
    }
    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
        Child_Anim.SetBool("Run", false);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player_Weapon")) // ���� �浹�� HP����
        {
            Monster_HP -= 10;
            if (Monster_HP <= 0)
            {
                Child_Anim.SetTrigger("Die");
                Destroy(gameObject, 3f); // ü�� 0�� �ɽ� ����
            }
        }
    }
}
