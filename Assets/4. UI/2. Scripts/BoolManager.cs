using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolManager : MonoBehaviour
{   
    public static bool FirstStageBossDie, SecondStageBossDie, ThirdStageBossDie, FourthStageBossDie; //������ ���� ��� true�� ����
    public static bool IsTutorial;
    public static bool IsBongin;
    public static bool PlayerDie;
    public static bool BonginCom;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        FirstStageBossDie = false;
        SecondStageBossDie = false;
        ThirdStageBossDie = false;
        FourthStageBossDie = false;
        IsBongin = false;
        PlayerDie = false;
        BonginCom = false;

    }
    void Update()
    {

    }
}
