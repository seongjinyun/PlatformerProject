using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageIntro : MonoBehaviour
{
    public GameObject StageInt;
    public TMP_Text StageText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "1_Stage")
        {
            StageText.text = "1�������� : ###����";
            Invoke("SetActivefalse", 2);
        }

        // �� ��ȯ �� bool�� ������ false���� true�� ���� ��, �� ��� SetActive(true)�� ���� ������Ʈ �� �ϰ� �������� ���� �ؽ�Ʈ�� ����
    }

    void SetActivefalse()
    {
        StageInt.SetActive(false);
    }
}
