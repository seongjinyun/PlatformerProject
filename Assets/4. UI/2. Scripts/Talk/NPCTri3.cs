using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTri3 : MonoBehaviour
{
    public GameObject TalkPannel;
    B_Test bt;

    private void Start()
    {
        bt = GetComponent<B_Test>();
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bt.Boss_seal == true)
        {
            if (collision.tag == "Player")
            {
                if (EndTalkManager.DataNum < 3)
                {
                    TalkPannel.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }

    }
}
