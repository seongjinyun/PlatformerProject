using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonginPortal: MonoBehaviour
{
    public GameObject Bong;

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.IsBongin == true)
        {
            Bong.SetActive(true);
        }
    }
}
