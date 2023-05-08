using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Shield : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigid_shield;
    public float skill_speed;

    public GameObject enemy; 
    

    GameObject[] Enemys;

    public AudioClip[] clip; // 오디오 변수 0 = Monster_Attacked --> 피격사운드


    public GameObject Player;
    AllUnits.Unit Pl_Dam;
    void Start()
    {
        rigid_shield = GetComponent<Rigidbody2D>();
        Pl_Dam = Player.GetComponent<AllUnits.Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster") //Monster 태그와 충돌하면
        {

            // Health 스크립트 가져오기
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("몬스터 스킬 피격" + (Monster_Hp.Monster_currentHp - Pl_Dam.SkillDamage_Shield));
                Monster_Hp.Monster_TakeDamage(Pl_Dam.SkillDamage_Shield);
                SfxManger.instance.SfxPlay("Monster_Attacked", clip[0]);
                // 체력 감소
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision) // 넉백 스크립트
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            foreach (GameObject monster in Enemys)
            {
                if (transform.position.x >= monster.transform.position.x && !isKnockback)

                {
                    isKnockback = true;
                    collision.transform.Translate(2.0f, 0.4f, 0);

                }
                else

                {
                    isKnockback = true;
                    collision.transform.Translate(-2.0f, 0.4f, 0);

                }
            }

        }
    }
    */
}
