using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //�̱��� ó���� �ν��Ͻ� ���� ����
    public TMP_Text txtTitle, btnStartText, btnOptionText, btnQuitText; //�޽��� �ؽ�Ʈ, Ÿ�� �ؽ�Ʈ
    public Button btnStart; //���� ��ư   
    public Button btnOption; //�ɼ� ��ư
    public Button btnBack; //���ξ��̵� ��ư
    public GameObject LevelSel;
    public GameObject char1, char2, char3;

    private void Awake() 
    {
        //���ӸŴ����� �̱��� ó��
        if (instance == null) instance = this; //�ν��Ͻ��� �������� ������ ���� �ν��Ͻ��� 
        else Destroy(this);                    //�ν��Ͻ��� �����ϸ� ���� �ν��Ͻ��� ���� 
    }


    void Update()
    {

    }
    void Start()
    {
        
    }

    public void SelectStart() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {
        LoadingSceneController.LoadScene("UI_Select");
        Debug.Log("���ӽ���");
    }
    public void CharSel()
    {
        LevelSel.SetActive(true);
        char1.SetActive(false);
        char2.SetActive(false);
        char3.SetActive(false);
    }
    public void TutorialStart() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {   if (BoolManager.IsTutorial == true)
        {
            LoadingSceneController.LoadScene("1_Stage");
        }
        else
        {
            LoadingSceneController.LoadScene("Tutorial");
            Debug.Log("���ӽ���");
        }
    }
    public void GameOption() //���� ���� �Լ� (�ɼ� ��ư�� ������ �����)
    {
        LoadingSceneController.LoadScene("UI_Option");
        Debug.Log("�ɼǾ����� �̵�");
    }
    public void Quit() //���� ���� �Լ� (QUIT ��ư�� ������ ����)
    {
        Application.Quit();
    }

    public void GameMain()
    {
        LoadingSceneController.LoadScene("UI_Main");
        Debug.Log("���θ޴��� �̵�");
    }
}
