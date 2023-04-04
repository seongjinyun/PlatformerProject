using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossPortal: MonoBehaviour
{
    public GameObject FireBossPor;

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.ThirdStageBossDie == true)
        {
            FireBossPor.SetActive(true);
        }
    }
}
