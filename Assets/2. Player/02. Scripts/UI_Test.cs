using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Test : MonoBehaviour
{
    public static UI_Test instance_ui; //�̱���
    public Canvas canvasToDisable;
    public GameObject pause_MenuCanvas;
    private void Awake()
    {
        if (instance_ui == null)
        {
            instance_ui = this; //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ����Ŵ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�
            DontDestroyOnLoad(instance_ui); //��������ʰ�
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Resume()
    {
        pause_MenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        //GameIsPaused = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableButton()
    {
        Button button = canvasToDisable.transform.Find("Pause").GetComponent<Button>();
        button.gameObject.SetActive(false);
    }

    public void EnableButton()
    {
        Button button = canvasToDisable.transform.Find("Pause").GetComponent<Button>();
        button.gameObject.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UI_Select")
        {
            DisableButton();
        }
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            EnableButton();
        }
    }
}
