using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spawn : MonoBehaviour
{
    GameObject[] Spawn_Position1;
    GameObject[] Spawn_Position2;
    GameObject[] Spawn_Position3;
    public GameObject[] Monster_prefabs;

    public int[] Normal_Hp;
    public int[] far_Hp;
    public int[] repeat_Hp;
    // Start is called before the first frame update

    void Awake()
    {
        Spawn_Position1 = GameObject.FindGameObjectsWithTag("NormalMonster_Spawn");
        Spawn_Position2 = GameObject.FindGameObjectsWithTag("farMonster_Spawn");
        Spawn_Position3 = GameObject.FindGameObjectsWithTag("repeatMonster_Spawn");

    }

    void Start()
    {
        EasyMode();
        HardMode();

    }

    void EasyMode()
    {
        foreach (GameObject spawn in Spawn_Position1)
        {
            Monster_prefabs[0].GetComponent<Monster_Stats>().Monster_hpMax = Normal_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[0], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position2)
        {
            Monster_prefabs[1].GetComponent<Monster_Stats>().Monster_hpMax = far_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[1], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position3)
        {
            Monster_prefabs[2].GetComponent<Monster_Stats>().Monster_hpMax = repeat_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[2], spawn.transform.position, spawn.transform.rotation);
        }
    }

    void dd()
    {

    }


    void HardMode()
    {
        foreach (GameObject spawn in Spawn_Position1)
        {
            Monster_prefabs[0].GetComponent<Monster_Stats>().Monster_hpMax = Normal_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[0], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position2)
        {
            Monster_prefabs[1].GetComponent<Monster_Stats>().Monster_hpMax = far_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[1], spawn.transform.position, spawn.transform.rotation);
        }

        foreach (GameObject spawn in Spawn_Position3)
        {
            Monster_prefabs[2].GetComponent<Monster_Stats>().Monster_hpMax = repeat_Hp[0];
            GameObject pre = Instantiate(Monster_prefabs[2], spawn.transform.position, spawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
