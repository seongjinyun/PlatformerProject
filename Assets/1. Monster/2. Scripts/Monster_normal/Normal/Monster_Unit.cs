using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Unit : Monster_Stats
{
    //  원거리, 근거리 몬스터
    // virtual - 자식 오브젝트가 받을 수 있게 해줌
    // Override - 부모에서 virtual이 선언되면 오버라이드를 해야함
    // protected - 상속된 스크립트에서만 접근 가능
    public Transform Target;
    public Transform[] WallCheck;


    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 10f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;
    //public bool MonsterDie = false;

    //public int Monster_HP = 10;
    bool MonCool = false;


    /*yield return null;  :  다음 프레임에 실행 됨.
    yield return new WaitForSeconds(float );  :  매개변수로 입력한 숫자에 해당하는 초만 큼 기다렸다가 실행됨.
    yield return new WaitForSecondsRealtime(flaot );  :  매개변수로 입력한 숫자에 해당하는 초만큼 기다렸다가 실행됨.
    그외 : yield return + new WaitForFixedUpdate / WaitForEndOfFrame 등...
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
        if (MonsterDie)
        {
            Destroy(gameObject, 1.5f);
        }
    }
    void Rotate()
    {
        //for (int i = 0; i < Target.Length; i++)
        if (!MonsterDie)
        {
            if (transform.position.x < Target.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        //== 타겟 방향으로 회전함 ==//
        //Vector3 dir = target.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

}
