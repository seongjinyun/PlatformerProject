using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BgmSource;
    public AudioSource SfxSource;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetBgmVolume(float volume)
    {
        BgmSource.volume = volume;
    }

    public void SfxVolume(float sfxvolume)
    {
        SfxSource.volume = sfxvolume;
    }
}
