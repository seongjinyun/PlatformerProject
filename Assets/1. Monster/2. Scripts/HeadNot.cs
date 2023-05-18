using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadNot : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeadNot"))
        {
            /*sprite.flipX = false; // аб
            sprite.flipX = true; // ©Л*/
            delay += Time.deltaTime;

            if (delay > 0.3f)
            {
                //rb.velocity = new Vector2(10f, rb.velocity.y);
                transform.Translate(Vector2.right * 3f * Time.deltaTime);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeadNot"))
        {
            delay = 0f;

        }
    }
}
