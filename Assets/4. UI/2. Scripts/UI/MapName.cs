using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class MapName : MonoBehaviour
{
    public TMP_Text scenename;
    // Update is called once per frame
   

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;

        if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("en"))
        {
            if (scene.name == "Tutorial")
            {
                scenename.text = "TUTORIAL";
            }
            else if (scene.name == "1_Stage")
            {
                scenename.text = "1STAGE";
            }
            else if (scene.name == "1_StageBoss")
            {
                scenename.text = "1STAGE BOSS";
            }
            else if (scene.name == "2_Stage")
            {
                scenename.text = "2STAGE";
            }
            else if (scene.name == "2_StageBoss")
            {
                scenename.text = "2STAGE BOSS";
            }
            else if (scene.name == "3_Stage")
            {
                scenename.text = "3STAGE";
            }
            else if (scene.name == "3_StageBoss")
            {
                scenename.text = "3STAGE BOSS";
            }
            else if (scene.name == "4_Stage")
            {
                scenename.text = "4STAGE";
            }
            else if (scene.name == "4_StageBoss")
            {
                scenename.text = "4STAGE BOSS";
            }
            else if (scene.name == "Maze_Stage")
            {
                scenename.text = "MAZE";
            }
            
        }
        else if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("ko-KR"))
        {
            if (scene.name == "Tutorial")
            {
                scenename.text = "튜토리얼";
            }
            else if (scene.name == "1_Stage")
            {
                scenename.text = "1스테이지";
            }
            else if (scene.name == "1_StageBoss")
            {
                scenename.text = "1스테이지 보스";
            }
            else if (scene.name == "2_Stage")
            {
                scenename.text = "2스테이지";
            }
            else if (scene.name == "2_StageBoss")
            {
                scenename.text = "2스테이지 보스";
            }
            else if (scene.name == "3_Stage")
            {
                scenename.text = "3스테이지";
            }
            else if (scene.name == "3_StageBoss")
            {
                scenename.text = "3스테이지 보스";
            }
            else if (scene.name == "4_Stage")
            {
                scenename.text = "4스테이지";
            }
            else if (scene.name == "4_StageBoss")
            {
                scenename.text = "4스테이지 보스";
            }
            else if (scene.name == "Maze_Stage")
            {
                scenename.text = "미로";
            }
        }
    }
}
