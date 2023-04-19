using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Test : MonoBehaviour
{
    public static UI_Test instance_ui; //싱글턴

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
