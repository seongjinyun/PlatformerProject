using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Bullet : MonoBehaviour
{

    private Rigidbody2D rigid_bullet;
    public float bullet_speed = 20.0f;

    public Basic_Boss EarthBullet_Damage;
    public float delay = 0f;

    // ȸ�� �ӵ��� �����ϴ� ����
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
            // Health ��ũ��Ʈ ��������
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (player_Hp != null)
            {
                if (delay <= 0f)
                {
                    Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - EarthBullet_Damage.IceWave_Damage));
                    player_Hp.TakeDamage(EarthBullet_Damage.IceWave_Damage);
                    // ü�� ����
                    delay = 0.8f;
                }

            }
        }
    }

    // �Ѿ��� ȸ����Ű�� �ڷ�ƾ �޼���
    IEnumerator RotateBullet()
    {
        while (true)
        {
            // �Ѿ��� ���� �̵� ó��
            Vector3 direction = transform.right.normalized;
            rigid_bullet.velocity = direction * bullet_speed;

            yield return null;
        }
    }
}
