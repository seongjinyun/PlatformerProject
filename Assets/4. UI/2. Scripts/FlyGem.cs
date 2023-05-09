using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGem : MonoBehaviour
{
    public GameObject flygem,flygem2;
    Mode_Select mode;
    // Update is called once per frame
    void Update()
    {
        if(BoolManager.BonginCom == true && mode.Easy == true)
        {
            flygem.SetActive(true);
        }
        if (BoolManager.BonginCom == true && mode.Hard == true)
        {
            flygem2.SetActive(true);
        }
    }
}
