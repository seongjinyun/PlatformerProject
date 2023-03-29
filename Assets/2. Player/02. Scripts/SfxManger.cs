using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManger : MonoBehaviour
{
    public static SfxManger instance; //싱글턴
    public AudioSource sfx;

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


    public void SfxPlay(string sfxName, AudioClip clip)
    {
        GameObject sound = new GameObject(sfxName + "Sound");
        AudioSource audiosource = sound.AddComponent<AudioSource>();
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
