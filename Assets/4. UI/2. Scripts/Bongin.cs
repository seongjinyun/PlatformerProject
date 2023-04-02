using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bongin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BonginPortal;
    void Start()
    {
        BoolManager.FirstStageBossDie = true;
        BoolManager.SecondStageBossDie = true;
        BoolManager.ThirdStageBossDie = true;
        BoolManager.FourthStageBossDie = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (BoolManager.IsBongin == true && BoolManager.FirstStageBossDie == true && BoolManager.SecondStageBossDie == true && BoolManager.ThirdStageBossDie == true && BoolManager.FourthStageBossDie == true && Input.GetKeyDown(KeyCode.B))
        {
            BonginPortal.SetActive(true);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            BoolManager.IsBongin = true;
        }
        else
        {
            BoolManager.IsBongin = false;
        }
    }
}
