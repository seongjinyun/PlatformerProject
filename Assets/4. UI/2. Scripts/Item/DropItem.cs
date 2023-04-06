using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public ItemType DropItems(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;
            return _item.itemType;
    }
    public Item GetItem()
    {
        return item;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (Inventory.instance.items.Count < 1)
            {
                Inventory.instance.AddItem(GetItem());
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
