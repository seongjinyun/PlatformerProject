using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolManager : MonoBehaviour
{   
    public static bool FirstStageBossDie, SecondStageBossDie, ThirdStageBossDie, FourthStageBossDie; //보스가 죽을 경우 true로 변경
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
