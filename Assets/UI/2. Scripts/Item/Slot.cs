using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public GameObject slot;
    public Item item;
    public Image itemIcon;
    
    private void Update()
    {
        if (Inventory.instance.items.Contains(item))
        {

        }
        else
        {
            slot.SetActive(false);
        }
    }

    public void UpdateSlotUI()
    {   
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

}
