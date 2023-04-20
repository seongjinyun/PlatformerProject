using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Test : MonoBehaviour
{
    public static UI_Test instance_ui; //싱글턴
    public Canvas canvasToDisable;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        // 이동할 씬의 이름과 현재 씬의 이름이 일치하는지 비교
        if (sceneName == "UI_Main" || sceneName == "UI_Select" || sceneName == "UI_Loading" || sceneName == "EndingScene")
        {
            // 특정 씬에서만 canvasToDisable 변수가 참조하는 캔버스를 비활성화
            canvasToDisable.gameObject.SetActive(false);
        }
        else 
        {
            // 다른 씬에서는 캔버스를 활성화
            canvasToDisable.gameObject.SetActive(true);
        }
        // 캔버스를 비활성화한 후, 씬 이동 수행
        SceneManager.LoadScene(sceneName);

        
        // 이전 씬에서 생성된 UI_Test 클래스의 인스턴스 파괴
        if (instance_ui != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
        {
        
        }
}
