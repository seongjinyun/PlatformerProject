using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chase_far : MonoBehaviour
{

    [SerializeField] // == public 근데 외부 스크립트에서 수정못함
    GameObject face;

    [SerializeField]
    Transform castPoint;

    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange; // 어그로범위

    [SerializeField]
    float moveSpeed;


    [SerializeField]
    float Monster_atkDistance;

    [SerializeField]
    GameObject Monster_bullet;

    public Transform Bullet_pos;
    public float Monster_cool;
    public float Monster_cur;
    public bool Monster_longAtk = false;


    Rigidbody2D rb2d;

    bool isFacingLeft;

    private bool isAgro = false;
    private bool isSearching;

    public int Monster_HP;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            isAgro = true;
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

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Water")); // 플레이어 레이어 설정

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player")) // 플레이어일때 원거리 공격.
            {
                val = true;

                if (Vector2.Distance(transform.position, hit.collider.transform.position) < Monster_atkDistance)
                {
                    if (Monster_cur <= 0)
                    {
                        Instantiate(Monster_bullet, Bullet_pos.position, transform.rotation);

                        Monster_cur = Monster_cool;
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * moveSpeed);
                    }
                    Monster_cur -= Time.deltaTime;
                    Monster_longAtk = true; // 공격 시 true
                }
                else
                {
                    Monster_longAtk = false; // 아니면 false
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
        return val;

    }

    void ChasePlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            // enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            //transform.localScale = new Vector2(2, 2); //크기
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
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Weapon")) // 웨폰 충돌시 HP감소
        {
            Monster_HP -= 10;
            if (Monster_HP <= 0)
            {
                Destroy(gameObject); // 체력 0이 될시 삭제
            }
        }
    }
}
