using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tor : MonoBehaviour
{
    public Boss_mode final_boss;
    public float delay = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        final_boss = GameObject.FindObjectOfType<Boss_mode>();
        Destroy(gameObject, 4f);
    }
    void Start()
    {

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
                        Debug.Log("PlayerHP =" + (player_Hp.currentHealth - final_boss.WindTornado_Damage));
                        player_Hp.TakeDamage(final_boss.WindTornado_Damage);
                        delay = 0.7f;
                    }


                }
            }
        }
    }
}