using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    public float speed;
    public float dir = 1f;
    public float distance;
    public LayerMask isLayer; // 레이어 지정
    public GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position, distance, isLayer);
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
            transform.Translate(transform.right * dir * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * dir * -1 * speed * Time.deltaTime);
        }

        void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}
