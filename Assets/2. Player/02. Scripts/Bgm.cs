using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bgm : MonoBehaviour
{
    public AudioClip[] bgmlist1;
    public AudioSource bgm1; //����� ������ҽ�
    public static Bgm instance1; //�̱���
    public AudioMixer mixer1; //����� �ͼ� ����

    


    private void Awake()
    {
        if (instance1 == null)
        {
            instance1 = this; //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ����Ŵ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�
            //DontDestroyOnLoad(instance1); //��������ʰ�
            
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
