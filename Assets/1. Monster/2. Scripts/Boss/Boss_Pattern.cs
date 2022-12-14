using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Pattern : MonoBehaviour
{   
    private bool isAttacking = false;
    Vector3 playerPos;
    Vector3 whereToAtk;
    public GameObject warning;
    public GameObject Atk1;
    
    //���� ������ �� ������Ʈ�� ����� �ݶ��̴��� �ְ� ������ ����

    private void OnTriggerStay2D(Collider2D other) // �÷��̾� �±� ���˽� �ڷ�ƾ ����
    {
        if (other.tag == "Player")
        {
            playerPos = other.transform.position; // ���˵� ��ġ�� Pos�� �־���
            StartCoroutine("BeforeAttack");
        }

    }
    // OntriggerStay�� ������ ������ ����Ǳ� ������ �ڷ�ƾ�� �̿�
    // isAttacking ������ �̿��� false�϶��� ������ �ϵ��� ����
    IEnumerator BeforeAttack()
    {
        if (isAttacking == false)
        {
            whereToAtk = playerPos;
            isAttacking = true;
            Debug.Log("������ ��ġ : " + whereToAtk);
            Instantiate(warning, whereToAtk, transform.rotation); 
            // ���� (warning �����տ� 2�ʵ� �����Ǵ� Destroy�� �־��� - pattern��ũ��Ʈ)
            yield return new WaitForSeconds(2f);
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack() // ����
    {
        Debug.Log("�׷��� ��������");
        Instantiate(Atk1, whereToAtk, transform.rotation);
        yield return new WaitForSeconds(1f);
        Debug.Log("���� ����");
        isAttacking = false;
    }
}
