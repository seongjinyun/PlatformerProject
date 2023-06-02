using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Buttonclick : MonoBehaviour
{
    private void Update()
    {
        
    }
    public GameObject swordman, spearman, shieldman;
    // Update is called once per frame
    public void click()
    {
        if(DataMgr.instance.currentCharacter == Character.Sword)
        {
            EventSystem.current.SetSelectedGameObject(swordman);
        }
        else if (DataMgr.instance.currentCharacter == Character.Spear)
        {
            EventSystem.current.SetSelectedGameObject(spearman);
        }
        else if (DataMgr.instance.currentCharacter == Character.Shield)
        {
            EventSystem.current.SetSelectedGameObject(shieldman);
        }
    }
}
