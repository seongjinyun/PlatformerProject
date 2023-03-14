using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Boss : Basic_Boss
{   
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
    }

    IEnumerator BossDash()
    {
        base.LookPlayer();//�÷��̾� ���� �ٶ󺸱�
        isDash = true;
        DashPos.SetActive(true);
        yield return new WaitForSeconds(1.5f); //���� ���� �ð�
        transform.position = Vector2.MoveTowards(transform.position, DashDir.position, speed * Time.deltaTime); // �������濡 DashDir��� �� ������Ʈ �����ؼ� ����(�������� �����ϰԲ�) Ÿ�� ���������� �ϸ� �̻��ϰ� �ȵ�
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
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Attack", false);
        StartCoroutine(RandomPattern());
    }
    IEnumerator RandomPattern()
    {
        yield return new WaitForSeconds(2.0f); //���� ���̿� ������ ���� �ð�

        int ranPattern = Random.Range(0, 2);
        switch (ranPattern)
        {
            case 0:
                StartCoroutine(BossDash());
                break;
            case 1:
                StartCoroutine(TeleAttack());
                break;
        }
    }
}
