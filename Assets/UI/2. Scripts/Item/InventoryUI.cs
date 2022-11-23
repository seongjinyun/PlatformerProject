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
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onChangeItem += RedrawSlotUI;  

    }


    void RedrawSlotUI()
    {   
        for (int i = 0; i < slots.Length; i++)
        {   
            if (inven.items[i].itemType == ItemType.Consumables)
            {
                slots[i].item = inven.items[i];
                slots[i].UpdateSlotUI();
            }
            if (inven.items[i].itemType == ItemType.ImConsumables)
            {
                Debug.Log("체력 회복!");
                Inventory.instance.RemoveInven();
                return;
            }
            if (inven.items[i].itemType == ItemType.etc)
            {
                Debug.Log("으앜 쓰레기야!");
                Inventory.instance.RemoveInven();
                return;
            }
        }
    }
}