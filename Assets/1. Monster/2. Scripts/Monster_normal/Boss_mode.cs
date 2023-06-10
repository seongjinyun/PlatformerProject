using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_mode : Basic_Boss
{
    public Transform Tornado1, Tornado2, Tornado3, Tornado4, BulletPos, MeteorPos, Skill_pos_2;
    public GameObject TornadoPrefab, MeteorPrepab, Attack_Skill_2;
    public GameObject bullet;

    public GameObject BreathPrepab;
    public Transform BreathPos;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        StartCoroutine(RandomPattern());

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator RandomPattern()
    {
        anim.SetBool("Stun", true);
        yield return new WaitForSeconds(3.0f); //패턴 사이에 나오는 경직 시간
        anim.SetBool("Stun", false);
        yield return new WaitForSeconds(0.5f);
        if (!MonsterDie)
        {
            int ranPattern = Random.Range(0, 5);
            switch (ranPattern)
            {
                case 0:
                    StartCoroutine(TeleAttack());
                    break;
                case 1:
                    StartCoroutine(SpawnTornado());
                    break;
                case 2:
                    StartCoroutine(SpawnBullet());

                    break;
                case 3:
                    StartCoroutine(Second_Attack());
                    break;
                case 4:
                    StartCoroutine(FireMeteor());
                    break;
            }
        }
    }
    IEnumerator Second_Attack()
    {
        base.LookPlayer();

        anim.SetTrigger("Skill_2");
        //SfxManger.instance.SfxPlay("Ice_Skill_explosion", clip[1]);
        yield return new WaitForSeconds(1f); // 1초 뒤에
        GameObject Skill_2 = Instantiate(Attack_Skill_2, Skill_pos_2.position, Skill_pos_2.rotation); //인스턴시에이트
        Destroy(Skill_2, 2f);
        StartCoroutine(RandomPattern());

    }

    IEnumerator TeleAttack() // 텔레포트 후 브레스
    {
        transform.position = Target.transform.position;
        yield return new WaitForSeconds(0.8f);
        base.LookPlayer();
        anim.SetTrigger("TeleAttack");
        //SfxManger.instance.SfxPlay("Fire_Skill_breath", clip[1]);
        yield return new WaitForSeconds(0.3f);
        GameObject Breath = Instantiate(BreathPrepab, BreathPos.position, BreathPos.rotation);

        yield return new WaitForSeconds(0.8f);
        StartCoroutine(RandomPattern());
    }
    IEnumerator SpawnTornado()
    {
        anim.SetTrigger("Skill_1");        //SfxManger.instance.SfxPlay("Wind_Skill_Tornado", clip[0]);
        yield return new WaitForSeconds(1f);
        GameObject Tor1 = Instantiate(TornadoPrefab, Tornado1.position, Tornado1.rotation);
        GameObject Tor2 = Instantiate(TornadoPrefab, Tornado2.position, Tornado1.rotation);
        GameObject Tor3 = Instantiate(TornadoPrefab, Tornado3.position, Tornado1.rotation);
        GameObject Tor4 = Instantiate(TornadoPrefab, Tornado4.position, Tornado1.rotation);

        yield return new WaitForSeconds(3.5f);

        StartCoroutine(RandomPattern());


    }
    IEnumerator SpawnBullet()
    {
        base.LookPlayer();
        anim.SetTrigger("Skill_1");
        //SfxManger.instance.SfxPlay("Wind_Skill_smallTor", clip[1]);
        yield return new WaitForSeconds(0.8f);
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
            temp.transform.rotation = Quaternion.Euler(0, 0, i + 10);
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
        StartCoroutine(RandomPattern());

    }
    IEnumerator FireMeteor()
    {
        anim.SetBool("Skill_1", true);
        //SfxManger.instance.SfxPlay("Fire_Skill_Meteor", clip[2]);
        GameObject Breath = Instantiate(MeteorPrepab, MeteorPos.position, MeteorPos.rotation);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(RandomPattern());


    }
}
