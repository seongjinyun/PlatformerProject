using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Platform : MonoBehaviour
{
    PlatformEffector2D effecter;
    

    // Start is called before the first frame update
    void Start()
    {
        effecter = GetComponent<PlatformEffector2D>();
    }
    
    public void ChangeLayer()
    {
        effecter.rotationalOffset = 180;
        //gameObject.layer = 15; //15�� ���̾�� �ٲ�� (Pass)���̾�
        StartCoroutine("ReturnLayer"); //�ڷ�ƾ ���� 
    }
    IEnumerator ReturnLayer()
    {
        yield return new WaitForSeconds(0.5f); //0.5�ʵڿ� 
        //gameObject.layer = 9; //9�� ���̾�� ���ƿ� (Ground)
        effecter.rotationalOffset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
