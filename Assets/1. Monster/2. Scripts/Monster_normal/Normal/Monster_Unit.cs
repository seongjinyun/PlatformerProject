using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Unit : Monster_Stats
{
    //  ���Ÿ�, �ٰŸ� ����
    // virtual - �ڽ� ������Ʈ�� ���� �� �ְ� ����
    // Override - �θ𿡼� virtual�� ����Ǹ� �������̵带 �ؾ���
    // protected - ��ӵ� ��ũ��Ʈ������ ���� ����
    public Transform Target;
    public Transform[] WallCheck;


    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 10f;
    public float MoveSpeed = 1f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;
    //public bool MonsterDie = false;

    //public int Monster_HP = 10;
    bool MonCool = false;


    /*yield return null;  :  ���� �����ӿ� ���� ��.
    yield return new WaitForSeconds(float );  :  �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ� ŭ ��ٷȴٰ� �����.
    yield return new WaitForSecondsRealtime(flaot );  :  �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ�ŭ ��ٷȴٰ� �����.
    �׿� : yield return + new WaitForFixedUpdate / WaitForEndOfFrame ��...
    yield break;*/

    protected override void Start()
    {
        base.Start();

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
        Rotate();
    }
    void Rotate()
    {
        //for (int i = 0; i < Target.Length; i++)
    
            if (transform.position.x < Target.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        
            
        //== Ÿ�� �������� ȸ���� ==//
        //Vector3 dir = target.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    
    /*protected virtual void OnTriggerEnter2D(Collider2D coll)
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
    }*/

    /*IEnumerator MonsterHP()
    {
        yield return new WaitForSeconds(1f);
        MonCool = false;
        if (Monster_HP <= 0)
        {
            Boss_Die(); // ü�� 0�� �ɽ� Boss_Die ����
            MonsterDie = true;
        }
    }*/

    /*protected virtual void Boss_Die()
    {
        //Destroy(gameObject,4);
        anim.SetTrigger("Die");
    }*/

}
