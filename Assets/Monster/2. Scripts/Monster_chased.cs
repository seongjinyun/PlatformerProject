using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_chased : MonoBehaviour
{
    public float Monster_speed = 1;
    public GameObject target;
    public float Monster_Dist = 5f;


    // public GameObject Ene;
    // public int hp = 5;
    // public GameObject Bullet;

    /*private void OnTriggerEnter2D(Collider2D collision) // HP
    {
        if (collision.gameObject.CompareTag("BULLET"))
        {
            Destroy(collision.gameObject);
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(Ene);
            }
        }
    }*/
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Monster_Rotate();
        //Ray();
        //GameObject target = GameObject.Find("Player_test");
        //transform.position = Vector3.Lerp(transform.position, target.transform.position, Monster_speed * Time.deltaTime);
    }

    void Monster_Rotate()
    {
        // 플레이어의 x좌표보다 작으면 오른쪽으로 회전
        if (target.transform.position.x > transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if (target.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    /*void Ray()
    {
        RaycastHit2D rayHit;
        Debug.DrawRay(this.transform.position + Vector3.up, Vector2.left * 10, Color.red);

        if (rayHit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.left * 10, LayerMask.GetMask("Water")))
        {
            //Destroy(rayHit.collider);
            if (rayHit.collider.tag == "Player")
            {
                Debug.Log("player");
            }
        }

    }*/
}
