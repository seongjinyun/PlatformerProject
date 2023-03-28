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
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health 스크립트 가져오기
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();

            if (player_Hp != null)
            {
                Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - IceSpike_Dam.IceBullet_Damage));
                player_Hp.TakeDamage(IceSpike_Dam.IceBullet_Damage);
                // 체력 감소

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
