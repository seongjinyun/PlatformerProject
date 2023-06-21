using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SfxManger : MonoBehaviour
{
    public AudioClip[] bgmlist;
    public AudioSource bgm; //배경음 오디오소스
    public static SfxManger instance; //싱글턴
    public AudioMixer mixer; //오디오 믹서 변수

    public Slider Sfx_Slider; // 유아이 효과음 슬라이더
    public Slider Bgm_Slider; // 유아이 배경음 슬라이더

    private GameObject Music_Check;



    private const string SFXVolumeKey = "SFXVolume";
    private const string BGMVolumeKey = "BGMVolume";

    
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this; //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 사운드매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다
            DontDestroyOnLoad(instance); //사라지지않게
            SceneManager.sceneLoaded += OnSceneLoaded; //씬 이동 시 bgm 메서드 호출
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) 
    {   
        for (int i = 0; i < bgmlist.Length; i++)
        {
            if(arg0.name == bgmlist[i].name) // 씬의 이름은 매개변수를 통해서 알수있음 그리고 씬의 이름과 클립의 이름이 같은것을
                BgmPlay(bgmlist[i]); // 재생
            if (GameObject.Find("Music_Chk")) // Music_Chk 게임오브젝트 찾으면 --> 튜토리얼 맵에 존재
            {
                StopMusic(bgmlist[i]); // 배경음 정지
                //Sfx_Slider.value = 1; // 슬라이더 값 초기화
                //Bgm_Slider.value = 1; // 슬라이더 값 초기화
            }
        }
        if (arg0.name == "FinalBoss_ModeScene")
        {
            BgmPlay(bgmlist[4]);
        }
        else
        {
            return;
        }
    }
    public void SaveSoundVolume() // 사운드 조절 저장
    {
        float sfxVolume = Mathf.Log10(Sfx_Slider.value) * 20;
        float bgmVolume = Mathf.Log10(Bgm_Slider.value) * 20;

        PlayerPrefs.SetFloat(SFXVolumeKey, sfxVolume);
        PlayerPrefs.SetFloat(BGMVolumeKey, bgmVolume);
        PlayerPrefs.Save();
    }

    public void LoadSoundVolume() // 사운드 불러오기
    {
        if (PlayerPrefs.HasKey(SFXVolumeKey))
        {
            float sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey);
            mixer.SetFloat("SFX", sfxVolume);
            Sfx_Slider.value = Mathf.Pow(10, sfxVolume / 20);
        }

        if (PlayerPrefs.HasKey(BGMVolumeKey))
        {
            float bgmVolume = PlayerPrefs.GetFloat(BGMVolumeKey);
            mixer.SetFloat("BGM", bgmVolume);
            Bgm_Slider.value = Mathf.Pow(10, bgmVolume / 20);
        }
    }

    public void SetSoundVolume() // 사운드 조절
    {
        mixer.SetFloat("SFX", Mathf.Log10(Sfx_Slider.value) * 20);
        mixer.SetFloat("BGM", Mathf.Log10(Bgm_Slider.value) * 20);

    }
    
    public void SfxPlay(string sfxName, AudioClip clip) // 사운드 매개변수 사운드 이름, 사운드 클립
    {
        GameObject sound = new GameObject(sfxName + "Sound");
        AudioSource audiosource = sound.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0]; // 오디오 믹서 그룹 가져오기
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(sound, clip.length);
    }

     public void BgmPlay(AudioClip clip) // 배경음
     {
        bgm.outputAudioMixerGroup = Bgm.instance1.mixer1.FindMatchingGroups("BGM")[0]; // 오디오 믹서 그룹 가져오기
        bgm.clip = clip;
        bgm.loop = true; // 계속 반복 되게
        bgm.volume = 0.1f; 
        bgm.Play(); // 플레이 함수 호출
        

     }
    // Start is called before the first frame update
    void Start()
    {
        Music_Check = GameObject.FindGameObjectWithTag("Sfx_Manager"); //배경음 정지 오브젝트 태그
        LoadSoundVolume();
    }
    public void StopMusic(AudioClip clip) // 배경음 정지 함수
    {
        bgm.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0]; // 오디오 믹서 그룹 가져오기
        bgm.clip = clip;
        bgm.volume = 0.1f;
        bgm.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //LoadSoundVolume();
        
    }
}
