using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    private Rigidbody2D rigid_bullet;
    public float skill_speed = 5.0f;
    protected bool isKnockback;
    GameObject[] Enemys; //넉백 변수

    public GameObject Attacked_Effect;

    public GameObject Player;
    AllUnits.Unit Pl_Dam;

    public AudioClip[] clip; // 오디오 변수 0 = Monster_Attacked --> 피격사운드

    // Start is called before the first frame update
    void Start()
    {
        rigid_bullet = GetComponent<Rigidbody2D>();
        Enemys = GameObject.FindGameObjectsWithTag("Monster"); // 넉백
        Pl_Dam = Player.GetComponent<AllUnits.Unit>();
    }

    
    void Update()
    {
        //rigid_bullet.velocity = transform.right *-1 * skill_speed;
        Destroy(gameObject,0.5f); //소드 스킬 사라지기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster") //Monster 태그와 충돌하면
        {
            StartCoroutine(Effect_Delay(collision.transform.position, collision.transform.rotation)); // collision 위치값 회전값 받아옴
            StartCoroutine(Effect_Delay(collision.transform.position + Vector3.right + Vector3.down, collision.transform.rotation));
            // Health 스크립트 가져오기
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("몬스터 스킬 피격" + (Monster_Hp.Monster_currentHp - Pl_Dam.SkillDamage_Sword));
                Monster_Hp.Monster_TakeDamage(Pl_Dam.SkillDamage_Sword);
                SfxManger.instance.SfxPlay("Monster_Attacked", clip[0]);
                // 체력 감소
            }
        }
    }

    IEnumerator Effect_Delay(Vector3 position, Quaternion rotation) //매개변수 받기
    {
        yield return new WaitForSeconds(0.2f); //2초 후
        GameObject Atk_Ef = Instantiate(Attacked_Effect, position, rotation); //이펙트 등장
        GameObject Atk_Ef_1 = Instantiate(Attacked_Effect, position, rotation); //이펙트 등장
        Destroy(Atk_Ef, 0.5f); //이펙트 사라진다요
        Destroy(Atk_Ef_1, 0.5f); //이펙트 사라진다요
    }
}
