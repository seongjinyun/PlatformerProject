using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    public float Monster_speed;
    public float Monster_bullet_distance;
    public LayerMask Monster_isLayer; // 레이어 지정
    public GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position, Monster_bullet_distance, Monster_isLayer);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("발사");
            }
            DestroyBullet();
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * Monster_speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * Monster_speed * Time.deltaTime);
        }

        void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}
