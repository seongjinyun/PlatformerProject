using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Spawn : MonoBehaviour
{
    // 프리팹 스테이지 배치 후 프리팹 언팩 해줘야함. (실수로 프리팹 수치 변경하면 다 변경되서)
    GameObject Spawn_Position1;


    public GameObject[] Boss_prefabs; // 몬스터 프리팹 0 = 근거리, 1 = 원거리, 2 = 패트롤

    // 난이도 별 몬스터 체력 0 = 이지, 1 = 하드
    public int[] Stage_1;
    public int[] Stage_2;
    public int[] Stage_3;
    public int[] Stage_4;

    Mode_Select Mode;

    void Awake()
    {
        Mode = FindObjectOfType<Mode_Select>();

        // 소환 할 위치에 오브젝트 만들고 소환 시킬 몬스터 태그 지정
        Spawn_Position1 = GameObject.FindGameObjectWithTag("Boss_Spawn");

        if (Mode.Easy == true) // 이지난이도
        {
            EasyMode();
        }
        if (Mode.Hard == true) // 하드난이도
        {
            HardMode();
        }

    }

    void Start()
    {

    }

    void EasyMode()
    {
        if (SceneManager.GetActiveScene().name == "1_StageBoss")
        {
            Boss_prefabs[0].GetComponent<One_Stage_Boss>().Monster_hpMax = Stage_1[0];
            GameObject pre = Instantiate(Boss_prefabs[0], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else if (SceneManager.GetActiveScene().name == "2_StageBoss")
        {
            Boss_prefabs[1].GetComponent<Stage_2_monster>().Monster_hpMax = Stage_2[0];
            GameObject pre = Instantiate(Boss_prefabs[1], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else if (SceneManager.GetActiveScene().name == "3_StageBoss")
        {
            Boss_prefabs[2].GetComponent<Fire_Boss>().Monster_hpMax = Stage_3[0];
            GameObject pre = Instantiate(Boss_prefabs[2], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else if (SceneManager.GetActiveScene().name == "4_StageBoss")
        {
            Boss_prefabs[3].GetComponent<Wind_Boss>().Monster_hpMax = Stage_4[0];
            GameObject pre = Instantiate(Boss_prefabs[3], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else
        {
            return;
        }

    }

    void HardMode()
    {
        if (SceneManager.GetActiveScene().name == "1_StageBoss")
        {
            Boss_prefabs[0].GetComponent<One_Stage_Boss>().Monster_hpMax = Stage_1[1];
            GameObject pre = Instantiate(Boss_prefabs[0], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else if (SceneManager.GetActiveScene().name == "1_StageBoss")
        {
            Boss_prefabs[1].GetComponent<Stage_2_monster>().Monster_hpMax = Stage_2[1];
            GameObject pre = Instantiate(Boss_prefabs[1], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else if (SceneManager.GetActiveScene().name == "1_StageBoss")
        {
            Boss_prefabs[2].GetComponent<Fire_Boss>().Monster_hpMax = Stage_3[1];
            GameObject pre = Instantiate(Boss_prefabs[2], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else if (SceneManager.GetActiveScene().name == "1_StageBoss")
        {
            Boss_prefabs[3].GetComponent<Wind_Boss>().Monster_hpMax = Stage_4[1];
            GameObject pre = Instantiate(Boss_prefabs[3], Spawn_Position1.transform.position, Spawn_Position1.transform.rotation);
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
