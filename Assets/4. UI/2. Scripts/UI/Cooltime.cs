using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Cooltime : MonoBehaviour
{
    public Image image_fill;
    bool isuesd;
    public float cooltime;
    public TMP_Text cooltxt;


    private float currentCooldown;
    void Start()
    {
        //image_fill.fillAmount = 1;
    }

    void Update()
    {
        currentCooldown = Player_Move.Dash_timer;
        if (currentCooldown <= 0)
        {
            // �뽬 ��Ÿ���� 0 ������ �� UI �����
            cooltxt.enabled = false;
        }
        else
        {
            // �뽬 ��Ÿ���� 0 �ʰ��� �� UI ���� �� ǥ��
            cooltxt.enabled = true;
            cooltxt.text = Mathf.CeilToInt(currentCooldown).ToString();
        }
    }
}

    /*if (Input.GetKeyDown(KeyCode.Z))
    {
        if (isuesd == false)
        {
            *//*StartCoroutine("DashCool");
            isuesd = true;
            Invoke("dashdelay", cooltime);*//*

            StartCooldown();
        }
    }*/

/*    void StartCooldown()
    {
        isuesd = true;

        if (currentCooldown <= 0f)
        {
            // ��Ÿ���� 0���� ��� UI�� ���ڸ� ǥ������ ����
            cooldownText.text = "";
        }
        else
        {
            // ���� ��Ÿ���� UI�� ǥ��
            cooldownText.text = currentCooldown.ToString("0");
        }
    }*/

    /*    IEnumerator DashCool()
        {
            while (Player_Move.Dash_timer > 0)
            {
                image_fill.fillAmount -= 1 * Time.smoothDeltaTime / cooltime;
                yield return null;
            }
            yield break;

        }

        void dashdelay()
        {
            isuesd = false;
            cooltime = 5;
        }*/

