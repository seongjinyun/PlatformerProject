using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Test : MonoBehaviour
{
    public static UI_Test instance_ui; //싱글턴
    public Canvas canvasToDisable;
    public GameObject pause_MenuCanvas;
    private void Awake()
    {
        if (instance_ui == null)
        {
            instance_ui = this; //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 사운드매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다
            DontDestroyOnLoad(instance_ui); //사라지지않게
            
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
