using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBullet : MonoBehaviour
{
    public float speed = 8f;
    public Wind_Boss windboss;
    private void Awake()
    {
        windboss = GameObject.FindObjectOfType<Wind_Boss>();
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
                    Debug.Log("PlayerHP =" + (player_Hp.currentHealth - windboss.WindBullet_Damage));
                    player_Hp.TakeDamage(windboss.WindBullet_Damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
