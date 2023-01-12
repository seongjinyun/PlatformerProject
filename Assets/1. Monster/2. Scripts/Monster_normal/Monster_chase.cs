using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chase : MonoBehaviour
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

    Rigidbody2D rb2d;

    bool isFacingLeft;

    public bool isAgro = false;
    private bool isSearching;
    public bool Move_Run = false; 

    public int Monster_HP;

    public Animator Child_Anim;
    public GameObject Child;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Child_Anim = Child.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
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

    bool CanSeePlayer(float distnace) // 레이로 플레이어를 찾음
    {
        bool val = false;
        float castDist = distnace;

        if (isFacingLeft)
        {
            castDist = -distnace;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player")); // 플레이어 레이어 설정

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player")) // 플레이어일때 공격.
            {
                val = true;
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

    void ChasePlayer() // 이동, 회전, 추적 
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
    void StopChasingPlayer() // 멈춤
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
        Child_Anim.SetBool("Run", false);
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
