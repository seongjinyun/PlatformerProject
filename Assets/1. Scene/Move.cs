using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigid; //물리이동을 위한 변수 선언 

    private void Awake()
    {

        rigid = GetComponent<Rigidbody2D>(); //변수 초기화 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    }
}