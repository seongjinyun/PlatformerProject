using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SfxManger : MonoBehaviour
{
    public static SfxManger instance; //싱글턴
    public AudioMixer mixer;

    public Slider Sfx_Slider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance); //사라지지않게
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("SFX", Mathf.Log10(Sfx_Slider.value) * 20);
    }

    public void SfxPlay(string sfxName, AudioClip clip)
    {
        GameObject sound = new GameObject(sfxName + "Sound");
        AudioSource audiosource = sound.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(sound, clip.length);
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
