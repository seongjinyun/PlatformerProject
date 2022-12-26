using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Status
    {
        public Unit_Code unitCode { get; } //�����ڵ�
        public string name { get; set; } //�̸�
        public int atk { get; set; } // ���ݷ�
        public int SP_atk { get; set; } // Ư�����ݷ�
        public int atk_speed { get; set; } //���ݼӵ�
        public int hp { get; set; } //ü��
        public int move_speed { get; set; } //�̵��ӵ�

        public Status()
        {

        }

        public Status(Unit_Code unit_code, string name, int atk, int SP_atk, int atk_speed, int hp, int move_speed)
        {
            this.unitCode = unit_code;
            this.name = name;
            this.atk = atk;
            this.SP_atk = SP_atk;
            this.atk_speed = atk_speed;
            this.hp = hp;
            this.move_speed = move_speed;
        }

        public Status SetUnitStatus(Unit_Code unitCode)
        {
            Status status = null;

            switch (unitCode)
            {
                case Unit_Code.Sword:
                    status = new Status(unitCode, "Sword", 1, 1, 1, 1, 1); //�����ڵ�, �̸�, ���ݷ�, Ư�����ݷ�, ���ݼӵ�, ü��, �̵��ӵ�
                    break;
            }
            return status;
        }
        
    }
}
