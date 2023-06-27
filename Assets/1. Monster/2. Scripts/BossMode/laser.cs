using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float moveSpeed;
    public int laserDamage = 1;

    public float delay = 0f;

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
                        Debug.Log("PlayerHP =" + (player_Hp.currentHealth - laserDamage));
                        player_Hp.TakeDamage(laserDamage);
                        delay = 0.7f;
                    }
                    // 체력 감소
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
