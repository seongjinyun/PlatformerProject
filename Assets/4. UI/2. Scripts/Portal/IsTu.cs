using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTu : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        BoolManager.IsTutorial = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BoolManager.IsTutorial = true;
        }
    }
}
