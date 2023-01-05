using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string NextSceneName;

    private HeroKnight player;
    void Start()
    {
        player = FindObjectOfType<HeroKnight>(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.currentmapname = NextSceneName;
            SceneManager.LoadScene(NextSceneName);
            Destroy(this.gameObject);
        }
    }
}
