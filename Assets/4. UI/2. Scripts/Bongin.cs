using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bongin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BonginPortal;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {   
        if (BoolManager.IsBongin == true && Input.GetKeyDown(KeyCode.B))
        {
            BonginPortal.SetActive(true);
            BoolManager.BonginCom = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BoolManager.IsBongin = true;
        }
    }

}
