using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat 
{
    public Unit_Code unitCode { get; }
    public string name { get; set; }
    public int Damage { get; set; }

    public Stat()
    {

    }
    public Stat(Unit_Code unitCode,string name, int Damage)
    {
        this.unitCode = unitCode;
        this.name = name;
        this.Damage = Damage;
    }
    public Stat SetUnitStat(Unit_Code unitCode)
    {
        Stat stat = null;

        switch (unitCode)
        {
            case Unit_Code:
                stat = new Stat(unitCode, "Sword", 5);
                break;
        }
        return stat;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
