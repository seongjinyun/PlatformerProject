using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Boss : Basic_Boss
{
    public Transform BreathPos, MeteorPos;
    public GameObject BreathPrepab, MeteorPrepab;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomPattern());
    }
    protected override void Update()
    {
        if (isDash == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime);
            anim.SetBool("Dash", true);
        }
    }
    IEnumerator BossDash()
    {
        base.LookPlayer();//�÷��̾� ���� �ٶ󺸱�
        isDash = true;
        yield return new WaitForSeconds(1.5f); //���� ���� �ð�
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime); // �������濡 DashDir��� �� ������Ʈ �����ؼ� ����(�������� �����ϰԲ�) Ÿ�� ���������� �ϸ� �̻��ϰ� �ȵ�
        yield return new WaitForSeconds(2.5f);
        isDash = false;
        anim.SetBool("Dash", false);
        StartCoroutine(RandomPattern());
    }

    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //���� ���̿� ������ ���� �ð�

        int ranPattern = Random.Range(0, 3);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(FireBreath());
                break;
            case 1:
                StartCoroutine(BossDash());
                break;
            case 2:
                StartCoroutine(FireMeteor());
                break;
        }
    }
    IEnumerator FireBreath()
    {
        LookPlayer();

        anim.SetBool("Breath", true);
        yield return new WaitForSeconds(0.4f);
        GameObject Breath = Instantiate(BreathPrepab, BreathPos.position, BreathPos.rotation);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("Breath", false);
        StartCoroutine(RandomPattern());

    }

    IEnumerator FireMeteor()
    {
        anim.SetBool("Meteor", true);
        GameObject Breath = Instantiate(MeteorPrepab, MeteorPos.position, MeteorPos.rotation);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("Meteor", false);
        StartCoroutine(RandomPattern());


    }
}
