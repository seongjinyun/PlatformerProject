using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Far_Monster_Bullet : MonoBehaviour
{
    /*Rigidbody2D rigid;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //rigidbody.velocity = transform.position * bulletSpeed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x)
            * Mathf.Rad2Deg ;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            /*// Health 스크립트 가져오기
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                // 체력 감소
                playerHealth.Damage(damageAmount);
            }*/

            // 투사체 파괴
            Destroy(gameObject);
        }
    }
}
