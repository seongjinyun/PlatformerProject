using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TalkManager : MonoBehaviour
{
    AllUnits.Unit unit;
    Dictionary<int, string> talkData, talkData2, talkData3;
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

        DataNum = 1;
        DataNum2 = 1;
        DataNum3 = 1;

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
    }

    void GenerateData()
    {
        talkData.Add(1, "ũ�����丣? ���� �� �̷� ���� ���� �Ȱ���?");
        talkData.Add(2, "����� ���η� ���� �װ� �ư�, ũ�����丣�� ȯ���ϰ� �ƾ��.");
        talkData.Add(3, "�׷�����... �� �и� �߱���...");
        talkData.Add(4, "ũ�����丣���� �����ʹ� �޸� ������ �����ϴµ� ����� ������ �ϼ����� ����� ������ ������ϱ� ���� ���õ� ��翹��.");
        talkData.Add(5, "�ƴ� ���. ����? �װ� ���� ���̿���?");
        talkData.Add(6, "���εǾ��ִ� ������ �跫�� �ٸ�� ������ ���� ���ɿ��� Ÿ���ϰ� �Ǹ鼭 ������ �����ǰ� �־��.");
        talkData.Add(7, "����� ������ ������ �ϼ����� ����� Ÿ���� ���ɿ��� ��ȭ�� ������� �ǵ�������, ������ ������ ��� ������ ���ľ� �ؿ�.");
        talkData.Add(8, "�� ���� �ؾ� �ϴ� �ſ���? ���� ���� ���� ������ �ϼ����� ���񷯿�?");
        talkData.Add(9, "���ù��� ��縸�� �� �� �ִ� ���̶� �׷���.");
        talkData.Add(10, "����, �����ֽŴٸ� ����� ������ �������� �帮�� �ҿ��� ����ٰԿ�.");
        talkData.Add(11, "�ź��ϸ� ��� ����?");
        talkData.Add(12, "���� ��Ÿ������, ����� ������� �װ� �ǰ���...");
        talkData.Add(13, "...�˰ھ��. ��� ����� �ҰԿ�");
        talkData.Add(14, "");
        
        talkData2.Add(1, "��, ��������. ����.. �� �� �ϸ� ����?");                                                                                                                                                                 
        talkData2.Add(2, "���� ���� ���̴� ��Ż�� ���� ũ�����丣�� ���� ������ �ϼ����� ����ġ�� Ÿ���� ���ɵ��� ������ ������� ���������ּ���.");
        talkData2.Add(3, "");

        talkData3.Add(1, "�տ� �� ���ڴ� ������..? ���Ⱑ ����� ������߰ھ�");
        talkData3.Add(2, "");
    }



    IEnumerator ActTalk()
    {
        talk.text = talkData[DataNum];

        DataNum++;
        yield return new WaitForSeconds(0.5f);
        
    }

    IEnumerator ActTalk2()
    {
        talk2.text = talkData2[DataNum2];

        DataNum2++;
        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator ActTalk3()
    {
        talk3.text = talkData3[DataNum3];

        DataNum3++;
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
    void PannelOff3()
    {
        Time.timeScale = 1f;
        TalkPannel3.SetActive(false);
        DataNum3++;

    }

}
