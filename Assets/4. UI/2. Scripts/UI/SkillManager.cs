using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Image image_fill;
    public float time_coolTime = 5;

    private float time_current;
    private bool isEnded = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Trigger_Skill();
        }
        if (isEnded)
            return;
        Check_CoolTime();
    }

    void Check_CoolTime()
    {
        time_current += Time.deltaTime;
        if(time_current < time_coolTime)
        {
            Set_FillAmount(time_current);
        }
        else if (!isEnded)
        {
            End_CoolTime();
        }
    }
    void End_CoolTime()
    {
        Set_FillAmount(time_coolTime);
        isEnded = true;
    }

    void Trigger_Skill()
    {
        if (!isEnded) return;

        Reset_CoolTime();
    }

    void Reset_CoolTime()
    {
        time_current = 0;
        Set_FillAmount(0);
        isEnded = false;
    }

    void Set_FillAmount(float value)
    {
        image_fill.fillAmount = value / time_coolTime;
    }
}