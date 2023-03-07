using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss_new : Boss3
{
    static bool FireBossRoom;
    public bool isDash, isLook;
    public Transform BreathPos;
    public GameObject BreathPrepab;
  
    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
        FireBossRoom = true; //보스 방 입장 시 true로 변경할꺼임
    }
    protected override void Update()
    {
        if(isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Dash", true);
        }   
    }

    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //경직시간

        int ranPattern = Random.Range(0, 2);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(BossBreath());
                break;
            case 1:
                StartCoroutine(BossDash());
                break;
        }
    }

    IEnumerator BossDash()
    {   
        LookPlayer();
        isDash = true;
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(4.0f);
        isDash = false;
        anim.SetBool("Dash", false);
        StartCoroutine(RandomPattern());
    }

    IEnumerator BossBreath()
    {
        LookPlayer();
        
        anim.SetTrigger("Breath");
        yield return new WaitForSeconds(1.0f);
        GameObject Breath = Instantiate(BreathPrepab, BreathPos.position, BreathPos.rotation);
        yield return new WaitForSeconds(2.0f);

        StartCoroutine(RandomPattern());
     
    }

    void LookPlayer()
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

    void TelpoPlayer()
    {
        transform.position = Target.transform.position;
    }
}
