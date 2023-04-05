using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EndTalkManager : MonoBehaviour
{
    AllUnits.Unit unit;
    Dictionary<int, string> talkData, talkData2;
    public GameObject TalkPannel, TalkPannel2;
    public Image Portrait, Portrait2;
    public Text talk, talk2;
    public Sprite God, Sword, Spear, Shield;
    Sprite CharSprite;
    public GameObject PL;
    public int CharCodecopy;
    public static int DataNum,DataNum2;

    public CanvasGroup Endingpannel;
    public float fadeCount;

    private void Start()
    {
        fadeCount = 0f;
    }
    void Awake()
    {
        talkData = new Dictionary<int, string>();
        talkData2 = new Dictionary<int, string>();
        DataNum = 1;
        DataNum2 = 1;
        GenerateData();

        

    }

    void Update()
    {

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

        if (DataNum == 3)
        {
            PannelOff();
        }
        if (DataNum2 == 4)
        {
            PannelOff2();

            BoolManager.Ending = true;
        }

        if (DataNum == 1 || DataNum == 2)
        {
            Portrait.sprite = CharSprite;
        }
        else
        {
            Portrait.sprite = God;

        }

        if (DataNum2 == 2 || DataNum2 == 4)
        {
            Portrait2.sprite = God;
        }
        else
        {
            Portrait2.sprite = CharSprite;
        }

        if (BoolManager.Ending == true)
        {
            StartCoroutine(Ending());
        }
    }

    void GenerateData()
    {
        talkData.Add(1, "앞에 신이 있다. 대화를 걸어보자");
        talkData.Add(2, "");

        talkData2.Add(1, "알겠어요, 크레아토르를 구해주셔서 감사합니다 용사여  당신의 소원은 뭐죠?");
        talkData2.Add(2, "내 소원은…!");
        talkData2.Add(3, "");
    }



    IEnumerator ActTalk()
    {
        talk.text = talkData[DataNum];
        Debug.Log(DataNum);

        DataNum++;
        yield return new WaitForSeconds(0.5f);
        
    }

    IEnumerator ActTalk2()
    {
        talk2.text = talkData2[DataNum2];
        Debug.Log(DataNum);

        DataNum2++;
        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator Ending()
    {
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.0001f;
            yield return new WaitForSeconds(0.1f);
            Endingpannel.alpha = fadeCount;

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

}
