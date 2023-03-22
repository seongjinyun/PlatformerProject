using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleAttack : MonoBehaviour
{
    public Wind_Boss windboss;

    // Start is called before the first frame update
    private void Awake()
    {
        windboss = GameObject.FindObjectOfType<Wind_Boss>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
                    Debug.Log("PlayerHP =" + (player_Hp.currentHealth - windboss.Monster_Damage));
                    player_Hp.TakeDamage(windboss.Monster_Damage);

                }
            }
        }
    }
}