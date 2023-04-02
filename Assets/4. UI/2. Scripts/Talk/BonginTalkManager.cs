using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BonginTalkManager : MonoBehaviour
{
    AllUnits.Unit unit;
    Dictionary<int, string> talkData;
    public GameObject TalkPannel;
    public Image Portrait;
    public Text talk;
    public Sprite Sword, Spear, Shield;
    Sprite CharSprite;
    public GameObject PL;
    public int CharCodecopy;
    public static int DataNum;

    private void Start()
    {
        
    }
    void Awake()
    {
        talkData = new Dictionary<int, string>();
        DataNum = 1;
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

        if (DataNum == 3)
        {
            PannelOff();
        }
        Portrait.sprite = CharSprite;
    }

    void GenerateData()
    {
        talkData.Add(1, "B를 눌러 봉인을 하자!");
        talkData.Add(2, "");
    }



    IEnumerator ActTalk()
    {
        talk.text = talkData[DataNum];
        Debug.Log(DataNum);

        DataNum++;
        yield return new WaitForSeconds(0.5f);
        
    }

    void PannelOff()
    {
        Time.timeScale = 1f;
        TalkPannel.SetActive(false);
        DataNum++;
    }
}
