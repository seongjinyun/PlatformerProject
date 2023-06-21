using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGrow : MonoBehaviour
{
    
    public Basic_Boss Earth_Damage;
    float delay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Earth_Damage = GameObject.Find("Rock Creature").GetComponent<Basic_Boss>();
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();

            if (player_Hp != null)
            {
                if (delay <= 0f)
                {
                    Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - Earth_Damage.EarthBullet_Damage));
                    player_Hp.TakeDamage(Earth_Damage.EarthBullet_Damage);
                    // 체력 감소
                    delay = 0.8f;
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
