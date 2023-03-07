using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_monster_state : MonoBehaviour
{
    public GameObject parent_Boss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GameObject.FindGameObjectWithTag("Monster").GetComponent<One_Stage_Boss>().Attack_State = true;
            parent_Boss.GetComponent<Stage_2_monster>().Attack_State = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GameObject.FindGameObjectWithTag("Monster").GetComponent<One_Stage_Boss>().Attack_State = false;
            parent_Boss.GetComponent<Stage_2_monster>().Attack_State = false;

        }
    }
}