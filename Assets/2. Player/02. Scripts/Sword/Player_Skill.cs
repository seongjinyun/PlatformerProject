using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    private Rigidbody2D rigid_bullet;
    public float skill_speed = 5.0f;
    protected bool isKnockback;
    GameObject[] Enemys; //�˹� ����

    public GameObject Attacked_Effect;

    public GameObject Player;
    AllUnits.Unit Pl_Dam;

    public AudioClip[] clip; // ����� ���� 0 = Monster_Attacked --> �ǰݻ���

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
        Destroy(gameObject,0.5f); //�ҵ� ��ų �������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster") //Monster �±׿� �浹�ϸ�
        {
            StartCoroutine(Effect_Delay(collision.transform.position, collision.transform.rotation)); // collision ��ġ�� ȸ���� �޾ƿ�
            StartCoroutine(Effect_Delay(collision.transform.position + Vector3.right + Vector3.down, collision.transform.rotation));
            // Health ��ũ��Ʈ ��������
            Monster_Stats Monster_Hp = collision.gameObject.GetComponent<Monster_Stats>();
            if (Monster_Hp != null)
            {
                Debug.Log("���� ��ų �ǰ�" + (Monster_Hp.Monster_currentHp - Pl_Dam.SkillDamage_Sword));
                Monster_Hp.Monster_TakeDamage(Pl_Dam.SkillDamage_Sword);
                SfxManger.instance.SfxPlay("Monster_Attacked", clip[0]);
                // ü�� ����
            }
        }
    }

    IEnumerator Effect_Delay(Vector3 position, Quaternion rotation) //�Ű����� �ޱ�
    {
        yield return new WaitForSeconds(0.2f); //2�� ��
        GameObject Atk_Ef = Instantiate(Attacked_Effect, position, rotation); //����Ʈ ����
        GameObject Atk_Ef_1 = Instantiate(Attacked_Effect, position, rotation); //����Ʈ ����
        Destroy(Atk_Ef, 0.5f); //����Ʈ ������ٿ�
        Destroy(Atk_Ef_1, 0.5f); //����Ʈ ������ٿ�
    }
}
