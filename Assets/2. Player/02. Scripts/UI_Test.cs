using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Test : MonoBehaviour
{
    public static UI_Test instance_ui; //�̱���

    private void Awake()
    {

        if (instance_ui == null)
        {
            instance_ui = this; //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ����Ŵ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�
            DontDestroyOnLoad(instance_ui); //��������ʰ�
            
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
