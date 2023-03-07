using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss_new : Boss3
{
    static bool FireBossRoom;
    public bool isDash, isLook;
    public float DashCool = 0;
    public float BreathCool = 0;
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
        DashCool += Time.deltaTime;
        BreathCool += Time.deltaTime;

        if(isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Dash", true);
        }
        /*
        if(BreathCool >= 10)
        {
            StartCoroutine(BossBreath());

        }
        if (Vector2.Distance(transform.position, Target.transform.position) >= 20)
        {
            isDash = true;
        }
        if(isDash == true && DashCool >= 20 && FireBossRoom == true)
        {
            StartCoroutine(BossDash());
        }
        */
    }

    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(0.1f);

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
        yield return new WaitForSeconds(4f);
        anim.SetBool("Dash", false);
        isDash = false;
        StartCoroutine(RandomPattern());
    }

    IEnumerator BossBreath()
    {
        LookPlayer();
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Breath");
        yield return new WaitForSeconds(0.5f);
        GameObject Breath = Instantiate(BreathPrepab);
        Breath.transform.position = BreathPos.transform.position;
        yield return new WaitForSeconds(4f);

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
