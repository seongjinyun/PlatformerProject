using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UsingItem : MonoBehaviour
{
    Inventory inven;
    public Slot[] slots;
    public ParticleSystem particleObject, particleObject2;
    public static bool UsingActiveSpeed;
    public static bool UsingActiveShield;
    public float Activecooldown;
    public static bool ShieldOn;

    public AudioClip[] clip; // 사운드 클립 0 = Invisibility, 1 = Speed_Item

    int playerSpeed = 10;
    Rigidbody2D rid2D;
    // Start is called before the first frame update


    void Start()
    {
        UsingActiveSpeed = false;
        UsingActiveShield = false;

        inven = Inventory.instance;
        rid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inven.items.Count > 0)
            {
                if (inven.items[0].itemName == "Trash1")
                {
                    Inventory.instance.RemoveInven();
                    Inventory.instance.onChangeItem();
                }
                if (inven.items[0].itemName == "Trash2")
                {
                    Inventory.instance.RemoveInven();
                    Inventory.instance.onChangeItem();
                }
                if (UsingActiveSpeed == false)
                {
                    if (inven.items[0].itemName == "Speed")
                    {
                        particleObject.Play();
                        SfxManger.instance.SfxPlay("Speed_Item", clip[1]);
                        Inventory.instance.RemoveInven();
                        Inventory.instance.onChangeItem();
                        UsingActiveSpeed = true;
                    }   
                }
                if(UsingActiveShield == false)
                {
                    if (inven.items[0].itemName == "Shield")
                    {
                        particleObject2.Play();
                        SfxManger.instance.SfxPlay("Invisibility", clip[0]);
                        Inventory.instance.RemoveInven();
                        Inventory.instance.onChangeItem();
                        UsingActiveShield = true;
                        ShieldOn = true;
                    }
                }
            }
        }
        if(UsingActiveSpeed == true)
        {
            Activecooldown += Time.deltaTime;
            if(Activecooldown >= 5)
            {
                UsingActiveSpeed = false;
                Activecooldown = 0;
                if(UsingActiveSpeed == false) // 파티클이 꺼지면 소리 안나게
                {
                    
                }
            }
        }
        if (UsingActiveShield == true)
        {
            Activecooldown += Time.deltaTime;
            if (Activecooldown >= 3)
            {
                UsingActiveShield = false;
                ShieldOn = false;

                Activecooldown = 0;
                if (UsingActiveShield == false) // 파티클이 꺼지면 소리 안나게
                {
                    
                }
            }
        }
    }
}
