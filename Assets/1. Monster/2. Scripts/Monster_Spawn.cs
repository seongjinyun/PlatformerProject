using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spawn : MonoBehaviour
{
    // 프리팹 스테이지 배치 후 프리팹 언팩 해줘야함. (실수로 프리팹 수치 변경하면 다 변경되서)
    GameObject[] Spawn_Position1;
    GameObject[] Spawn_Position2;
    GameObject[] Spawn_Position3;
    public GameObject[] Monster_prefabs; // 몬스터 프리팹 0 = 근거리, 1 = 원거리, 2 = 패트롤

    // 난이도 별 몬스터 체력 0 = 이지, 1 = 하드
    public int[] Normal_Hp;
    public int[] far_Hp;
    public int[] repeat_Hp;

    Mode_Select Mode;

    public Sprite[] sprite;
    void Awake()
    {
        Mode = FindObjectOfType<Mode_Select>();

        // 소환 할 위치에 오브젝트 만들고 소환 시킬 몬스터 태그 지정
        Spawn_Position1 = GameObject.FindGameObjectsWithTag("NormalMonster_Spawn");
        Spawn_Position2 = GameObject.FindGameObjectsWithTag("farMonster_Spawn");
        Spawn_Position3 = GameObject.FindGameObjectsWithTag("repeatMonster_Spawn");

    }

    void Start()
    {

        if (Mode.Easy == true) // 이지난이도
        {
            EasyMode();
        }
        if (Mode.Hard == true) // 하드난이도
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
