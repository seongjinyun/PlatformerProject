using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{   
    Consumables,
    ImConsumables, 
    etc
}

[System.Serializable]
public class Item
{   
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    
    public static implicit operator Item(List<Item> v)
    {
        throw new NotImplementedException();
    }
}