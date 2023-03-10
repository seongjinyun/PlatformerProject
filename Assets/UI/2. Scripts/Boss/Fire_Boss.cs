using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Boss : Basic_Boss
{
    public Transform BreathPos;
    public GameObject BreathPrepab;

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

        int ranPattern = Random.Range(0, 2);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(FireBreath());
                break;
            case 1:
                StartCoroutine(BossDash());
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
}
