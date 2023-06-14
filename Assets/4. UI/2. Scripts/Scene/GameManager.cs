using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; //�̱��� ó���� �ν��Ͻ� ���� ����
    public TMP_Text txtTitle, btnStartText, btnOptionText, btnQuitText; //�޽��� �ؽ�Ʈ, Ÿ�� �ؽ�Ʈ
    public Button btnStart; //���� ��ư   
    public Button btnOption; //�ɼ� ��ư
    public Button btnBack; //���ξ��̵� ��ư
    public Button btnEscpae; //���� Ż�� ��ư 
    public GameObject LevelSel;
    public GameObject char1, char2, char3;
    public bool Eng, Kr;
    public GameObject Main_Image_KOR, Main_Image_ENG;

    GameObject resetPoint;
    GameObject player;

    private void Awake() 
    {
        //���ӸŴ����� �̱��� ó��
        if (instance == null) instance = this; //�ν��Ͻ��� �������� ������ ���� �ν��Ͻ��� 
        else Destroy(this);                    //�ν��Ͻ��� �����ϸ� ���� �ν��Ͻ��� ���� 
    }


    void Update()
    {
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;

        if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("en"))
        {
            Main_Image_ENG.SetActive(true);
            Main_Image_KOR.SetActive(false);
        }
        else if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("ko-KR"))
        {
            Main_Image_ENG.SetActive(false);
            Main_Image_KOR.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    public void SelectStart() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {
        LoadingSceneController.LoadScene("UI_Select");
        BoolManager.FirstStageBossDie = false;
        BoolManager.SecondStageBossDie = false;
        BoolManager.ThirdStageBossDie = false;
        BoolManager.FourthStageBossDie = false;
    }
    public void TutorialStart() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {
        LoadingSceneController.LoadScene("Tutorial");

        BoolManager.FirstStageBossDie = false;
        BoolManager.SecondStageBossDie = false;
        BoolManager.ThirdStageBossDie = false;
        BoolManager.FourthStageBossDie = false;
    }
    public void LevSel()
    {
        LevelSel.SetActive(true);
    }
/*    public void TutorialStart_Esay() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {   
        LoadingSceneController.LoadScene("Tutorial");
        Debug.Log("���ӽ���");
        BoolManager.PlayerDie = false;
        Easy = true;
    }
    public void TutorialStart_Hard() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {
        LoadingSceneController.LoadScene("Tutorial");
        Debug.Log("���ӽ���");
        BoolManager.PlayerDie = false;
        Hard = true;
    }*/

    public void Quit() //���� ���� �Լ� (QUIT ��ư�� ������ ����)
    {
        Application.Quit();
    }

    public void GameMain()
    {
        LoadingSceneController.LoadScene("UI_Main");
        Debug.Log("���θ޴��� �̵�");
        UI_Test.instance_ui.Resume();
    }
    public void Escape()
    {
        player = GameObject.FindWithTag("Player");
        resetPoint = GameObject.FindWithTag("RESPAWN");
        player.transform.position = resetPoint.transform.position;
    }
    public void LangENG()
    {
        LocalizationSettings.SelectedLocale =
           LocalizationSettings.AvailableLocales.Locales[0];
    }
    public void LangKOR()
    {
        LocalizationSettings.SelectedLocale =
           LocalizationSettings.AvailableLocales.Locales[1];
    }
    
    public void Mode_Scene()
    {
        LoadingSceneController.LoadScene("FinalBoss_ModeScene");
    }
}
