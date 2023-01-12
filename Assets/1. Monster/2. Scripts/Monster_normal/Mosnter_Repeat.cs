using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosnter_Repeat : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public float Speed = 1f;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 5);
    }
    void Update()
    {
        anim.SetBool("Run", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove * Speed, rigid.velocity.y); // move

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 5);

        }
        if (nextMove > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);

        Think();
    }
}
