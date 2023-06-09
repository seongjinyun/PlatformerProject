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
        //�ι�° �Ķ���Ϳ� Space.World�� �������ν� Rotation�� ���� ���� ������ ������
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision) // �극�� ���� ������
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
