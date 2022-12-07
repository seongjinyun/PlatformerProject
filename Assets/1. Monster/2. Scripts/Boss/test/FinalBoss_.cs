using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_ : MonoBehaviour
{
    public float speed;

    public float Timer = 0f;

    public GameObject Monster_bullet;
    public Transform Bullet_pos;
    public GameObject[] Target;

    public float JumpPower = 3f;
    Rigidbody2D rb;
    public LayerMask Layer;
    public bool isJump = false;
    private bool isGround = true;
    public GameObject Pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 10f)
        {
             Instantiate(Monster_bullet, Bullet_pos.position, transform.rotation);
             Timer = 0f;
        }
        Jump();

    }

    void LateUpdate() // 하이라키뷰 플레이어 이름 찾아서 추적
    {
        transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);
    }

    void Jump()
    {
        Debug.DrawLine(Pos.transform.position, Vector2.right, Color.red, 1f);

        if (Physics2D.Raycast(Pos.transform.position, Vector2.right*-1, 1f, Layer))
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            isJump = true;
            if (isJump == true)
            {
                // 땅에서 떨어졌으므로 isGround를 false로 바꿈
                isGround = false;
                isJump = false; // 일단 임시 점프 overlapcircle 사용해서 점프구현하기
            }
        }
    }
}
