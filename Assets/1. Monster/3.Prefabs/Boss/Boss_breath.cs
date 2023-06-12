using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_breath : MonoBehaviour
{
    public Boss_mode boss_mode;
    public float delay = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        //fireboss = GetComponent<Fire_Boss>();
        boss_mode = GameObject.FindObjectOfType<Boss_mode>();
        Destroy(gameObject, 0.8f);
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision) // 브레스 공격 딜레이
    {
        if (collision.CompareTag("Player"))
        {
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            
            if (collision)
            {
                if (player_Hp != null)
                {
                    if (delay <= 0f)
                    {
                        Debug.Log("PlayerHP =" + (player_Hp.currentHealth - boss_mode.FireBreath_Damage));
                        player_Hp.TakeDamage(boss_mode.FireBreath_Damage);
                        delay = 0.7f;
                    }
                    // 체력 감소
                }
            }
        }
    }
}