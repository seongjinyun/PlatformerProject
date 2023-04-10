using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bgm : MonoBehaviour
{
    public AudioClip[] bgmlist1;
    public AudioSource bgm1; //배경음 오디오소스
    public static Bgm instance1; //싱글턴
    public AudioMixer mixer1; //오디오 믹서 변수

    


    private void Awake()
    {
        if (instance1 == null)
        {
            instance1 = this; //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 사운드매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다
            //DontDestroyOnLoad(instance1); //사라지지않게
            
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
