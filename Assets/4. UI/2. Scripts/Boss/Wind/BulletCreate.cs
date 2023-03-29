using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{

    public float rot_Speed;
    public Transform pos;
    public GameObject bullet;
    static public bool BulletGo;
    public Transform Target;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {   
        if(BulletGo == true)
        {
            StartCoroutine(BulletCreating());
        }
        
    }

    IEnumerator BulletCreating()
    {
        
        //총알 생성
        GameObject temp = Instantiate(bullet);
        //2초후 자동 삭제
        Destroy(temp, 3f);
        temp.transform.position = transform.position;
        temp.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(5f);
        Instantiate(temp, transform.position, transform.rotation);
        Instantiate(temp, transform.position, Quaternion.Euler(0, 0, 35));
        Instantiate(temp, transform.position, Quaternion.Euler(0, 0, -35));
    }
    public void LookPlayer()
    {
        if (transform.position.x < Target.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

}