using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class EnemyCountText : MonoBehaviour
{
    public TMP_Text enemycounttext;

    public int curkillcount;
    private void Start()
    {
        
    }
    void Update()
    {
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;

        curkillcount = EnemyCountManager.instance.KillMonsterCount;
        if (SceneManager.GetActiveScene().name == "1_Stage")
        {
            if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("en"))
            {
                enemycounttext.text = "REMAINING ENEMIES  " + curkillcount + " /" + EnemyCountManager.instance.onestage;
            }
            else if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("ko-KR"))
            {
                enemycounttext.text = "남은 적 : " + curkillcount + " /" + EnemyCountManager.instance.onestage;
            }
        }
        if (SceneManager.GetActiveScene().name == "2_Stage")
        {
            if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("en"))
            {
                enemycounttext.text = "REMAINING ENEMIES  " + curkillcount + " /" + EnemyCountManager.instance.twostage;
            }
            else if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("ko-KR"))
            {
                enemycounttext.text = "남은 적 : " + curkillcount + " /" + EnemyCountManager.instance.twostage;
            }
        }
        if (SceneManager.GetActiveScene().name == "3_Stage")
        {
            if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("en"))
            {
                enemycounttext.text = "REMAINING ENEMIES  " + curkillcount + " /" + EnemyCountManager.instance.threestage;
            }
            else if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("ko-KR"))
            {
                enemycounttext.text = "남은 적 : " + curkillcount + " /" + EnemyCountManager.instance.threestage;
            }
        }
        if (SceneManager.GetActiveScene().name == "4_Stage")
        {
            if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("en"))
            {
                enemycounttext.text = "REMAINING ENEMIES  " + curkillcount + " /" + EnemyCountManager.instance.fourstage;
            }
            else if (LocalizationSettings.SelectedLocale == availableLocales.GetLocale("ko-KR"))
            {
                enemycounttext.text = "남은 적 : " + curkillcount + " /" + EnemyCountManager.instance.fourstage;
            }
        }

    }
}
