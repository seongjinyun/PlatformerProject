using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBossPortal: MonoBehaviour
{
    public GameObject IceBossPor;

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.SecondStageBossDie == true)
        {
            IceBossPor.SetActive(true);
        }
    }
}
