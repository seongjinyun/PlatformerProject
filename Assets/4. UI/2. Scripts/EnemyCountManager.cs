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
        //���ӸŴ����� �̱��� ó��
        if (instance == null) instance = this; //�ν��Ͻ��� �������� ������ ���� �ν��Ͻ��� 
        else Destroy(this);                    //�ν��Ͻ��� �����ϸ� ���� �ν��Ͻ��� ���� 
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
