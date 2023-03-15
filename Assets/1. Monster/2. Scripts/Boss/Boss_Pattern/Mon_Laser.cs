using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon_Laser : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.velocity = transform.position * bulletSpeed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x)
            * Mathf.Rad2Deg ;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

}
