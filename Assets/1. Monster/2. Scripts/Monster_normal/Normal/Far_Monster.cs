using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Far_Monster : Monster_Unit
{
    
    public Transform Bul_Pos;
    public float attackRange = 5f; // 몬스터 공격 범위
    public float attackForce = 500f; // 몬스터 공격 힘
    public GameObject projectilePrefab; // 몬스터 발사체 프리팹
    public float projectileSpeed = 10f; // 발사체 속도
    public float attackDelay = 2f; // 몬스터 공격 딜레이
    public LayerMask playerLayer; // 플레이어가 위치한 레이어
    public float angle_dd = 0f;

    private Transform playerTransform; // 플레이어의 트랜스폼
    public bool canAttack = true; // 몬스터가 공격할 수 있는지 여부

    public System.Action AtkAction = null;
    public float Angle = 80f;

    //far_Monster_State far_state;

    private void Awake()
    {
        AtkAction -= farAttack;
        AtkAction += farAttack;
    }
    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player_Hit").transform;
        
        //far_state = GetComponent<far_Monster_State>();
    }

    protected override void Update()
    {
        base.Update();
        if (!MonsterDie)
        {
            //farAttack();
            // 플레이어가 공격 범위 내에 있는지 확인
            if (Vector2.Distance(transform.position, playerTransform.position) < attackRange)
            {
                // 몬스터가 공격할 수 있는지 여부 확인
                if (canAttack)
                {
                    anim.SetTrigger("Attack");
                }
            }
        }
    }

    void farAttack() // 공격
    {
        // 몬스터가 공격을 시도한 후, 반복 공격을 방지하기 위해 canAttack을 false로 설정
        canAttack = false;
        // 공격 방향 계산
        Vector2 attackDirection = (playerTransform.position - transform.position).normalized;
        // 공격 각도 계산
        float attackAngle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg - Angle;
        // 몬스터 위치에서 발사체 생성
        GameObject projectile = Instantiate(projectilePrefab, Bul_Pos.position, Quaternion.Euler(0f, 0f, attackAngle));

        // 발사체에 힘을 가해 공격 방향으로 이동시킴
        projectile.GetComponent<Rigidbody2D>().AddForce(attackDirection * attackForce);

        // 일정 시간이 지난 후 발사체 제거
        Destroy(projectile, 5f);
        // 다음 공격을 위한 딜레이 코루틴 실행
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        // 공격 딜레이 시간만큼 대기
        yield return new WaitForSeconds(attackDelay);
        // 다음 공격 가능하도록 canAttack을 true로 변경
        canAttack = true;
        
    }

    private void OnDrawGizmosSelected()
    {
        // 몬스터 주변에 공격 범위를 나타내는 원 그리기
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
