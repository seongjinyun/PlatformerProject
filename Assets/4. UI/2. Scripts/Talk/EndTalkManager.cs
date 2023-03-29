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
        talkData.Add(1, "ũ�����丣? ���� �� �̷� ���� �°���?");
        talkData.Add(2, "����� ���� ���� �޾� �̸��� ���� �Ǿ����.");
        talkData.Add(3, "�� ���迡�� �����ʹ� �޸� ���͵��� ���縮���־��. �׷��� ������ ���ݺ��� ��ſ��� ���͵�� �ο� �� �ִ� ���� ��� ����ؾ��ϴ��� �˷��ַ��� �ؿ�.");
        talkData.Add(4, "�ƴ� ���.. ����? �װ� �������̿���!!");
        talkData.Add(5, "���.. �� ����� ���ɵ�� �ΰ����� ��ȭ�Ӱ� ��� �־����. ������ ���� �Ǿ��ִ� ������ �� �ȿ��� ������ �跫�� �ٸ�� �ᱹ, ������ ���������� ���Ҿ��.");
        talkData.Add(6, "�׷��� ������ ū ���̴� ���ɿ��� Ÿ���ϰ� �Ǹ鼭 �Ϲ� ���ɵ��� ������� �����ϴ� ���Ͱ� �Ǿ������ ������.");
        talkData.Add(7, "����� ������ ���ɵ��� ��ȭ���� ������� ��������, ������ ������ ��� ������ �����ؾ� �ؿ�.");
        talkData.Add(8, "���� ���� ���ο�? �׸��� ���� �� �ؾ��ؿ�! �� ���� �ٸ� ����鵵 ���ݾƿ�!");
        talkData.Add(9, "����� ���ù��� ���. �ٸ� ������� �� �� ���� ���̶� �׷���. ����, �����ֽŴٸ� ����� ������ ���������帮�� �ҿ��� ����ٰԿ�.");
        talkData.Add(10, "�ź��ϸ� ��� ����?");
        talkData.Add(11, "���� ��Ÿ������ ����� ������� �װ� �ǰ��ҡ�");
        talkData.Add(12, "...�˰ھ�� ��� ����� ����");
        talkData.Add(13, "");
        
        talkData2.Add(1, "��, ��������. ����.. �� �� �ϸ� ����?");
        talkData2.Add(2, "���� ���� ���̴� ��Ż�� ���� ũ�����丣�� ���� ������ �ϼ����� ����ġ�� Ÿ���� ���ɵ��� ������ ������� ���������ּ���.");
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
