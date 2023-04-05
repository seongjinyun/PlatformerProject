using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AllUnits
{
    public class Unit : MonoBehaviour
    {
        // �÷��̾�� �� ������ �������� ����� ����
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

        protected bool Player_Die = false;

        // �ڽ� Ŭ�����鵵 ���� �� �ֵ���
        virtual protected void Start()
        {
            currentHealth = maxHealth;
            initialDamageDelay = damageDelay;
        }
        virtual protected void Update()
        {
           
        }
        
        public void TakeDamage(int Monster_Damage) // �ǰ� 
        {
            
            if (Player_UsingItem.UsingActiveShield == false)
            {
                if (!isDamage)
                {
                    currentHealth -= Monster_Damage;
                    if (currentHealth <= 0)
                    {
                        //DIe �ִ� ���� �� ����
                        //Debug.Log("���");
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
        public void NotDamage(int Zero_Damage) //���� �ǰ�
        {
            currentHealth -= Zero_Damage;
            
        }
    }
}