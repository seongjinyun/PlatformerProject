using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject information;
    CanvasGroup canvasGroup;
    public bool iscoll;
    public float count;
    void Start()
    {
        iscoll = false;

        canvasGroup = information.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.alpha = count;

        if(count < 0)
        {
            count = 0;
        }
        else if(count > 1)
        {
            count = 1;
        }
        
        if(iscoll == true)
        {
            count += 0.01f; 
        }
        else
        {
            count -= 0.01f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            iscoll = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            iscoll = false;
        }
    }
}
