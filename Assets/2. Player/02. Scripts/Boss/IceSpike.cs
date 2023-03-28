using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    Basic_Boss IceSpike_Dam;

    // Start is called before the first frame update
    void Start()
    {
        IceSpike_Dam = GameObject.Find("Ice Creature").GetComponent<Basic_Boss>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health ��ũ��Ʈ ��������
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();

            if (player_Hp != null)
            {
                Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - IceSpike_Dam.IceBullet_Damage));
                player_Hp.TakeDamage(IceSpike_Dam.IceBullet_Damage);
                // ü�� ����

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
