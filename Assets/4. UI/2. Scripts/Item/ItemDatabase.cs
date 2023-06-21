using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public AudioClip clip;
    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();

    public GameObject DropItemPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            SfxManger.instance.SfxPlay("Get_Item", clip);
            GameObject go = Instantiate(DropItemPrefab ,transform.position, Quaternion.identity);
            go.GetComponent<DropItem>().DropItems(itemDB[Random.Range(0, 4)]);

            Destroy(gameObject);
        }
    }
}
