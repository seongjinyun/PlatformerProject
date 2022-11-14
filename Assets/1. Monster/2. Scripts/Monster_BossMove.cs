using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_BossMove : MonoBehaviour
{
    public float speed;
    public GameObject Target;

    public float Timer = 0f;

    public GameObject Monster_bullet;
    public Transform Bullet_pos;

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 10f)
        {
             Instantiate(Monster_bullet, Bullet_pos.position, transform.rotation);
             Timer = 0f;
        }

        Rotate();
    }

    void LateUpdate() // ���̶�Ű�� �÷��̾� �̸� ã�Ƽ� ����
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, speed * Time.deltaTime);
    }

    void Rotate()
    {
        if (transform.position.x > Target.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
