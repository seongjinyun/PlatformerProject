using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MapName : MonoBehaviour
{
    public TMP_Text scenename;
    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Tutorial") 
        {
            scenename.text = "튜토리얼 맵";
        }
        else if (scene.name == "1_Stage")
        {
            scenename.text = "1스테이지 : 메마른 땅";
        }
        else if (scene.name == "1_StageBoss")
        {
            scenename.text = "1스테이지 : 메마른 땅";
        }
        else if (scene.name == "2_Stage")
        {
            scenename.text = "2스테이지 : 얼음 동굴";
        }
        else if (scene.name == "2_StageBoss")
        {
            scenename.text = "2스테이지 : 얼음 동굴";
        }
        else if (scene.name == "3_Stage")
        {
            scenename.text = "3스테이지 : 지하 건물";
        }
        else if (scene.name == "3_StageBoss")
        {
            scenename.text = "3스테이지 : 지하 건물";
        }
        else if (scene.name == "4_Stage")
        {
            scenename.text = "4스테이지 : 마왕성 입구";
        }
        else if (scene.name == "4_StageBoss")
        {
            scenename.text = "4스테이지 : 마왕성 입구";
        }
        else if (scene.name == "Maze_Stage")
        {
            scenename.text = "봉인 스테이지 : 미로";
        }
    }
}
