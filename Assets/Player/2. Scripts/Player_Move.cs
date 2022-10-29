using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
   // public SpriteRenderer sr;
    public float speed = 3f;
    public float jumpPower;
    Rigidbody2D Player_rigid;
    Transform Player_tr;
    
    public int prHp = 100;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();
        
        sprite = GetComponent<SpriteRenderer>();
    }
    void Jump() 
    {
        if (Input.GetButtonDown("Jump"))
        {
            Player_rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    

    void move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
           // sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
           // sr.flipX = false;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += speed * Time.deltaTime * new Vector3(h, v, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ENEMY"))
        {
            prHp -= 10;
            if (prHp <= 0)
            {
                Debug.Log("ÇÇ°Ý");
                //player die
            }
        }
    }*/
}
