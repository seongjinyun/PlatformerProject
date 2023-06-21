using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Pattern : MonoBehaviour
{   
    public enum Atk_Pattern { Bottom_Atk, Rush_Atk }

    private bool isAttacking = false;
    Vector3 playerPos;
    Vector3 whereToAtk;
    public GameObject warning;
    public GameObject Atk1;

    public bool Skill = false;

    public float ColTime = 20f;
    public float CurTime = 0f;

    void Update()
    {
        
        //Debug.Log(ColTime);
        if (ColTime <= CurTime)
        {
            ColTime = 5f;
            if (Skill == true)
            {
                StartCoroutine("BeforeAttack");
            }
        }
    }
    //���� ������ �� ������Ʈ�� ����� �ݶ��̴��� �ְ� ������ ����

    private void OnTriggerStay2D(Collider2D other) // �÷��̾� �±� ���˽� �ڷ�ƾ ����
    {
        if (other.tag == "Monster_Skill_Pos")
        {
            playerPos = other.transform.position; // ���˵� ��ġ�� Pos�� �־���
            Skill = true;
            //            StartCoroutine("BeforeAttack");
            ColTime -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Monster_Skill_Pos")
        {
            Skill = false;
        }
    }
    // OntriggerStay�� ������ ������ ����Ǳ� ������ �ڷ�ƾ�� �̿�
    // isAttacking ������ �̿��� false�϶��� ������ �ϵ��� ����
    IEnumerator BeforeAttack()
    {
        if (isAttacking == false)
        {
            Atk_Pattern atk_Pattern = Atk_Pattern.Bottom_Atk;
            if (atk_Pattern == Atk_Pattern.Bottom_Atk)
            {
                whereToAtk = playerPos;
                isAttacking = true;
                //Debug.Log("������ ��ġ : " + whereToAtk);
                Instantiate(warning, whereToAtk, transform.rotation);
                // ���� (warning �����տ� 2�ʵ� �����Ǵ� Destroy�� �־��� - pattern��ũ��Ʈ)
                yield return new WaitForSeconds(1f);
                StartCoroutine("Bottom_Attack");
            }
        }
    }

    IEnumerator Bottom_Attack() // ����
    {
        Instantiate(Atk1, whereToAtk, transform.rotation);
        yield return new WaitForSeconds(1f);
        //Debug.Log("���� ����");
        isAttacking = false;
    }

}
