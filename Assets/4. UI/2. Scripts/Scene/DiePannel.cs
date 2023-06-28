using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePannel : MonoBehaviour
{
    public GameObject Diepannel;
    public GameObject PauseCan;
    void Start()
    {
        Diepannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.PlayerDie == true)
        {
            Diepannel.SetActive(true);
            Destroy(PauseCan);
        }
        else if(BoolManager.PlayerDie == false)
        {
            Diepannel.SetActive(false);
        }
    }
}
