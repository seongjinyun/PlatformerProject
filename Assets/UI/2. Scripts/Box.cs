using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject[] items = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {  

    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {  
            int rand = Random.Range(0, 5);
            Instantiate(items[rand], transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
