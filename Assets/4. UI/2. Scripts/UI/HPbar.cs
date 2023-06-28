using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HPbar : MonoBehaviour
{
    AllUnits.Unit CurHp;
    public GameObject HP;
    public TMP_Text hp;
    public Slider hpbar;

    private int maxhp = 5;

    public float curhp;
    void Start()
    {
        HP = GameObject.FindWithTag("Player");

        CurHp = HP.GetComponent<AllUnits.Unit>();
        curhp = CurHp.currentHealth;
        hpbar.value = (float)curhp / (float)maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = curhp + "/ 3";
        curhp = CurHp.currentHealth;

        handleHp();
    }

    private void handleHp()
    {
        hpbar.value = (float)curhp / (float)maxhp;
    }
}
