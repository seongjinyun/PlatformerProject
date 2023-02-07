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
    
    void Start()
    {
        image_fill.fillAmount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            {
            if (isuesd == false)
            {
                StartCoroutine("DashCool");
                isuesd = true;
                Invoke("dashdelay", cooltime);
            }
        } 
        
        if(Player_Move.Dash_timer < 0)
        {
            image_fill.fillAmount = 1;
        }
        
    }

    IEnumerator DashCool()
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
    }
}
