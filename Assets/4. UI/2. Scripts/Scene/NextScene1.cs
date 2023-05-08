using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene1 : MonoBehaviour
{
    public string NextMapName;
    public string HardMapName;
    public CurMapName Player;

    Mode_Select mode;
    void Start()
    {
        mode = FindObjectOfType<Mode_Select>();
    }

    // Update is called once per frame
    void Update()
    {
        Player = FindObjectOfType<CurMapName>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            if(mode.Hard == true)
            {
                Player.CurMapname = HardMapName;
                LoadingSceneController.LoadScene(HardMapName);
            }
            else 
            {
                Player.CurMapname = NextMapName;
                LoadingSceneController.LoadScene(NextMapName);
            }
        }
    }
}