using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Monster : MonoBehaviour
{
    public float moveDistance = 5f;      // �Ÿ�
    public float moveSpeed = 3f;         // �ӵ�
    public float knockbackForce = 5f;    // �˹� ��
    int Damage = 1;

    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 moveDirection = Vector2.right;

    public Vector2 Vec;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
        rb.gravityScale = 0f;
    }

    private void FixedUpdate()
    {
        // �̵� ���� ����� ȸ��
        if (Mathf.Abs(rb.position.x - startPos.x) >= moveDistance)
        {
            moveDirection = -moveDirection;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (player_Hp != null)
            {
                Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - Damage));
                player_Hp.TakeDamage(Damage);
            }
            // �÷��̾� �˹�
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(moveDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}

