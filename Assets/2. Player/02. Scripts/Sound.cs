using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public void SaveSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFX", volume);
        PlayerPrefs.Save();
    }
    public void SaveBGMVolume(float volume)
    {
        PlayerPrefs.SetFloat("BGM", volume);
        PlayerPrefs.Save();
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
