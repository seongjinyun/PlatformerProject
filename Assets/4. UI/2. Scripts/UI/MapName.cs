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
            scenename.text = "Ʃ�丮�� ��";
        }
        else if (scene.name == "1_Stage")
        {
            scenename.text = "1�������� : �޸��� ��";
        }
        else if (scene.name == "1_StageBoss")
        {
            scenename.text = "1�������� : �޸��� ��";
        }
        else if (scene.name == "2_Stage")
        {
            scenename.text = "2�������� : ���� ����";
        }
        else if (scene.name == "2_StageBoss")
        {
            scenename.text = "2�������� : ���� ����";
        }
        else if (scene.name == "3_Stage")
        {
            scenename.text = "3�������� : ���� �ǹ�";
        }
        else if (scene.name == "3_StageBoss")
        {
            scenename.text = "3�������� : ���� �ǹ�";
        }
        else if (scene.name == "4_Stage")
        {
            scenename.text = "4�������� : ���ռ� �Ա�";
        }
        else if (scene.name == "4_StageBoss")
        {
            scenename.text = "4�������� : ���ռ� �Ա�";
        }
        else if (scene.name == "Maze_Stage")
        {
            scenename.text = "���� �������� : �̷�";
        }
    }
}
