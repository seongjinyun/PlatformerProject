using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Transform pos;
    GameObject[] Enemy_Test;
    public Vector2 player_boxSize;
    protected float Kb_timer = 0f;
    static public float Skill_gauge = 0;
    protected Animator Player_anim;
    public float Kb_delayTime = 2f;
    protected float Max_Skill_gauge = 101;
    
    public Transform Parent;

    protected float Atk_curTime;

    [SerializeField]
    public float Atk_coolTime = 1f;
    //public float Atk_speed = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Test = GameObject.FindGameObjectsWithTag("Monster");
        Player_anim = GetComponent<Animator>();
    }

    

    public void Attack_gauge()
    {
        if(Atk_curTime <= 0)
        {
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                
                
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
                foreach (Collider2D collider in collider2Ds)


                    if (collider.tag == "Monster") //Monster �±׿� �浹�ϸ�
                    {
                        Gauge();
                        
                    }

                Player_anim.SetTrigger("Attack");
                
                Atk_curTime = Atk_coolTime;

            }
        }
        else
        {
            Atk_curTime -= Time.deltaTime;
        }
            
    }

    
    public void Gauge()
    {
        Skill_gauge += 5;
        Debug.Log("������ + " + Skill_gauge);
    }
    
    
       
        
    

    /*IEnumerator Kb_Delay()
    {
        isKnockback = true;
        yield return new WaitForSeconds(0.41f);

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, player_boxSize, 0); //�ڽ��ȿ� ������ ��� ������Ʈ���� collider2d[] �迭�� ����
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Monster") //Monster �±׿� �浹�ϸ�
                {
                    Skill_gauge += 5;
                    Debug.Log("������ + 5");
                    foreach (GameObject monster in Enemy_Test)

                    if (Parent.transform.position.x > monster.transform.position.x && monster.transform.rotation.y == 0) //�÷��̾� ��ġ�� ������ġ���� ������
                    {
                        //isKnockback = true;
                        collider.transform.Translate(-2.0f, 0.4f, 0); // ���� ƨ�ܳ���
                        is_delay = true;
                    }
                    else if (Parent.transform.position.x < monster.transform.position.x && monster.transform.rotation.eulerAngles.y <= 180) //�÷��̾� ��ġ�� ������ġ���� ����
                    {
                        //isKnockback = true;
                        collider.transform.Translate(-2.0f, 0.4f, 0); //���������� ƨ�ܳ���
                        is_delay = true;
                    }
                    else if (Parent.transform.position.x < monster.transform.position.x && monster.transform.rotation.eulerAngles.y <= -180) //�÷��̾� ��ġ�� ������ġ���� ����
                    {
                        //isKnockback = true;
                        collider.transform.Translate(2.0f, 0.4f, 0); //���������� ƨ�ܳ���
                        is_delay = true;
                    }
                }
            }
            
            yield return new WaitForSeconds(0.5f);
            isKnockback = false;
    }
    */
   

    // Update is called once per frame
    void Update()
    {
        if(Skill_gauge >= Max_Skill_gauge)
        {
            Skill_gauge = 100;
            //Debug.Log(Skill_gauge);
        }

        Attack_gauge();
       // Player_anim.SetFloat("Attack_speed", Atk_speed);
        
    }
}
