using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chase_Test : MonoBehaviour
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

    private bool isAgro = false;
    private bool isSearching;
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

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Water"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
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


    void ChasePlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            // enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(2, 2); //크기
            isFacingLeft = false;
        }
        else
        {
            // enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-2, 2); 
            isFacingLeft = true;
        }
    }
    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
    }
}
