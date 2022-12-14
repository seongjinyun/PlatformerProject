using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f); // 발에 떳다가 사라지게 하는 스크립트
    }
}
