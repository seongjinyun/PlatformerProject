using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public enum Boss_State { Idle, Atk, Run, Jump, Die };
    Boss_State boss_State = Boss_State.Idle;

    // virtual - �ڽ� ������Ʈ�� ���� �� �ְ� ����
    // Override - �θ𿡼� virtual�� ����Ǹ� �������̵带 �ؾ���
    // protected - ��ӵ� ��ũ��Ʈ������ ���� ����
    public Transform Target;
    public GameObject Child_anim;
    public Animator anim;
    public Monster_State Child;
    public Transform DashDir;

    public float speed;
    public float Radius = 10f;
    public float MoveSpeed = 1f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;
    public bool MonsterDie = false;

    public int Monster_HP = 10;
    bool MonCool = false;


    /*yield return null;  :  ���� �����ӿ� ���� ��.
    yield return new WaitForSeconds(float );  :  �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ� ŭ ��ٷȴٰ� �����.
    yield return new WaitForSecondsRealtime(flaot );  :  �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ�ŭ ��ٷȴٰ� �����.
    �׿� : yield return + new WaitForFixedUpdate / WaitForEndOfFrame ��...
    yield break;*/

    protected virtual void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Child = Child_anim.GetComponent<Monster_State>();
        DashDir = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.CompareTag("Player_Weapon")) // ���� �浹�� HP����
        {
            if (!MonCool)
            {
                Monster_HP -= 1;
                MonCool = true;

                Debug.Log(Monster_HP);
            }
            else
            {
                StartCoroutine(MonsterHP());
            }
            //StartCoroutine(MonsterHP());
        }
    }

    IEnumerator MonsterHP()
    {
        yield return new WaitForSeconds(1f);
        MonCool = false;
        if (Monster_HP <= 0)
        {
            Boss_Die(); // ü�� 0�� �ɽ� Boss_Die ����
            MonsterDie = true;
        }
    }

    protected virtual void Boss_Die()
    {
        //Destroy(gameObject,4);
        anim.SetTrigger("Die");
    }

}
