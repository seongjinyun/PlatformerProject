using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode_Select : MonoBehaviour
{
    // ��� ����
    public bool Easy = false;
    public bool Hard = false;

    public void TutorialStart_Esay() //���� ���� �Լ� (���� ��ư�� ������ �����)
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
