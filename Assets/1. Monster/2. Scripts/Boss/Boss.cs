using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum Boss_State { Idle, Atk, Run, Jump, Die };
    Boss_State boss_State = Boss_State.Idle;

    // virtual - �ڽ� ������Ʈ�� ���� �� �ְ� ����
    // Override - �θ𿡼� virtual�� ����Ǹ� �������̵带 �ؾ���
    // protected - ��ӵ� ��ũ��Ʈ������ ���� ����
    public Transform Target;
    public Transform[] WallCheck;
    public GameObject Child_anim;
    public Animator anim;

    public float JumpPower = 3f;
    public float speed = 0.5f;
    public float Radius = 10f;

    public LayerMask Layer_Chase;
    public LayerMask Layer_Wall;

    public Rigidbody2D rb;

    public bool collider2D;
    public bool MonsterDie = false;



    /*yield return null;  :  ���� �����ӿ� ���� ��.
    yield return new WaitForSeconds(float );  :  �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ� ŭ ��ٷȴٰ� �����.
    yield return new WaitForSecondsRealtime(flaot );  :  �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ�ŭ ��ٷȴٰ� �����.
    �׿� : yield return + new WaitForFixedUpdate / WaitForEndOfFrame ��...
    yield break;*/

    protected virtual void Start()
    {
        anim = Child_anim.GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        Rotate();
        StartCoroutine(Boss_Jump());
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

    IEnumerator Boss_Jump() // ����
    {
        if (!MonsterDie) {
            yield return null;

            if (!Physics2D.OverlapCircle(WallCheck[0].position, 0.01f, Layer_Wall) &&
                 Physics2D.OverlapCircle(WallCheck[1].position, 0.01f, Layer_Wall) &&
                !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, Layer_Wall))
            {
                //Debug.Log("�� �浹");
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

}
