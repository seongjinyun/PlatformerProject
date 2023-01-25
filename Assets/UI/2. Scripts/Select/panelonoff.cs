using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelonoff : MonoBehaviour
{
    public GameObject sword, spear, shield;

    PanelCtrl panelCtrl;
    // Update is called once per frame
    void Update()
    {
        if (DataMgr.instance.currentCharacter == Character.Sword)
        {
            sword.SetActive(false);
            spear.SetActive(true);
            shield.SetActive(true);
        }
        else if(DataMgr.instance.currentCharacter == Character.Spear)
        {
            sword.SetActive(true);
            spear.SetActive(false);
            shield.SetActive(true);
        }
        else
        {
            sword.SetActive(true);
            spear.SetActive(true);
            shield.SetActive(false);
        }
       
    }
}
