using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Unit : MonoBehaviour
{
    public enum Boss_State { Idle, Atk, Run, Jump, Die };
    Boss_State boss_State = Boss_State.Idle;

    // virtual - 자식 오브젝트가 받을 수 있게 해줌
    // Override - 부모에서 virtual이 선언되면 오버라이드를 해야함
    // protected - 상속된 스크립트에서만 접근 가능
    public Transform Target;
    public Transform[] WallCheck;
    public GameObject Child_anim;
    public Animator anim;
    public Monster_State Child;

    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 10f;
    public float MoveSpeed = 1f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;
    public bool MonsterDie = false;

    public int Monster_HP = 10;
    bool MonCool = false;

    public bool far_Monster = false;


    /*yield return null;  :  다음 프레임에 실행 됨.
    yield return new WaitForSeconds(float );  :  매개변수로 입력한 숫자에 해당하는 초만 큼 기다렸다가 실행됨.
    yield return new WaitForSecondsRealtime(flaot );  :  매개변수로 입력한 숫자에 해당하는 초만큼 기다렸다가 실행됨.
    그외 : yield return + new WaitForFixedUpdate / WaitForEndOfFrame 등...
    yield break;*/

    protected virtual void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Child = Child_anim.GetComponent<Monster_State>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
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
        
            
        //== 타겟 방향으로 회전함 ==//
        //Vector3 dir = target.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    
    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.CompareTag("Player_Weapon")) // 웨폰 충돌시 HP감소
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
            Boss_Die(); // 체력 0이 될시 Boss_Die 실행
            MonsterDie = true;
        }
    }

    protected virtual void Boss_Die()
    {
        //Destroy(gameObject,4);
        anim.SetTrigger("Die");
    }

}
