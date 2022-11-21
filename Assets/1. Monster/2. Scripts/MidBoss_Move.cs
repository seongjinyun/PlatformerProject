using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss_Move : MonoBehaviour
{
    public enum State { idle, Run, Attack, Jump, Die };

    public State Boss_state = State.idle;

    public float speed;
    public GameObject[] Target;

    public float Timer = 0f;

    public GameObject Monster_bullet;
    public Transform Bullet_pos;

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

    void LateUpdate() // 하이라키뷰 플레이어 이름 찾아서 추적
    {

        transform.position = Vector3.Lerp(transform.position, Target[0].transform.position, speed * Time.deltaTime);

        //RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.right, 3f);
        //Debug.DrawLine(transform.position, Hit.point, Color.yellow);

    }

    void Rotate()
    {
        if (transform.position.x > Target[0].transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
