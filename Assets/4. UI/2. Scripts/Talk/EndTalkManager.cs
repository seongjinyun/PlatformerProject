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
    }

    void GenerateData()
    {
        talkData.Add(1, "�տ� ���� �ִ�. ��ȭ�� �ɾ��");
        talkData.Add(2, "");

        talkData2.Add(1, "�˰ھ��, ũ�����丣�� �����ּż� �����մϴ� ��翩  ����� �ҿ��� ����?");
        talkData2.Add(2, "�� �ҿ�����!");
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
