using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public Fire_Boss fireboss;
    Rigidbody2D rigid;
    float MeteorPw = 10;
    void Awake()
    {
        fireboss = GameObject.FindObjectOfType<Fire_Boss>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);

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
                    Debug.Log("PlayerHP =" + (player_Hp.currentHealth - fireboss.FireMeteor_Damage));
                    player_Hp.TakeDamage(fireboss.FireMeteor_Damage);
                    Destroy(gameObject);

                }
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

