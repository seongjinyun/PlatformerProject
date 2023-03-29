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


    private void Start()
    {
        
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

        if (Input.GetMouseButtonDown(0) && TalkPannel.activeSelf == true)
        {
            StartCoroutine(ActTalk());
        }
        if (Input.GetMouseButtonDown(0) && TalkPannel2.activeSelf == true)
        {
            StartCoroutine(ActTalk2());
        }

        if (DataNum == 14)
        {
            PannelOff();
        }
        if (DataNum2 == 4)
        {
            PannelOff2();
        }

        if (DataNum == 2 || DataNum == 5 || DataNum == 9 || DataNum == 11 || DataNum == 13 || DataNum2 == 2)
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
    }

    void GenerateData()
    {
        talkData.Add(1, "크레아토르? 내가 왜 이런 곳에 온거지?");
        talkData.Add(2, "당신은 용사로 선택 받아 이리로 오게 되었어요.");
        talkData.Add(3, "이 세계에는 지구와는 달리 몬스터들이 도사리고있어요. 그렇기 때문에 지금부터 당신에게 몬스터들과 싸울 수 있는 힘을 어떻게 사용해야하는지 알려주려고 해요.");
        talkData.Add(4, "아니 잠깐.. 몬스터? 그게 무슨말이에요!!");
        talkData.Add(5, "사실.. 이 세계는 정령들과 인간들이 조화롭게 살고 있었어요. 하지만 봉인 되어있던 마왕이 그 안에서 모종의 계략을 꾸몄고 결국, 봉인이 깨져버리고 말았어요.");
        talkData.Add(6, "그렇게 봉인의 큰 축이던 정령왕은 타락하게 되면서 일반 정령들은 사람들을 공격하는 몬스터가 되어버리고 말았죠.");
        talkData.Add(7, "당신의 역할은 정령들을 정화시켜 본래대로 돌려놓고, 정령의 파편을 모아 마왕을 봉인해야 해요.");
        talkData.Add(8, "제가 무슨 수로요? 그리고 제가 왜 해야해요! 저 말고 다른 사람들도 많잖아요!");
        talkData.Add(9, "당신은 선택받은 용사. 다른 사람들은 할 수 없는 일이라 그래요. 만약, 도와주신다면 당신을 지구로 돌려보내드리고 소원을 들어줄게요.");
        talkData.Add(10, "거부하면 어떻게 되죠?");
        talkData.Add(11, "정말 안타깝지만 당신은 순리대로 죽게 되겠죠…");
        talkData.Add(12, "...알겠어요 당신 말대로 하죠");
        talkData.Add(13, "");
        
        talkData2.Add(1, "뭐, 조금은요. 이제.. 뭘 더 하면 되죠?");
        talkData2.Add(2, "이제 옆에 보이는 포탈을 통해 크레아토르로 가서 마왕의 하수인을 물리치고 타락한 정령들을 원래의 모습으로 돌려놓아주세요.");
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
