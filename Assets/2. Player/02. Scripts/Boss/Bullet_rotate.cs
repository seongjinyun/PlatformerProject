using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_rotate : MonoBehaviour
{
    float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ȸ�� ����� �ӵ� ����
        this.gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
