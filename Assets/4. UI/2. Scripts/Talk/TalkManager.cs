using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class TalkManager : MonoBehaviour
{
    AllUnits.Unit unit;
    Dictionary<int, string> talkData, talkData2, talkData3;
    Dictionary<int, string> talkDataENG, talkDataENG2, talkDataENG3;
    public GameObject TalkPannel, TalkPannel2, TalkPannel3;
    public Image Portrait, Portrait2, Portrait3;
    public Text talk, talk2, talk3;
    public Sprite God, Sword, Spear, Shield;
    Sprite CharSprite;
    public GameObject PL;
    public int CharCodecopy;
    public static int DataNum,DataNum2, DataNum3;


    private void Start()
    {
        TalkPannel3.SetActive(true);
        Time.timeScale = 0f;

        BoolManager.Ending = false;
    }
    void Awake()
    {
        talkData = new Dictionary<int, string>();
        talkData2 = new Dictionary<int, string>();
        talkData3 = new Dictionary<int, string>();

        talkDataENG = new Dictionary<int, string>();
        talkDataENG2 = new Dictionary<int, string>();
        talkDataENG3 = new Dictionary<int, string>();

        DataNum = 1;
        DataNum2 = 1;
        DataNum3 = 1;

        GenerateData();
        GenerateDataENG();
    }

    void Update()
    {
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;

        PL = GameObject.FindWithTag("Player");

        unit = PL.GetComponent<AllUnits.Unit>();

        if (unit.CharCode == 0)
        {
            CharSprite = Sword;
        }
        if (unit.CharCode == 1)
        {
            CharSprite = Spear;
        }
        if (unit.CharCode == 2)
        {
            CharSprite = Shield;
        }

        if (Input.GetKeyDown(KeyCode.Space) && TalkPannel.activeSelf == true)
        {
            StartCoroutine(ActTalk());
        }
        if (Input.GetKeyDown(KeyCode.Space) && TalkPannel2.activeSelf == true)
        {
            StartCoroutine(ActTalk2());
        }
        if (Input.GetKeyDown(KeyCode.Space) && TalkPannel3.activeSelf == true)
        {
            StartCoroutine(ActTalk3());
        }

        if (DataNum == 15)
        {
            PannelOff();
        }
        if (DataNum2 == 4)
        {
            PannelOff2();
        }
        if (DataNum3 == 3)
        {
            PannelOff3();
        }

        if (DataNum == 2 || DataNum == 4 || DataNum == 6 || DataNum == 9 || DataNum == 12 || DataNum == 14)
        {
            Portrait.sprite = CharSprite;
        }
        else
        {
            Portrait.sprite = God;

        }

        if (DataNum2 == 2)
        {
            Portrait2.sprite = CharSprite;
        }
        else
        {
            Portrait2.sprite = God;
        }
        if (DataNum3 == 1 || DataNum3 == 2)
        {
            Portrait3.sprite = CharSprite;
        }

        if (Time.timeScale == 0)
        {
            PL.GetComponent<Player_Move>().enabled = false; // 플레이어 스크립트 비활성화
        }
        else if (Time.timeScale == 1)
        {
            PL.GetComponent<Player_Move>().enabled = true;
        }
    }

    void GenerateData()
    {
        talkData.Add(1, "크레아토르? 제가 왜 이런 곳에 오게 된거죠?");
        talkData.Add(2, "당신은 과로로 인해 죽게 됐고, 크레아토르로 환생하게 됐어요.");
        talkData.Add(3, "그럴리가... 전 분명 야근을...");
        talkData.Add(4, "크레아토르에는 지구와는 달리 마왕이 존재하는데 당신은 마왕의 하수인을 무찌르고 마왕을 재봉인하기 위해 선택된 용사예요.");
        talkData.Add(5, "아니 잠깐…. 마왕? 그게 무슨 말이에요?");
        talkData.Add(6, "봉인되어있던 마왕이 계략을 꾸몄고 봉인의 축인 정령왕이 타락하게 되면서 봉인이 해제되고 있어요.");
        talkData.Add(7, "당신의 역할은 마왕의 하수인을 무찌르고 타락한 정령왕을 정화해 본래대로 되돌려놓고, 정령의 파편을 모아 봉인을 고쳐야 해요.");
        talkData.Add(8, "꼭 제가 해야 하는 거예요? 제가 무슨 수로 마왕의 하수인을 무찔러요?");
        talkData.Add(9, "선택받은 용사만이 할 수 있는 일이라 그래요.");
        talkData.Add(10, "만약, 도와주신다면 당신을 지구로 돌려보내 드리고 소원을 들어줄게요.");
        talkData.Add(11, "거부하면 어떻게 되죠?");
        talkData.Add(12, "정말 안타깝지만, 당신은 순리대로 죽게 되겠죠...");
        talkData.Add(13, "...알겠어요. 당신 말대로 할게요");
        talkData.Add(14, "");
        
        talkData2.Add(1, "뭐, 조금은요. 이제.. 뭘 더 하면 되죠?");                                                                                                                                                                 
        talkData2.Add(2, "이제 옆에 보이는 포탈을 통해 크레아토르로 가서 마왕의 하수인을 물리치고 타락한 정령들을 원래의 모습으로 돌려놓아주세요.");
        talkData2.Add(3, "");

        talkData3.Add(1, "앞에 저 여자는 누구지..? 여기가 어딘지 물어봐야겠어");
        talkData3.Add(2, "");
    }
    void GenerateDataENG()
    {
        talkDataENG.Add(1, "kreaitor? What brought me here?");
        talkDataENG.Add(2, "You died from fatigue and have been reincarnated here in kreaitor.");
        talkDataENG.Add(3, "That's impossible... I was just working overtime...");
        talkDataENG.Add(4, "Unlike Earth, there is a demon living in Creator and you have been chosen to defeat the demon's underlings and imprison him.");
        talkDataENG.Add(5, "Wait what? A demon? What are you talking about?");
        talkDataENG.Add(6, "The imprisoned demon tricked the elemental lord, corrupted him, and escaped his imprisonment.");
        talkDataENG.Add(7, "You need to defeat the demon's underlings and cleanse the corrupted elemental lord, gather the broken elemental shards and fix the seal of imprisonment.");
        talkDataENG.Add(8, "Why me? How do you expect me to defeat the demon's underlings?");
        talkDataENG.Add(9, "Only the chosen one can do this.");
        talkDataENG.Add(10, "If you are successful, I shall return you to Earth and grant you one wish.");
        talkDataENG.Add(11, "What happens if I refuse?");
        talkDataENG.Add(12, "Then, you will die as intended.");
        talkDataENG.Add(13, "...Alright. I'll do as you say.");
        talkDataENG.Add(14, "");

        talkDataENG2.Add(1, "I guess. What do I do now?");
        talkDataENG2.Add(2, "This portal will take you to kreaitor. Defeat the demon's underlings and cleanse the corrupted elemental lord.");
        talkDataENG2.Add(3, "");

        talkDataENG3.Add(1, "Who is that woman in front of you? I need to ask where I am");
        talkDataENG3.Add(2, "");
    }


    IEnumerator ActTalk()
    {   
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            talk.text = talkDataENG[DataNum];

            DataNum++;
            yield return new WaitForSeconds(0.5f);
        }
        else if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            talk.text = talkData[DataNum];

            DataNum++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ActTalk2()
    {
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            talk2.text = talkDataENG2[DataNum2];

            DataNum2++;
            yield return new WaitForSeconds(0.5f);
        }
        else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            talk2.text = talkData2[DataNum2];

            DataNum2++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ActTalk3()
    {
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            talk3.text = talkDataENG3[DataNum3];

            DataNum3++;
            yield return new WaitForSeconds(0.5f);
        }
        else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            talk3.text = talkData3[DataNum3];

            DataNum3++;
            yield return new WaitForSeconds(0.5f);
        }
        

    }

    void PannelOff()
    {
        Time.timeScale = 1f;
        TalkPannel.SetActive(false);
        DataNum++;
    }

    void PannelOff2()
    {
        Time.timeScale = 1f;
        TalkPannel2.SetActive(false);
        DataNum2++;

    }
    void PannelOff3()
    {
        Time.timeScale = 1f;
        TalkPannel3.SetActive(false);
        DataNum3++;

    }

}
