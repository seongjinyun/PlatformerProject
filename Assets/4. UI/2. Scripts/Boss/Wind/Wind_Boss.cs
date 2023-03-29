using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Boss : Basic_Boss
{
    public Transform Tornado1, Tornado2, Tornado3, Tornado4, BulletPos; 
    public GameObject TornadoPrefab;
    public GameObject bullet;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Dash", true);
        }

        BulletPos.transform.rotation = transform.rotation;

    }

    IEnumerator BossDash()
    {
        base.LookPlayer();//플레이어 방향 바라보기
        isDash = true;
        DashPos.SetActive(true);
        yield return new WaitForSeconds(1.5f); //패턴 피할 시간
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime); // 보스전방에 DashDir라는 빈 오브젝트 생성해서 추적(전방으로 돌진하게끔) 타겟 포지션으로 하면 이상하게 안됨
        yield return new WaitForSeconds(2.5f);
        isDash = false;
        anim.SetBool("Dash", false);
        DashPos.SetActive(false);
        StartCoroutine(RandomPattern());
    }
    IEnumerator TeleAttack()
    {
        transform.position = Target.transform.position;
        yield return new WaitForSeconds(0.5f);
        base.LookPlayer();
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack", false);
        StartCoroutine(RandomPattern());
    }
    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //패턴 사이에 나오는 경직 시간
        if (!MonsterDie)
        {
            int ranPattern = Random.Range(0, 4);
            switch (ranPattern)
            {
                case 0:
                    StartCoroutine(BossDash());
                    break;
                case 1:
                    StartCoroutine(TeleAttack());
                    break;
                case 2:
                    StartCoroutine(SpawnTornado());
                    break;
                case 3:
                    StartCoroutine(SpawnTornado());
                    break;
            }
        }
    }

    IEnumerator SpawnTornado()
    {
        anim.SetBool("Tornado", true);
        yield return new WaitForSeconds(1f);
        GameObject Tor1 = Instantiate(TornadoPrefab, Tornado1.position, Tornado1.rotation);
        GameObject Tor2 = Instantiate(TornadoPrefab, Tornado2.position, Tornado1.rotation);
        GameObject Tor3 = Instantiate(TornadoPrefab, Tornado3.position, Tornado1.rotation);
        GameObject Tor4 = Instantiate(TornadoPrefab, Tornado4.position, Tornado1.rotation);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Tornado", false);
        yield return new WaitForSeconds(3.5f);

        StartCoroutine(SpawnBullet());


    }

    IEnumerator SpawnBullet()
    {
        base.LookPlayer();
        anim.SetBool("Bullet", true);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 360; i += 25)
        {
            GameObject temp = Instantiate(bullet);
            Destroy(temp, 2f);
            temp.transform.position = BulletPos.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 360; i += 25)
        {
            GameObject temp = Instantiate(bullet);
            Destroy(temp, 2f);
            temp.transform.position = BulletPos.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i+10);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 360; i += 25)
        {
            GameObject temp = Instantiate(bullet);
            Destroy(temp, 2f);
            temp.transform.position = BulletPos.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i + 17);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 360; i += 25)
        {
            GameObject temp = Instantiate(bullet);
            Destroy(temp, 2f);
            temp.transform.position = BulletPos.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i + 24);
        }

        yield return new WaitForSeconds(3f);
        anim.SetBool("Bullet", false);
        StartCoroutine(RandomPattern());

    }
}
