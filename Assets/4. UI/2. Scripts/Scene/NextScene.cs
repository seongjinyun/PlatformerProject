using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string NextMapName;
    public CurMapName Player;
    void Start()
    {

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
            Player.CurMapname = NextMapName;
            LoadingSceneController.LoadScene(NextMapName);
        }
    }
}
