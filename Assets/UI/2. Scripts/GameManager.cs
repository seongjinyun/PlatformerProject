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

    public void GameStart() //���� ���� �Լ� (���� ��ư�� ������ �����)
    {
        SceneManager.LoadScene("UI_Tutorial");
        Debug.Log("���ӽ���");
    }

    public void GameOption() //���� ���� �Լ� (�ɼ� ��ư�� ������ �����)
    {
        SceneManager.LoadScene("UI_Option");
        Debug.Log("�ɼǾ����� �̵�");
    }
    public void Quit() //���� ���� �Լ� (QUIT ��ư�� ������ ����)
    {
        Application.Quit();
    }

    public void GameMain()
    {
        SceneManager.LoadScene("UI_Main");
        Debug.Log("���θ޴��� �̵�");
    }
}
