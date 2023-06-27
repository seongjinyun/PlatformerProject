using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Map_pattern : MonoBehaviour
{
    public GameObject laser_before;
    public GameObject laser;
    Vector3 trans;
    Vector3 playerPos;
    public enum Atk_Pattern { Bottom_Atk, Rush_Atk }

    private bool isAttacking = false;

    public float delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Monster_Skill_Pos").GetComponent<Transform>().position;
        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            StartCoroutine(BeforeAttack());
            delay = 5f;
        }

    }
    IEnumerator BeforeAttack()
    {
        if (isAttacking == false)
        {
            Atk_Pattern atk_Pattern = Atk_Pattern.Bottom_Atk;
            if (atk_Pattern == Atk_Pattern.Bottom_Atk)
            {
                trans = playerPos;
                isAttacking = true;
                //Debug.Log("감지한 위치 : " + whereToAtk);
                GameObject laser_ = Instantiate(laser_before, trans, transform.rotation);

                Destroy(laser_, 1.7f);
                yield return new WaitForSeconds(1.7f);
                StartCoroutine(Bottom_Attack());
            }
        }
    }

    IEnumerator Bottom_Attack() // 공격
    {
        GameObject laser_ = Instantiate(laser, trans, transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(laser_, 1f);
        //Debug.Log("공격 끝남");
        isAttacking = false;
    }

}
