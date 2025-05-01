using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO item;
    public int amount;
    

    private void Awake()
    {
        initialize(this.item, amount);
    }

    void initialize(ItemSO item, int amount)
    {
        this.item = item;
        this.GetComponent<SpriteRenderer>().sprite = item.itemImage;
        this.transform.localScale = new Vector3(item.itemScale, item.itemScale, 1);
        this.amount = amount;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            InventorySlot inventorySlot = new InventorySlot
            {
                item = item,
                amount = amount
            };

            if (Inventory.instance.AddItem(inventorySlot))
            {
                Destroy(gameObject);
            }
        }
    }
}
