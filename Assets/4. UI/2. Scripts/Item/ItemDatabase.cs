using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();

    public GameObject DropItemPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            GameObject go = Instantiate(DropItemPrefab ,transform.position, Quaternion.identity);
            go.GetComponent<DropItem>().DropItems(itemDB[Random.Range(0, 4)]);

            Destroy(gameObject);
        }
    }
}
