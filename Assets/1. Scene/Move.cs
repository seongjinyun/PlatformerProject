using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigid; //�����̵��� ���� ���� ���� 

    private void Awake()
    {

        rigid = GetComponent<Rigidbody2D>(); //���� �ʱ�ȭ 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    }
}