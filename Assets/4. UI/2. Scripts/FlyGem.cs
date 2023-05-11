using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGem : MonoBehaviour
{
    public GameObject flygem,flygem2;
    Mode_Select mode;
    // Update is called once per frame

    private void Start()
    {
        mode = FindObjectOfType<Mode_Select>();

        flygem.SetActive(false);
        flygem2.SetActive(false);

    }
    void Update()
    {
        if (BoolManager.BonginCom == true)
        {
            if(mode.Easy == true)
            {
                flygem.SetActive(true);
            }
            else
            {
                flygem2.SetActive(true);
            }
        }
        else if(BoolManager.BonginCom == false)
        {
            flygem.SetActive(false);
            flygem2.SetActive(false);
        }
    }
}
