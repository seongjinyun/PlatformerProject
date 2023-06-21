using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HpBar : MonoBehaviour
{
    Monster_Stats stat;
    public GameObject Boss;
    public Slider BossHpbar;
    public float maxhp, curhp;
    

    void Start()
    {

        Boss = GameObject.FindWithTag("Monster");

        stat = Boss.GetComponent<Monster_Stats>();

        maxhp = stat.Monster_hpMax;
        curhp = stat.Monster_currentHp;
        
        BossHpbar.value = (float)curhp / (float)maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        curhp = stat.Monster_currentHp;

        BossHp();
    }

    private void BossHp()
    {
        BossHpbar.value = (float)curhp / (float)maxhp;
    }
}
