using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AllUnits
{
    public class Unit : MonoBehaviour
    {
        // 플레이어와 적 유닛이 공통으로 사용할 변수
        [SerializeField] protected float speed = 3f;
        [SerializeField] internal int maxHealth = 50;
        [SerializeField] internal int currentHealth;
        [SerializeField] internal int damage = 1;
        [SerializeField] internal int SkillDamage_Sword = 2;
        [SerializeField] internal int SkillDamage_Spear = 2;
        [SerializeField] internal int SkillDamage_Shield = 3;
        [SerializeField] internal float damageDelay = 2f;
        private float initialDamageDelay;
        [SerializeField] protected bool isDamage = false;

        public int CharCode;

        protected SpriteRenderer sprite;

        protected bool Player_Die = false;

        public AudioClip[] clip_attacked; // 피격 사운드 

        public GameObject me;

        // 자식 클래스들도 사용될 수 있도록
        virtual protected void Start()
        {
            currentHealth = maxHealth;
            initialDamageDelay = damageDelay;
            sprite = GetComponent<SpriteRenderer>();
            me = GameObject.FindWithTag("Player");
        }
        virtual protected void Update()
        {
           if(currentHealth > 25)
            {
                currentHealth = 25;
            }
        }
        public void findAllChildren()
        {
            
        }
        public void TakeDamage(int Monster_Damage) // 피격 
        {
            SpriteRenderer[] allChildren = me.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer child in allChildren)
            {
                float damtime = 0;

                while (damtime < 10)
                {
                    if (damtime % 2 == 0)
                    {
                        child.color = new Color32(255, 255, 255, 90);
                    }
                    else
                    {
                        child.color = new Color32(255, 255, 255, 180);
                    }

                    damtime += Time.deltaTime;
                    Debug.Log(damtime);
                }
                sprite.color = new Color32(255, 255, 255, 255);
            }
            StartCoroutine(dam());
            
            //SfxManger.instance.SfxPlay("Monster_Attacked", clip_attacked[0]);
            if (clip_attacked.Length > 0)
            {
                SfxManger.instance.SfxPlay("Monster_Attacked", clip_attacked[0]);
            }
            if (Player_UsingItem.UsingActiveShield == false)
            {
                if (!isDamage)
                {
                    currentHealth -= Monster_Damage;
                    
                    if (currentHealth <= 0)
                    {
                        //DIe 애님 실행 및 삭제
                        //Debug.Log("사망");
                    }
                    StartCoroutine(NotDam());
                }
                else
                {
                    currentHealth -= 0;
                }
            }
        }
        IEnumerator NotDam()
        {
            isDamage = true;
            yield return new WaitForSeconds(0.2f);
            isDamage = false;
        }

        IEnumerator dam()
        {
            /*SpriteRenderer[] allChildren = me.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer child in allChildren)
            {
                int damtime = 0;

                while (damtime < 10)
                {
                    if (damtime % 2 == 0)
                    {
                        child.color = new Color32(255, 255, 255, 90);
                    }
                    else
                    {
                        child.color = new Color32(255, 255, 255, 180);
                    }

                    yield return new WaitForSeconds(0.2f);

                    damtime++;
                    Debug.Log(damtime);
                }
                sprite.color = new Color32(255, 255, 255, 255);
            }
            */
            yield return new WaitForSeconds(0.2f);
        }
        public void NotDamage(int Zero_Damage) //무적 피격
        {
            currentHealth -= Zero_Damage;
            
        }
    }
}