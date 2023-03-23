using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlam : MonoBehaviour
{
    Basic_Boss IceSlam_Damge;

    // Start is called before the first frame update
    void Start()
    {
        IceSlam_Damge = GameObject.Find("Ice Creature").GetComponent<Basic_Boss>();
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
                Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - IceSlam_Damge.IceWave_Damage));
                player_Hp.TakeDamage(IceSlam_Damge.IceWave_Damage);
                // ü�� ����

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
