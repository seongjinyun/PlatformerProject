using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss_new : Boss3
{
    static bool FireBossRoom;
    public bool isDash, isLook;
    public float DashCool = 0;
  
    protected override void Start()
    {
        base.Start();

        FireBossRoom = true; //보스 방 입장 시 true로 변경할꺼임
    }
    protected override void Update()
    {
        Debug.Log(Vector2.Distance(transform.position, Target.transform.position));
        DashCool += Time.deltaTime;

        if (Vector2.Distance(transform.position, Target.transform.position) >= 20)
        {
            isDash = true;
        }
        if(isDash == true && DashCool >= 20 && FireBossRoom == true)
        {
            StartCoroutine(BossDash());
        }
    }

    IEnumerator BossDash()
    {
        if (isLook == false)
        {
            LookPlayer();
        }
        else
        {
            anim.SetBool("Dash", true);
            yield return new WaitForSeconds(1f); //1초 대기
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            yield return new WaitForSeconds(4f);
            anim.SetBool("Dash", false);
            DashCool = 0;
            isDash = false;
            isLook = false;
            yield break;
        }
    }

    IEnumerator PlayerEnemyDistance()
    {
        yield return null;
    }

    void LookPlayer()
    {   
        if (transform.position.x < Target.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isLook = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isLook = true;
        }
        
    }
}
