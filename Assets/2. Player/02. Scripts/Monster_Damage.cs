using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Damage : MonoBehaviour
{
    public GameObject Damage_Effect;
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear"))
        {
            Debug.Log("�浹");
            Instantiate(Damage_Effect, collision.transform.position, Quaternion.identity);

            GameObject effect = Instantiate(Damage_Effect, Enemy.transform.position, Quaternion.identity);
            Destroy(effect,0.5f);
        }
    }
}
