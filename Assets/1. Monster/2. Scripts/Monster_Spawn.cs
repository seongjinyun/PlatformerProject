using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spawn : MonoBehaviour
{
    // ������ �������� ��ġ �� ������ ���� �������. (�Ǽ��� ������ ��ġ �����ϸ� �� ����Ǽ�)
    GameObject[] Spawn_Position1;
    GameObject[] Spawn_Position2;
    GameObject[] Spawn_Position3;
    public GameObject[] Monster_prefabs; // ���� ������ 0 = �ٰŸ�, 1 = ���Ÿ�, 2 = ��Ʈ��

    // ���̵� �� ���� ü�� 0 = ����, 1 = �ϵ�
    public int[] Normal_Hp;
    public int[] far_Hp;
    public int[] repeat_Hp;

    Mode_Select Mode;

    public Sprite[] sprite;
    void Awake()
    {
        Mode = FindObjectOfType<Mode_Select>();

        // ��ȯ �� ��ġ�� ������Ʈ ����� ��ȯ ��ų ���� �±� ����
        Spawn_Position1 = GameObject.FindGameObjectsWithTag("NormalMonster_Spawn");
        Spawn_Position2 = GameObject.FindGameObjectsWithTag("farMonster_Spawn");
        Spawn_Position3 = GameObject.FindGameObjectsWithTag("repeatMonster_Spawn");

    }

    void Start()
    {

        if (Mode.Easy == true) // �������̵�
        {
            EasyMode();
        }
        if (Mode.Hard == true) // �ϵ峭�̵�
        {
            HardMode();
        }
    }

    void EasyMode()
    {
        foreach (GameObject spawn in Spawn_Position1)
        {
            Monster_prefabs[0].GetComponent<Normal_Monster>().Monster_hpMax = Normal_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[0], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position2)
        {
            Monster_prefabs[1].GetComponent<Far_Monster>().Monster_hpMax = far_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[1], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position3)
        {
            Monster_prefabs[2].GetComponent<Mosnter_Repeat>().Monster_hpMax = repeat_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[2], spawn.transform.position, spawn.transform.rotation);
        }
    }

    void HardMode() 
    {
        foreach (GameObject spawn in Spawn_Position1)
        {
            Monster_prefabs[0].GetComponent<Normal_Monster>().Monster_hpMax = Normal_Hp[1];
            GameObject pre = Instantiate(Monster_prefabs[0], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position2)
        {
            Monster_prefabs[1].GetComponent<Far_Monster>().Monster_hpMax = far_Hp[1];
            GameObject pre = Instantiate(Monster_prefabs[1], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position3)
        {
            Monster_prefabs[2].GetComponent<Mosnter_Repeat>().Monster_hpMax = repeat_Hp[1];
            GameObject pre = Instantiate(Monster_prefabs[2], spawn.transform.position, spawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
