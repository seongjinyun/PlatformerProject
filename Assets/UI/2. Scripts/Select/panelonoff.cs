using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelonoff : MonoBehaviour
{
    public GameObject sword, spear, shield, swordstat, spearstat, shieldstat,swordstar, spearstar,shieldstar;

    PanelCtrl panelCtrl;
    // Update is called once per frame
    void Update()
    {
        if (DataMgr.instance.currentCharacter == Character.Sword)
        {
            sword.SetActive(false);
            spear.SetActive(true);
            shield.SetActive(true);
            swordstat.SetActive(true);
            spearstat.SetActive(false);
            shieldstat.SetActive(false);
            swordstar.SetActive(true);
            spearstar.SetActive(false);
            shieldstar.SetActive(false);
        }
        else if(DataMgr.instance.currentCharacter == Character.Spear)
        {
            sword.SetActive(true);
            spear.SetActive(false);
            shield.SetActive(true);
            swordstat.SetActive(false);
            spearstat.SetActive(true);
            shieldstat.SetActive(false);
            swordstar.SetActive(false);
            spearstar.SetActive(true);
            shieldstar.SetActive(false);
        }
        else
        {
            sword.SetActive(true);
            spear.SetActive(true);
            shield.SetActive(false);
            swordstat.SetActive(false);
            spearstat.SetActive(false);
            shieldstat.SetActive(true);
            swordstar.SetActive(false);
            spearstar.SetActive(false);
            shieldstar.SetActive(true);
        }
       
    }
}
