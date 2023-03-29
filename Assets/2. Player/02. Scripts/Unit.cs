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
        [SerializeField] internal int SkillDamage_Sword = 3;
        [SerializeField] internal int SkillDamage_Spear = 3;
        [SerializeField] internal int SkillDamage_Shield = 5;
        [SerializeField] internal float damageDelay = 2f;
        private float initialDamageDelay;
        [SerializeField] protected bool isDamage = false;

        public int CharCode;

        // 자식 클래스들도 사용될 수 있도록
        virtual protected void Start()
        {
            currentHealth = maxHealth;
            initialDamageDelay = damageDelay;
        }
        virtual protected void Update()
        {
            DamageDelay();
        }
        protected void DamageDelay()
        {
            if (isDamage && damageDelay > 0)
            {
                damageDelay -= Time.deltaTime;
                if (damageDelay <= 0)
                {
                    isDamage = false;
                    damageDelay = initialDamageDelay;
                }
            }
        }
        public void TakeDamage(int Monster_Damage) // 피격 
        {
            if (Player_UsingItem.UsingActiveShield == false)
            {
                currentHealth -= Monster_Damage;
                if (currentHealth <= 0)
                {
                    //DIe 애님 실행 및 삭제
                    //Debug.Log("사망");
                }
            }
            else
            {

            }
        }

        public void NotDamage(int Zero_Damage) //무적 피격
        {
            currentHealth -= Zero_Damage;
            
        }
    }
}