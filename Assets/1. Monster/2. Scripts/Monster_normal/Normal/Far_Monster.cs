using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Far_Monster : Monster_Unit
{
    public GameObject Bullet;
    public Transform Bul_Pos;
    Vector2 Player;

    float timer = 4f;
    public float CoolT;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Player = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        far_Attack();
    }
    void far_Attack()
    {
        if (!MonsterDie)
        {
            CoolT -= Time.deltaTime;
            if (CoolT < 0) CoolT = 0;
            /*RaycastHit2D ray = Physics2D.Linecast(s)*/
            collider2D = Physics2D.OverlapCircle(transform.position, Radius, Layer_Chase);
            // 범위 내에 Layer_Chase Player가 탐색되면 플레이어 위치로 공격
            if (CoolT == 0)
            {
                if (collider2D)
                {
                    GameObject bulletCopy = Instantiate(Bullet, Bul_Pos.position, transform.rotation);
                    bulletCopy.GetComponent<Rigidbody2D>().velocity = bulletCopy.transform.right * 10f;
                    CoolT = timer;
                }
            }
            
            

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

    }
}
