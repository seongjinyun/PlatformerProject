using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    private Rigidbody2D rigid_bullet;
    public float skill_speed = 5.0f;
    protected bool isKnockback;
    GameObject[] Enemys; //�˹� ����

    public GameObject Player;
    AllUnits.Unit Pl_Dam;

    // Start is called before the first frame update
    void Start()
    {
        rigid_bullet = GetComponent<Rigidbody2D>();
        Enemys = GameObject.FindGameObjectsWithTag("Monster"); // �˹�
        Pl_Dam = Player.GetComponent<AllUnits.Unit>();
    }

    
    void Update()
    {
        //rigid_bullet.velocity = transform.right *-1 * skill_speed;
        Destroy(gameObject,0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster") //Monster �±׿� �浹�ϸ�
        {
            
            // Health ��ũ��Ʈ ��������
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("���� ��ų �ǰ�" + (Monster_Hp.Monster_currentHp - Pl_Dam.SkillDamage));
                Monster_Hp.Monster_TakeDamage(Pl_Dam.SkillDamage);
                // ü�� ����
            }
        }
    }
}
