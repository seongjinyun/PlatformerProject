using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Boss : Monster_Stats
{
    //public float Monster_Hp = 10f;//체력
    //public float Monster_Damage = 1f; // 공격력
    public GameObject DashPos; // 대쉬할때 생기는 콜라이더(보스 전방에만 생김)
    public float speed; //대쉬 속도 변수 
    //public GameObject Child_anim;
    public bool isDash;
    
    // 스킬 공격력 변수
    public int EarthBullet_Damage = 1;

    public int IceBullet_Damage = 1;
    public int IceWave_Damage = 1;

    public int Dash_Damage = 1;
    public int FireBreath_Damage = 1;
    public int FireMeteor_Damage = 1;

    public int WindTornado_Damage = 1;
    public int WindBullet_Damage = 1;

    public Transform Attack_Pos;
    public float Attack_Radius;

    public LayerMask P_Layer;
    //public Animator anim;
    public Transform Target, DashDir;

    public AllUnits.Unit player_Hp;
    Transform Player;

    protected override void Start()
    {
        base.Start();
        //anim = Child_anim.GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player_Hit").GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DashDir = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        player_Hp = Player.GetComponent<AllUnits.Unit>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        BossDie();
    }

    void BossDie()
    {
        if (MonsterDie)
        {
            Collider2D coll = GetComponent<Collider2D>();
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
            coll.enabled = false;

            return;
        }
    }
    public void LookPlayer()
    {
        if (transform.position.x < Player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
    protected virtual void Collider_Atk() // 텔포 공격 플레이어의 체력을 깎음
    {
        Collider2D collider2d = Physics2D.OverlapCircle(Attack_Pos.position, Attack_Radius, P_Layer); 
        // Attack_Pos 오브젝트로 포지션 지정, Attack_Radius 공격 범위를 지정
        // 인스펙터에서 P_Layer에 Player 레이어로 지정

        if (collider2d)
        {
            if (player_Hp != null) // 평타 공격 - 기본 공격 애니메이션 이벤트에 Collider()함수 추가
            {
                Debug.Log("PlayerHP =" + (player_Hp.currentHealth - Monster_Damage));
                player_Hp.TakeDamage(Monster_Damage);
                // 체력 감소
            }
/*            else if (isDash) // 대쉬 공격 - 달리는 애니메이션 이벤트에 맨 앞에 Collider()함수 추가 + 달리는 애니메이션 스피드 0.7로 지정
            {
                Debug.Log("PlayerHP =" + (player_Hp.currentHealth - Dash_Damage));
                player_Hp.TakeDamage(Dash_Damage);
            }*/
        }
    }

    protected virtual void Collider_Dash() // 텔포 공격 플레이어의 체력을 깎음
    {
        Collider2D collider2d = Physics2D.OverlapCircle(Attack_Pos.position, Attack_Radius, P_Layer);
        // Attack_Pos 오브젝트로 포지션 지정, Attack_Radius 공격 범위를 지정
        // 인스펙터에서 P_Layer에 Player 레이어로 지정

        if (collider2d)
        {
            if (isDash) // 대쉬 공격 - 달리는 애니메이션 이벤트에 맨 앞에 Collider()함수 추가 + 달리는 애니메이션 스피드 0.7로 지정
            {
                Debug.Log("PlayerHP =" + (player_Hp.currentHealth - Dash_Damage));
                player_Hp.TakeDamage(Dash_Damage);
            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        // 몬스터 주변에 공격 범위를 나타내는 원 그리기
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attack_Pos.position, Attack_Radius);
    }
}
