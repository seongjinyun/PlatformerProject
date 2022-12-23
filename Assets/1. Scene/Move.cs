using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // public SpriteRenderer sr;
    public float speed = 3f;

    public int prHp = 100;

    
    // Start is called before the first frame update
    void Start()
    {
        //  sr = this.gameObject.GetComponent<SpriteRenderer>();

        //  sr.flipX = false;
    }

    void move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //  sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //  sr.flipX = false;
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
    }
}