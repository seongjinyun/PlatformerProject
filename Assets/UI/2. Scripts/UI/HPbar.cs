using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HPbar : MonoBehaviour
{
    public TMP_Text hp;
    public Slider hpbar;

    private int maxhp = 100;

    public float curhp;
    void Start()
    {   
        curhp = Player_Move.Player_Hp;
        hpbar.value = (float)curhp / (float)maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = curhp + "/ 100";
        curhp = Player_Move.Player_Hp;

        handleHp();
    }

    private void handleHp()
    {
        hpbar.value = (float)curhp / (float)maxhp;
    }
}
