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

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
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
        }
    }

    public void SetSFXVolume() // ȿ���� ���� ����
    {
        mixer.SetFloat("SFX", Mathf.Log10(Sfx_Slider.value) * 20);
    }
    public void SetBGMVolume() // ����� ���� ����
    {
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
        bgm.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0]; // ����� �ͼ� �׷� ��������
        bgm.clip = clip;
        bgm.loop = true; // ��� �ݺ� �ǰ�
        bgm.volume = 0.1f; 
        bgm.Play(); // �÷��� �Լ� ȣ��
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
