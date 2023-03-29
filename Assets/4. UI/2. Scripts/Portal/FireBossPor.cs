using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossPor : MonoBehaviour
{
    public GameObject FireBossStagePor;

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.FirstStageBossDie == true)
        {
            FireBossStagePor.SetActive(true);
        }
    }
}
