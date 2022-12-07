using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum Boss_State { Idle, Atk, Run, Jump, Die };
    Boss_State boss_State = Boss_State.Idle;

    // virtual - 자식 오브젝트가 받을 수 있게 해줌
    // Override - 부모에서 virtual이 선언되면 오버라이드를 해야함
    // protected - 상속된 스크립트에서만 접근 가능
    public GameObject[] Target;
    public Transform[] WallCheck;
    public GameObject Child_anim;
    public Animator anim;

    public GameObject Monster_Skill;
    public Transform Skill_pos;
    public float Skill_timer = 0f;

    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 10f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;
    public bool MonsterDie = false;

    /*yield return null;  :  다음 프레임에 실행 됨.
    yield return new WaitForSeconds(float );  :  매개변수로 입력한 숫자에 해당하는 초만 큼 기다렸다가 실행됨.
    yield return new WaitForSecondsRealtime(flaot );  :  매개변수로 입력한 숫자에 해당하는 초만큼 기다렸다가 실행됨.
    그외 : yield return + new WaitForFixedUpdate / WaitForEndOfFrame 등...
    yield break;*/

    protected virtual void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        
        Rotate();
        StartCoroutine(Boss_Jump());
        StartCoroutine(Boss_Skill());

    }
    void Rotate()
    {
        for (int i = 0; i < Target.Length; i++)
        {
            if (transform.position.x < Target[i].transform.position.x)
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

    IEnumerator Boss_Jump() // 점프
    {
        if (!MonsterDie) {
            yield return null;

            if (!Physics2D.OverlapCircle(WallCheck[0].position, 0.01f, Layer_Wall) &&
                 Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) &&
                !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
            {
                //Debug.Log("벽 충돌");
                boss_State = Boss_State.Jump;
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            }

            else if (Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall))
            {
                if (WallCheck[1].position.x < transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    rb.velocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
                }
            }
        }
    }
    IEnumerator Boss_Skill()
    {
        yield return null;
        if (Skill_timer >= 10f)
        {
            yield return null;
            Instantiate(Monster_Skill, Skill_pos.position, transform.rotation);
            Skill_timer = 0f;
        }
    }
}
