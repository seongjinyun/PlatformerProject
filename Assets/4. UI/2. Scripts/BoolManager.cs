using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolManager : MonoBehaviour
{   
    public static bool FirstStageBossDie, SecondStageBossDie, ThirdStageBossDie, FourthStageBossDie; //������ ���� ��� true�� ����
    public static bool IsTutorial;

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
    }
    void Update()
    {

    }
}
