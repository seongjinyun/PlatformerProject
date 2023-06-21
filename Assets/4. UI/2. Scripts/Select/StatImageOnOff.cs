using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class StatImageOnOff : MonoBehaviour
{
    public GameObject SwordStat, SpearStat, ShieldStat, SwordImg, SpearImg, ShieldImg ;

    SelectChar selectChar;
    PanelCtrl panelCtrl;
    // Update is called once per frame
    void Update()
    {
        
        if (DataMgr.instance.currentCharacter == Character.Sword)
        {
            SwordImg.SetActive(true);
            SwordStat.SetActive(true);
            SpearImg.SetActive(false);
            SpearStat.SetActive(false);
            ShieldImg.SetActive(false);
            ShieldStat.SetActive(false);
        }
        else if(DataMgr.instance.currentCharacter == Character.Spear)
        {
            SwordImg.SetActive(false);
            SwordStat.SetActive(false);
            SpearImg.SetActive(true);
            SpearStat.SetActive(true);
            ShieldImg.SetActive(false);
            ShieldStat.SetActive(false);

        }
        else if(DataMgr.instance.currentCharacter == Character.Shield)
        {
            SwordImg.SetActive(false);
            SwordStat.SetActive(false);
            SpearImg.SetActive(false);
            SpearStat.SetActive(false);
            ShieldImg.SetActive(true);
            ShieldStat.SetActive(true);

        }
    }
}
