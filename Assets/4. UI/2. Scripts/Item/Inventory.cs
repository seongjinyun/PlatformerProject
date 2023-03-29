using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Item item;
    #region Singleton
    [SerializeField]
    public static Inventory instance;
    private void Awake()
    {   
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnchangeItem();
    public OnchangeItem onChangeItem;

    public List<Item> items = new List<Item>();
    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
     
        }
    }

    void Start()
    {
        SlotCnt = 1;
    }

    public bool AddItem(Item _item)
    {
        if (items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
                onChangeItem.Invoke();
            return true;
        }
        return false;
    }
    public void RemoveInven()
    {
        items.RemoveRange(0, items.Count);
    }

    public void Removeslot()
    {   
        onChangeItem.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DropItem"))
        {
            DropItem dropItem = collision.GetComponent<DropItem>();
            if (AddItem(dropItem.GetItem()))
                dropItem.DestroyItem();
        }
    }

}
