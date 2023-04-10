using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postion : MonoBehaviour
{
    AllUnits.Unit CurHp;
    public GameObject player;
    Player_Move player_Move;
    public AudioClip clip;
    public float curhp;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        player_Move = player.GetComponent<Player_Move>();


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            SfxManger.instance.SfxPlay("Heal_Item", clip);
            player_Move.currentHealth += 5;

            Destroy(gameObject);
        }
    }
}
