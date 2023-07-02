using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Bullet : MonoBehaviour
{

    private Rigidbody2D rigid_bullet;
    public float bullet_speed = 20.0f;

    public Basic_Boss EarthBullet_Damage;
    public float delay = 0f;

    // 회전 속도를 조절하는 변수
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigid_bullet = GetComponent<Rigidbody2D>();
        StartCoroutine(RotateBullet());
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health 스크립트 가져오기
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (player_Hp != null)
            {
                if (delay <= 0f)
                {
                    Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - EarthBullet_Damage.IceWave_Damage));
                    player_Hp.TakeDamage(EarthBullet_Damage.IceWave_Damage);
                    // 체력 감소
                    delay = 0.8f;
                }

            }
        }
    }

    // 총알을 회전시키는 코루틴 메서드
    IEnumerator RotateBullet()
    {
        while (true)
        {
            // 총알의 직진 이동 처리
            Vector3 direction = transform.right.normalized;
            rigid_bullet.velocity = direction * bullet_speed;

            yield return null;
        }
    }
}
