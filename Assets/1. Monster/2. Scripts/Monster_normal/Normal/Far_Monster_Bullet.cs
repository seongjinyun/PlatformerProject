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
    public int Monster_Damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health 스크립트 가져오기
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (player_Hp != null)
            {
                player_Hp.TakeDamage(Monster_Damage);
                // 체력 감소

            }
            // 투사체 파괴
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
