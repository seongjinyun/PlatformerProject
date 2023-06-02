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
        
        if (EventSystem.current.currentSelectedGameObject.name == "SwordMan")
        {
            SwordImg.SetActive(true);
            SwordStat.SetActive(true);
            SpearImg.SetActive(false);
            SpearStat.SetActive(false);
            ShieldImg.SetActive(false);
            ShieldStat.SetActive(false);
            DataMgr.instance.currentCharacter = Character.Sword;
        }
        else if(EventSystem.current.currentSelectedGameObject.name == "SpearMan")
        {
            SwordImg.SetActive(false);
            SwordStat.SetActive(false);
            SpearImg.SetActive(true);
            SpearStat.SetActive(true);
            ShieldImg.SetActive(false);
            ShieldStat.SetActive(false);
            DataMgr.instance.currentCharacter = Character.Spear;

        }
        else if(EventSystem.current.currentSelectedGameObject.name == "ShieldMan")
        {
            SwordImg.SetActive(false);
            SwordStat.SetActive(false);
            SpearImg.SetActive(false);
            SpearStat.SetActive(false);
            ShieldImg.SetActive(true);
            ShieldStat.SetActive(true);
            DataMgr.instance.currentCharacter = Character.Shield;

        }
    }
}
