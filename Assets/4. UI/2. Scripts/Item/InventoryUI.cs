using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{   
    Inventory inven;
    public DropItem dropitem;
    public GameObject inventoryPannel;

    public Slot[] slots;
    public Transform slotHolder;

    public void Start()
    {
        if(Inventory.instance != null){
            inven = Inventory.instance;
        }
        else
        {
            Inventory.instance = inven;
        }
            
        slots = slotHolder.GetComponentsInChildren<Slot>();
        if(inven)inven.onChangeItem += RedrawSlotUI;
    }

    public void Update()
    {
        RedrawSlotUI();
    }


    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {   
            if (inven.items.Count == 0)
            {   
                slots[i].itemIcon.sprite = null;
                break;
            }

            if (inven.items[i].itemType == ItemType.Consumables || inven.items[i].itemType == ItemType.etc)
            {
                slots[i].item = inven.items[i];
                slots[i].UpdateSlotUI(slots[i].item);
                return;
            }
        }
    }
}