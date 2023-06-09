using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Meteo : MonoBehaviour
{
    public Boss_mode boss_mo;
    Rigidbody2D rigid;
    float MeteorPw = 10;
    void Awake()
    {
        boss_mo = GameObject.FindObjectOfType<Boss_mode>();

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
                    Debug.Log("PlayerHP =" + (player_Hp.currentHealth - boss_mo.FireMeteor_Damage));
                    player_Hp.TakeDamage(boss_mo.FireMeteor_Damage);
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

