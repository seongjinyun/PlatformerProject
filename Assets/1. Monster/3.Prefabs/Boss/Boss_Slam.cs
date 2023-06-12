using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Slam : MonoBehaviour
{
    public  Boss_mode boss_mo;
    public float delay = 0f;


    // Start is called before the first frame update
    void Start()
    {
        boss_mo = GameObject.FindObjectOfType<Boss_mode>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // Health 스크립트 가져오기
            AllUnits.Unit player_Hp = collision.gameObject.GetComponent<AllUnits.Unit>();
            if (collision)
            {
                if (player_Hp != null)
                {
                    if (delay <= 0f)
                    {

                        Debug.Log("플레이어 체력 = " + (player_Hp.currentHealth - boss_mo.IceWave_Damage));
                        player_Hp.TakeDamage(boss_mo.IceWave_Damage);
                        // 체력 감소
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
