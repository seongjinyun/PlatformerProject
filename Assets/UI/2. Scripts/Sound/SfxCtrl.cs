using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtrl : MonoBehaviour
{
    public AudioSource SfxSource;
    public AudioClip jumpsound;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
    }

    public void jump()
    {
        SfxSource.PlayOneShot(jumpsound);
    }
}
