using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteChange : MonoBehaviour
{
    public Sprite SwordSel, SwordDesel, SpearSel, SpearDeSel, ShieldSel, ShieldDeSel;
    public GameObject SwordBtn, SpearBtn, ShieldBtn;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (DataMgr.instance.currentCharacter == Character.Sword)
        {
            SwordBtn.GetComponent<Image>().sprite = SwordSel;
            SpearBtn.GetComponent<Image>().sprite = SpearDeSel;
            ShieldBtn.GetComponent<Image>().sprite = ShieldDeSel;
        }
        else if (DataMgr.instance.currentCharacter == Character.Spear)
        {
            SwordBtn.GetComponent<Image>().sprite = SwordDesel;
            SpearBtn.GetComponent<Image>().sprite = SpearSel;
            ShieldBtn.GetComponent<Image>().sprite = ShieldDeSel;
        }
        else if (DataMgr.instance.currentCharacter == Character.Shield)
        {
            SwordBtn.GetComponent<Image>().sprite = SwordDesel;
            SpearBtn.GetComponent<Image>().sprite = SpearDeSel;
            ShieldBtn.GetComponent<Image>().sprite = ShieldSel;
        }
    }
}
