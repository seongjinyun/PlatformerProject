using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public float camera_speed = 5.0f;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - this.transform.position; //타겟과 카메라 위치 계산값
        Vector3 moveVector = new Vector3(dir.x * camera_speed * Time.deltaTime, dir.y * camera_speed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
