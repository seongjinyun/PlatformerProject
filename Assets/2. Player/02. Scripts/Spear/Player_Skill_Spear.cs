using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Spear : MonoBehaviour
{
    private Rigidbody2D rigid_spear;
    public float skill_speed = 15.0f;
    GameObject[] Enemys;
    protected bool isKnockback;
    //public GameObject explo;

    public GameObject Attacked_Effect; //이펙트

    public GameObject Player;
    AllUnits.Unit Pl_Dam;

    public AudioClip[] clip; // 오디오 변수 0 = Monster_Attacked --> 피격사운드

    //float x = 1;
    //float y = -1f;
    //private float angle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Monster");
        rigid_spear = GetComponent<Rigidbody2D>();
        Pl_Dam = Player.GetComponent<AllUnits.Unit>();
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
                    monster.transform.Translate(2.0f, 0.4f, 0);

                }
                else

                {
                    isKnockback = true;
                    monster.transform.Translate(-2.0f, 0.4f, 0);

                }
            }

        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        //rigid_spear.AddTorque(angle);
        rigid_spear.velocity = transform.right* -1 * skill_speed;
        this.gameObject.transform.Rotate(0, 0, 5 * Time.deltaTime);
        Destroy(gameObject, 3f);
        rigid_spear.gravityScale = 0f;
        //rigid_spear.velocity = new Vector2(1, -1); // 대각선 창
        //rigid_spear.AddForce(Vector2.left * skill_speed);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster") //Monster 태그와 충돌하면
        {
            GameObject Atk_Ef = Instantiate(Attacked_Effect, collision.transform.position, collision.transform.rotation);
            GameObject Atk_Ef_2 = Instantiate(Attacked_Effect, collision.transform.position + Vector3.right + Vector3.up, collision.transform.rotation); // 스킬이펙트
            Destroy(Atk_Ef, 0.5f);
            Destroy(Atk_Ef_2, 0.5f);
            // Health 스크립트 가져오기
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("몬스터 스킬 피격" + (Monster_Hp.Monster_currentHp - Pl_Dam.SkillDamage_Spear));
                Monster_Hp.Monster_TakeDamage(Pl_Dam.SkillDamage_Spear);
                SfxManger.instance.SfxPlay("Monster_Attacked", clip[0]);
                // 체력 감소
            }
        }
    }

}
