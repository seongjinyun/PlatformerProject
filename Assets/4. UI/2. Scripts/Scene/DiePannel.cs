using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePannel : MonoBehaviour
{
    public GameObject Diepannel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BoolManager.PlayerDie == true)
        {
            Diepannel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
