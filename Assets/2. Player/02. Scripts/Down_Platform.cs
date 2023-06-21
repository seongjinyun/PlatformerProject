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
        //gameObject.layer = 15; //15번 레이어로 바뀌고 (Pass)레이어
        StartCoroutine("ReturnLayer"); //코루틴 시작 
    }
    IEnumerator ReturnLayer()
    {
        yield return new WaitForSeconds(0.5f); //0.5초뒤에 
        //gameObject.layer = 9; //9번 레이어로 돌아옴 (Ground)
        effecter.rotationalOffset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
