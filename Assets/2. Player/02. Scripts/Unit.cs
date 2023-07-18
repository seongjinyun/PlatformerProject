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
        [SerializeField] internal int SkillDamage_Sword = 2;
        [SerializeField] internal int SkillDamage_Spear = 2;
        [SerializeField] internal int SkillDamage_Shield = 3;
        [SerializeField] internal float damageDelay = 2f;
        private float initialDamageDelay;
        [SerializeField] protected bool isDamage = false;

        public int CharCode;

        protected SpriteRenderer sprite;

        protected bool Player_Die = false;

        public AudioClip[] clip_attacked; // �ǰ� ���� 

        public GameObject Attacked_Effect; // �ǰ� ����Ʈ



        private float damageTimer = 0f;

        // �ڽ� Ŭ�����鵵 ���� �� �ֵ���
        virtual protected void Start()
        {
            currentHealth = maxHealth;
            initialDamageDelay = damageDelay;
            sprite = GetComponent<SpriteRenderer>();
            
            
        }
        virtual protected void Update()
        {
            if (currentHealth > 25)
            {
                currentHealth = 25;
            }
        }
        
        public void TakeDamage(int Monster_Damage) // �ǰ� 
        {

            //GameObject Atk_Ef = Instantiate(Attacked_Effect, me.transform.position, me.transform.rotation);
            //Destroy(Atk_Ef, 0.5f);

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

        
    }
}