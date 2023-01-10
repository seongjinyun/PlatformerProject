using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spear : Player_Move
{
    // Start is called before the first frame update
    void Start()
    {
        Player_rigid = GetComponent<Rigidbody2D>();
        Player_tr = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
