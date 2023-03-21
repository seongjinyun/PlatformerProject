using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Boss : Monster_Stats
{
    //public float Monster_Hp = 10f;//ü��
    //public float Monster_Damage = 1f; // ���ݷ�
    public GameObject DashPos; // �뽬�Ҷ� ����� �ݶ��̴�(���� ���濡�� ����)
    public float speed; //�뽬 �ӵ� ���� 
    //public GameObject Child_anim;
    public bool isDash;

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

    protected override void Start()
    {
        base.Start();
        //anim = Child_anim.GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DashDir = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        player_Hp = Target.GetComponent<AllUnits.Unit>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void LookPlayer()
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
    protected virtual void Collider() // ���� ���� �÷��̾��� ü���� ����
    {
        Collider2D collider2d = Physics2D.OverlapCircle(Attack_Pos.position, Attack_Radius, P_Layer); 
        // Attack_Pos ������Ʈ�� ������ ����, Attack_Radius ���� ������ ����
        // �ν����Ϳ��� P_Layer�� Player ���̾�� ����

        if (collider2d)
        {
            if (player_Hp != null) // ��Ÿ ���� - �⺻ ���� �ִϸ��̼� �̺�Ʈ�� Collider()�Լ� �߰�
            {
                Debug.Log("PlayerHP =" + (player_Hp.currentHealth - Monster_Damage));
                player_Hp.TakeDamage(Monster_Damage);
                // ü�� ����
            }
            else if (isDash) // �뽬 ���� - �޸��� �ִϸ��̼� �̺�Ʈ�� �� �տ� Collider()�Լ� �߰� + �޸��� �ִϸ��̼� ���ǵ� 0.7�� ����
            {
                Debug.Log("PlayerHP =" + (player_Hp.currentHealth - Dash_Damage));
                player_Hp.TakeDamage(Dash_Damage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        // ���� �ֺ��� ���� ������ ��Ÿ���� �� �׸���
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attack_Pos.position, Attack_Radius);
    }
}
