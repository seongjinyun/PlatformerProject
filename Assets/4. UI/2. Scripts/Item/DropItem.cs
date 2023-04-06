using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    bool isDie = false;
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
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie)
            Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddItem(GetItem());

            isDie = true;
            if (isDie)
                Destroy(gameObject);
        }
    }
}
