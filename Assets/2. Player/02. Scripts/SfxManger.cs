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

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
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
        }
    }

    public void SetSFXVolume() // 효과음 사운드 조절
    {
        mixer.SetFloat("SFX", Mathf.Log10(Sfx_Slider.value) * 20);
    }
    public void SetBGMVolume() // 배경음 사운드 조절
    {
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
        bgm.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0]; // 오디오 믹서 그룹 가져오기
        bgm.clip = clip;
        bgm.loop = true; // 계속 반복 되게
        bgm.volume = 0.1f; 
        bgm.Play(); // 플레이 함수 호출
     }
    // Start is called before the first frame update
    void Start()
    {
        Bgm_Slider.CompareTag("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
