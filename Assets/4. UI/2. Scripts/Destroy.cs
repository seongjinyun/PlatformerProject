using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UI_Main" || SceneManager.GetActiveScene().name == "UI_Loading" || SceneManager.GetActiveScene().name == "UI_Select")
        {
            Destroy(gameObject);
        }
/*        else
        {
            DontDestroyOnLoad(gameObject);
        }*/
    }
    private void Awake() // ���� ��������� ĵ���� ���� (UI �±� => �Ȼ������ ĵ����)
    {
        GameObject[] allCanvas = GameObject.FindGameObjectsWithTag("UI");

        if (allCanvas.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
