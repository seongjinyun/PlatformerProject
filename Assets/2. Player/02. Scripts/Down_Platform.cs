using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeLayer()
    {
        gameObject.layer = 15; //15�� ���̾�� �ٲ�� (Pass)���̾�
        StartCoroutine("ReturnLayer"); //�ڷ�ƾ ���� 
    }
    IEnumerator ReturnLayer()
    {
        yield return new WaitForSeconds(1f); //0.5�ʵڿ� 
        gameObject.layer = 9; //9�� ���̾�� ���ƿ� (Ground)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
