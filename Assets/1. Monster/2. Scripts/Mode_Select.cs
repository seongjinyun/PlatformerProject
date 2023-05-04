using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode_Select : MonoBehaviour
{
    // 모드 선택
    public bool Easy = false;
    public bool Hard = false;

    public void TutorialStart_Esay() //게임 시작 함수 (시작 버튼을 누르면 실행됨)
    {
        LoadingSceneController.LoadScene("Tutorial");
        Debug.Log("게임시작");
        BoolManager.PlayerDie = false;
        Easy = true;
        Debug.Log("이지난이도 선택");
    }
    public void TutorialStart_Hard() //게임 시작 함수 (시작 버튼을 누르면 실행됨)
    {
        LoadingSceneController.LoadScene("Tutorial");
        Debug.Log("게임시작");
        BoolManager.PlayerDie = false;
        Hard = true;
        Debug.Log("하드난이도 선택");
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
