using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chase_far : MonoBehaviour
{

    [SerializeField] // == public 근데 외부 스크립트에서 수정못함
    GameObject face;

    [SerializeField]
    Transform Monster2_castPoint;

    [SerializeField]
    Transform Monster2_Player;

    [SerializeField]
    float Monster2_agroRange; // 어그로범위

    [SerializeField]
    float Monster2_moveSpeed;


    [SerializeField]
    float Monster2_atkDistance;

    [SerializeField]
    GameObject Monster2_bullet;

    public Transform Monster2_bullet_pos;
    public float Monster2_cool;
    public float Monster2_cur;


    Rigidbody2D Monster2_rb2d;

    bool Monster2_isFacingLeft;

    private bool Monster2_isAgro = false;
    private bool Monster2_isSearching;

    public int Monster2_HP;
    // Start is called before the first frame update
    void Start()
    {
        Monster2_rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Monster2_CanSeeMonster2_Player(Monster2_agroRange))
        {
            Monster2_isAgro = true;
        }
        else
        {
            if (Monster2_isAgro)
            {
                if (Monster2_isSearching)
                {
                    Monster2_isSearching = true;
                }
                Invoke("StopChasingMonster2_Player", 3);
            }

        }

        if (Monster2_isAgro)
        {
            Monster2_ChaseMonster2_Player();
        }

    }

    bool Monster2_CanSeeMonster2_Player(float distnace)
    {
        bool val = false;
        float castDist = distnace;

        if (Monster2_isFacingLeft)
        {
            castDist = -distnace;
        }

        Vector2 endPos = Monster2_castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(Monster2_castPoint.position, endPos, 1 << LayerMask.NameToLayer("Water")); // 플레이어 레이어 설정

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Monster2_Player")) // 플레이어일때 원거리 공격.
            {
                val = true;

                if (Vector2.Distance(transform.position, hit.collider.transform.position) < Monster2_atkDistance)
                {
                    if (Monster2_cur <= 0)
                    {
                        Instantiate(Monster2_bullet, Monster2_bullet_pos.position, transform.rotation);

                        Monster2_cur = Monster2_cool;
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * Monster2_moveSpeed);
                    }
                    Monster2_cur -= Time.deltaTime;
                }
            }
            else
            {
                val = false;
            }

            Debug.DrawLine(Monster2_castPoint.position, hit.point, Color.yellow);
        }
        else
        {
            Debug.DrawLine(Monster2_castPoint.position, endPos, Color.blue);
        }
        return val;

    }

    void Monster2_ChaseMonster2_Player()
    {
        if (transform.position.x < Monster2_Player.position.x)
        {
            // enemy is to the left side of the Monster2_Player, so move right
            Monster2_rb2d.velocity = new Vector2(Monster2_moveSpeed, 0);
            //transform.localScale = new Vector2(2, 2); //크기
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Monster2_isFacingLeft = false;
        }
        else
        {
            // enemy is to the left side of the Monster2_Player, so move right
            Monster2_rb2d.velocity = new Vector2(-Monster2_moveSpeed, 0);
            //transform.localScale = new Vector2(-2, 2);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Monster2_isFacingLeft = true;
        }
    }
    void StopChasingMonster2_Player()
    {
        Monster2_isAgro = false;
        Monster2_isSearching = false;
        Monster2_rb2d.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Weapon")) // 웨폰 충돌시 HP감소
        {
            Monster2_HP -= 10;
            if (Monster2_HP <= 0)
            {
                Destroy(gameObject); // 체력 0이 될시 삭제
            }
        }
    }
}
