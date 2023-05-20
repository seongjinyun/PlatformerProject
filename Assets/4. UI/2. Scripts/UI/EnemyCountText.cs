using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyCountText : MonoBehaviour
{
    public TMP_Text enemycounttext;

    public int curkillcount;
    private void Start()
    {
        
    }
    void Update()
    {
        curkillcount = EnemyCountManager.instance.KillMonsterCount;
        if(SceneManager.GetActiveScene().name == "1_Stage")
        {
            enemycounttext.text = "接食 旋 : " + curkillcount + " /" + EnemyCountManager.instance.onestage;
        }
        if (SceneManager.GetActiveScene().name == "2_Stage")
        {
            enemycounttext.text = "接食 旋 : " + curkillcount + " /" + EnemyCountManager.instance.twostage;
        }
        if (SceneManager.GetActiveScene().name == "3_Stage")
        {
            enemycounttext.text = "接食 旋 : " + curkillcount + " /" + EnemyCountManager.instance.threestage;
        }
        if (SceneManager.GetActiveScene().name == "4_Stage")
        {
            enemycounttext.text = "接食 旋 : " + curkillcount + " /" + EnemyCountManager.instance.fourstage;
        }

    }
}
