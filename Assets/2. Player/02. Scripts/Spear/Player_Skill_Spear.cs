using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Spear : MonoBehaviour
{
    private Rigidbody2D rigid_spear;
    public float skill_speed = 5.0f;
    GameObject[] Enemys;
    protected bool isKnockback;
    //public GameObject explo;

    public GameObject Player;
    AllUnits.Unit Pl_Dam;


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

    /*private void OnTriggerEnter2D(Collider2D collision) // �˹� ��ũ��Ʈ
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
        Destroy(gameObject, 3f);
        //rigid_spear.velocity = new Vector2(1, -1); // �밢�� â
        //rigid_spear.AddForce(Vector2.left * skill_speed);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster") //Monster �±׿� �浹�ϸ�
        {

            // Health ��ũ��Ʈ ��������
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("���� ��ų �ǰ�" + (Monster_Hp.Monster_currentHp - Pl_Dam.SkillDamage_Spear));
                Monster_Hp.Monster_TakeDamage(Pl_Dam.SkillDamage_Spear);
                // ü�� ����
            }
        }
    }

}