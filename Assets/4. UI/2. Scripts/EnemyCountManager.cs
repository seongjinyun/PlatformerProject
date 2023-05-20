using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyCountManager : MonoBehaviour
{
    public static EnemyCountManager instance;
    public int onestage, twostage, threestage, fourstage;
    public bool one, two, three, four;
    public int KillMonsterCount;
    private void Awake()
    {
        //게임매니저를 싱글턴 처리
        if (instance == null) instance = this; //인스턴스가 존재하지 않으면 현재 인스턴스로 
        else Destroy(this);                    //인스턴스가 존재하면 현재 인스턴스를 삭제 
    }
    void Start()
    {
        one = false;
        two = false;
        three = false;
        four = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "1_Stage" && one == false)
        {
            GameObject[] onestagecount = GameObject.FindGameObjectsWithTag("Monster");
            onestage = onestagecount.Length;

            one = true;
        }
        if (SceneManager.GetActiveScene().name == "2_Stage" && two == false)
        {
            GameObject[] twostagecount = GameObject.FindGameObjectsWithTag("Monster");
            twostage = twostagecount.Length;

            two = true;
        }
        if (SceneManager.GetActiveScene().name == "3_Stage" && three == false)
        {
            GameObject[] threestagecount = GameObject.FindGameObjectsWithTag("Monster");
            threestage = threestagecount.Length;

            three = true;
        }
        if (SceneManager.GetActiveScene().name == "4_Stage" && four == false)
        {
            GameObject[] fourstagecount = GameObject.FindGameObjectsWithTag("Monster");
            fourstage = fourstagecount.Length;

            four = true;
        }
    }
}
