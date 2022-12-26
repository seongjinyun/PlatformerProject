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
        public Unit_Code unitCode { get; } //유닛코드
        public string name { get; set; } //이름
        public int atk { get; set; } // 공격력
        public int SP_atk { get; set; } // 특수공격력
        public int atk_speed { get; set; } //공격속도
        public int hp { get; set; } //체력
        public int move_speed { get; set; } //이동속도

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
                    status = new Status(unitCode, "Sword", 1, 1, 1, 1, 1); //유닛코드, 이름, 공격력, 특수공격력, 공격속도, 체력, 이동속도
                    break;
            }
            return status;
        }
        
    }
}
