using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Test : MonoBehaviour
{
    public static UI_Test instance_ui; //�̱���
    public Canvas canvasToDisable;

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

    public void LoadScene(string sceneName)
    {
        // �̵��� ���� �̸��� ���� ���� �̸��� ��ġ�ϴ��� ��
        if (sceneName == "UI_Main" || sceneName == "UI_Select" || sceneName == "UI_Loading" || sceneName == "EndingScene")
        {
            // Ư�� �������� canvasToDisable ������ �����ϴ� ĵ������ ��Ȱ��ȭ
            canvasToDisable.gameObject.SetActive(false);
        }
        else 
        {
            // �ٸ� �������� ĵ������ Ȱ��ȭ
            canvasToDisable.gameObject.SetActive(true);
        }
        // ĵ������ ��Ȱ��ȭ�� ��, �� �̵� ����
        SceneManager.LoadScene(sceneName);

        
        // ���� ������ ������ UI_Test Ŭ������ �ν��Ͻ� �ı�
        if (instance_ui != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
        {
        
        }
}
