using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGem : MonoBehaviour
{
    public GameObject flygem;

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.BonginCom == true)
        {
            flygem.SetActive(true);
        }
    }
}
