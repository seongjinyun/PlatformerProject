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
            // 대쉬 쿨타임이 0 이하일 때 UI 숨기기
            cooltxt.enabled = false;
        }
        else
        {
            // 대쉬 쿨타임이 0 초과일 때 UI 갱신 및 표시
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
            // 쿨타임이 0초일 경우 UI에 숫자를 표시하지 않음
            cooldownText.text = "";
        }
        else
        {
            // 현재 쿨타임을 UI에 표시
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

