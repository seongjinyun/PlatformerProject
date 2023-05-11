using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoolReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            BoolManager.FirstStageBossDie = false;
            BoolManager.SecondStageBossDie = false;
            BoolManager.ThirdStageBossDie = false;
            BoolManager.FourthStageBossDie = false;

            BoolManager.BonginCom = false;
        }
    }
}
