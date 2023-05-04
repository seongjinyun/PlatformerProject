using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonginTri : MonoBehaviour
{
    public GameObject TalkPannel;

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (BonginTalkManager.DataNum < 3)
            {
                TalkPannel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
