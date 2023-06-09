using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGobull : MonoBehaviour
{
    public float speed = 8f;
    public Boss_mode final_boss;
    private void Awake()
    {
        final_boss = GameObject.FindObjectOfType<Boss_mode>();
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        //두번째 파라미터에 Space.World를 해줌으로써 Rotation에 의한 방향 오류를 수정함
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision) // 브레스 공격 딜레이
    {
        if (collision.CompareTag("Player"))
        {
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();

            if (collision)
            {
                if (player_Hp != null)
                {
                    Debug.Log("PlayerHP =" + (player_Hp.currentHealth - final_boss.WindBullet_Damage));
                    player_Hp.TakeDamage(final_boss.WindBullet_Damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
