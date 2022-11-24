using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chase : MonoBehaviour
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
    float moveSpeed;

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

    bool CanSeePlayer(float distnace) // ���̷� �÷��̾ ã��
    {
        bool val = false;
        float castDist = distnace;

        if (isFacingLeft)
        {
            castDist = -distnace;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Water")); // �÷��̾� ���̾� ����

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player")) // �÷��̾��϶� ����.
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

    void ChasePlayer() // �̵�, ȸ��, ���� 
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
    void StopChasingPlayer() // ����
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter(Collision coll) 
    {
        if (coll.gameObject.CompareTag("Weapon")) // ���� �浹�� HP����
        {
            Monster_HP -= 10;
            if (Monster_HP <= 0)
            {
                Destroy(gameObject); // ü�� 0�� �ɽ� ����
            }
        }
    }
}