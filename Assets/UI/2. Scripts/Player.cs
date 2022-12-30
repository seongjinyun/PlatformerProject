using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inven;
    public Slot[] slots;
    public ParticleSystem particleObject, particleObject2;
    
    int playerSpeed = 10;
    Rigidbody2D rid2D;
    public int Player_Hp;
    // Start is called before the first frame update


    void Start()
    {
        inven = Inventory.instance;
        Player_Hp = 5;
        rid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {  
            if (inven.items[0].itemName == "Speed")
            {   
                particleObject.Play();
                Inventory.instance.RemoveInven();
                Inventory.instance.onChangeItem();
            }
            if (inven.items[0].itemName == "Shield")
            {
                particleObject2.Play();
                Inventory.instance.RemoveInven();
                Inventory.instance.onChangeItem();
            }
            else
            {
                Inventory.instance.RemoveInven();
                Inventory.instance.onChangeItem();
            }
        }
    }
}
