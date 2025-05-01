using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO item;
    public int amount;

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
