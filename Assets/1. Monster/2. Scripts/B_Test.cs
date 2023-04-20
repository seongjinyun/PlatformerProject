using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Test : MonoBehaviour
{
    SpriteRenderer Sprite;

    public float speed = 2.0f;

    private Vector2 targetPosition;
    private bool isMoving = false; 

    public bool Boss_seal = false;

    Player_Move Pm;

    // Start is called before the first frame update
    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Pm = FindObjectOfType<Player_Move>();
    }
    void Start()
    {
        StartCoroutine("Move_Boss");
        Pm.enabled = false;
    }

    IEnumerator Move_Boss()
    {
        yield return new WaitForSeconds(1f);
        MoveUp();

        yield return new WaitForSeconds(5f);
        Sprite.enabled = true;
        Pm.enabled = true;
        Boss_seal = true;
    }
    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == (Vector3)targetPosition)
            {
                isMoving = false;
  
            }
        }
    }

    public void MoveUp()
    {
        targetPosition = (Vector2)transform.position + Vector2.up * 4f;
        isMoving = true;
    }
}
