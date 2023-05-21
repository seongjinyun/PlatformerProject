using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam_atk : MonoBehaviour
{
    public Basic_Boss IceSlam_Damge;
    public float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health ��ũ��Ʈ ��������
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (collision)
            {
                if (player_Hp != null)
                {
                    if (delay <= 0f)
                    {

                        Debug.Log("�÷��̾� ü�� = " + (player_Hp.currentHealth - IceSlam_Damge.IceWave_Damage));
                        player_Hp.TakeDamage(IceSlam_Damge.IceWave_Damage);
                        // ü�� ����
                        delay = 0.9f;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }
}
