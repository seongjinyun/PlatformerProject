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
        gameObject.layer = 15; //15번 레이어로 바뀌고 (Pass)레이어
        StartCoroutine("ReturnLayer"); //코루틴 시작 
    }
    IEnumerator ReturnLayer()
    {
        yield return new WaitForSeconds(1f); //0.5초뒤에 
        gameObject.layer = 9; //9번 레이어로 돌아옴 (Ground)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
