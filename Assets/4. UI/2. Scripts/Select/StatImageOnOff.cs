using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class StatImageOnOff : MonoBehaviour
{
    public GameObject SwordStat, SpearStat, ShieldStat, SwordImg, SpearImg, ShieldImg ;
    public GameObject SwordStatENG, SpearStatENG, ShieldStatENG;
    SelectChar selectChar;
    PanelCtrl panelCtrl;
    // Update is called once per frame
    void Update()
    {
        
        if (DataMgr.instance.currentCharacter == Character.Sword)
        {
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                SwordImg.SetActive(true);
                SwordStat.SetActive(false);
                SwordStatENG.SetActive(true);
                SpearImg.SetActive(false);
                SpearStat.SetActive(false);
                SpearStatENG.SetActive(false);
                ShieldImg.SetActive(false);
                ShieldStat.SetActive(false);
                ShieldStatENG.SetActive(false);
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                SwordImg.SetActive(true);
                SwordStat.SetActive(true);
                SwordStatENG.SetActive(false);
                SpearImg.SetActive(false);
                SpearStat.SetActive(false);
                SpearStatENG.SetActive(false);
                ShieldImg.SetActive(false);
                ShieldStat.SetActive(false);
                ShieldStatENG.SetActive(false);
            }

        }
        else if(DataMgr.instance.currentCharacter == Character.Spear)
        {
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                SwordImg.SetActive(false);
                SwordStat.SetActive(false);
                SwordStatENG.SetActive(false);
                SpearImg.SetActive(true);
                SpearStat.SetActive(false);
                SpearStatENG.SetActive(true);
                ShieldImg.SetActive(false);
                ShieldStat.SetActive(false);
                ShieldStatENG.SetActive(false);
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                SwordImg.SetActive(false);
                SwordStat.SetActive(false);
                SwordStatENG.SetActive(false);
                SpearImg.SetActive(true);
                SpearStat.SetActive(true);
                SpearStatENG.SetActive(false);
                ShieldImg.SetActive(false);
                ShieldStat.SetActive(false);
                ShieldStatENG.SetActive(false);
            }

        }
        else if(DataMgr.instance.currentCharacter == Character.Shield)
        {
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                SwordImg.SetActive(false);
                SwordStat.SetActive(false);
                SwordStatENG.SetActive(false);
                SpearImg.SetActive(false);
                SpearStat.SetActive(false);
                SpearStatENG.SetActive(false);
                ShieldImg.SetActive(true);
                ShieldStat.SetActive(false);
                ShieldStatENG.SetActive(true);
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                SwordImg.SetActive(false);
                SwordStat.SetActive(false);
                SwordStatENG.SetActive(false);
                SpearImg.SetActive(false);
                SpearStat.SetActive(false);
                SpearStatENG.SetActive(false);
                ShieldImg.SetActive(true);
                ShieldStat.SetActive(true);
                ShieldStatENG.SetActive(false);
            }
        }
    }
}
