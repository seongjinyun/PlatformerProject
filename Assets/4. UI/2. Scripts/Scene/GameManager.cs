using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글턴 처리용 인스턴스 변수 선언
    public TMP_Text txtTitle, btnStartText, btnOptionText, btnQuitText; //메시지 텍스트, 타임 텍스트
    public Button btnStart; //시작 버튼   
    public Button btnOption; //옵션 버튼
    public Button btnBack; //메인씬이동 버튼
    public GameObject LevelSel;
    public GameObject char1, char2, char3;

    public Mode_Select Mode;

    private void Awake() 
    {
        //게임매니저를 싱글턴 처리
        if (instance == null) instance = this; //인스턴스가 존재하지 않으면 현재 인스턴스로 
        else Destroy(this);                    //인스턴스가 존재하면 현재 인스턴스를 삭제 

        Mode = FindObjectOfType<Mode_Select>();

    }


    void Update()
    {

    }
    void Start()
    {
        
    }

    public void SelectStart() //게임 시작 함수 (시작 버튼을 누르면 실행됨)
    {
        LoadingSceneController.LoadScene("UI_Select");
        Debug.Log("게임시작");
    }
    public void CharSel()
    {
        LevelSel.SetActive(true);
        char1.SetActive(false); 
        char2.SetActive(false);
        char3.SetActive(false);
    }
/*    public void TutorialStart_Esay() //게임 시작 함수 (시작 버튼을 누르면 실행됨)
    {   
        LoadingSceneController.LoadScene("Tutorial");
        Debug.Log("게임시작");
        BoolManager.PlayerDie = false;
        Easy = true;
    }
    public void TutorialStart_Hard() //게임 시작 함수 (시작 버튼을 누르면 실행됨)
    {
        LoadingSceneController.LoadScene("Tutorial");
        Debug.Log("게임시작");
        BoolManager.PlayerDie = false;
        Hard = true;
    }*/

    public void Quit() //게임 정지 함수 (QUIT 버튼을 누르면 실행)
    {
        Application.Quit();
    }

    public void GameMain()
    {
        LoadingSceneController.LoadScene("UI_Main");
        Debug.Log("메인메뉴로 이동");
        UI_Test.instance_ui.Resume();

        Mode.Easy = false;
        Mode.Hard = false;
    }
}
