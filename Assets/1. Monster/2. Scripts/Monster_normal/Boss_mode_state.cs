using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_mode_state : MonoBehaviour
{
    Transform Player;

    public bool Attack = false;

    GameObject Parent;

    Boss_mode boss_mo;

    public GameObject normal_Parent;
    AllUnits.Unit player_Hp;

    public Transform Attpos;
    public float AttSize;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss_mo = normal_Parent.GetComponent<Boss_mode>();
        player_Hp = Player.GetComponent<AllUnits.Unit>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    void AtkAct()
    {
        Debug.Log("공격");
        Collider2D coll = Physics2D.OverlapCircle(Attpos.position, AttSize, boss_mo.P_Layer);

        if (coll)
        {
            if (player_Hp != null)
            {
                Debug.Log("PlayerHP" + (player_Hp.currentHealth - boss_mo.Monster_Damage));
                player_Hp.TakeDamage(boss_mo.Monster_Damage);
                // 체력 감소
            }
        }
        // normalMonster.AtkAction.Invoke();

    }
}
