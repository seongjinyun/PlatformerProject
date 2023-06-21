using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SfxManger : MonoBehaviour
{
    public AudioClip[] bgmlist;
    public AudioSource bgm; //����� ������ҽ�
    public static SfxManger instance; //�̱���
    public AudioMixer mixer; //����� �ͼ� ����

    public Slider Sfx_Slider; // ������ ȿ���� �����̴�
    public Slider Bgm_Slider; // ������ ����� �����̴�

    private GameObject Music_Check;



    private const string SFXVolumeKey = "SFXVolume";
    private const string BGMVolumeKey = "BGMVolume";

    
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this; //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ����Ŵ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�
            DontDestroyOnLoad(instance); //��������ʰ�
            SceneManager.sceneLoaded += OnSceneLoaded; //�� �̵� �� bgm �޼��� ȣ��
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
            if(arg0.name == bgmlist[i].name) // ���� �̸��� �Ű������� ���ؼ� �˼����� �׸��� ���� �̸��� Ŭ���� �̸��� ��������
                BgmPlay(bgmlist[i]); // ���
            if (GameObject.Find("Music_Chk")) // Music_Chk ���ӿ�����Ʈ ã���� --> Ʃ�丮�� �ʿ� ����
            {
                StopMusic(bgmlist[i]); // ����� ����
                //Sfx_Slider.value = 1; // �����̴� �� �ʱ�ȭ
                //Bgm_Slider.value = 1; // �����̴� �� �ʱ�ȭ
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
    public void SaveSoundVolume() // ���� ���� ����
    {
        float sfxVolume = Mathf.Log10(Sfx_Slider.value) * 20;
        float bgmVolume = Mathf.Log10(Bgm_Slider.value) * 20;

        PlayerPrefs.SetFloat(SFXVolumeKey, sfxVolume);
        PlayerPrefs.SetFloat(BGMVolumeKey, bgmVolume);
        PlayerPrefs.Save();
    }

    public void LoadSoundVolume() // ���� �ҷ�����
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

    public void SetSoundVolume() // ���� ����
    {
        mixer.SetFloat("SFX", Mathf.Log10(Sfx_Slider.value) * 20);
        mixer.SetFloat("BGM", Mathf.Log10(Bgm_Slider.value) * 20);

    }
    
    public void SfxPlay(string sfxName, AudioClip clip) // ���� �Ű����� ���� �̸�, ���� Ŭ��
    {
        GameObject sound = new GameObject(sfxName + "Sound");
        AudioSource audiosource = sound.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0]; // ����� �ͼ� �׷� ��������
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(sound, clip.length);
    }

     public void BgmPlay(AudioClip clip) // �����
     {
        bgm.outputAudioMixerGroup = Bgm.instance1.mixer1.FindMatchingGroups("BGM")[0]; // ����� �ͼ� �׷� ��������
        bgm.clip = clip;
        bgm.loop = true; // ��� �ݺ� �ǰ�
        bgm.volume = 0.1f; 
        bgm.Play(); // �÷��� �Լ� ȣ��
        

     }
    // Start is called before the first frame update
    void Start()
    {
        Music_Check = GameObject.FindGameObjectWithTag("Sfx_Manager"); //����� ���� ������Ʈ �±�
        LoadSoundVolume();
    }
    public void StopMusic(AudioClip clip) // ����� ���� �Լ�
    {
        bgm.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0]; // ����� �ͼ� �׷� ��������
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
