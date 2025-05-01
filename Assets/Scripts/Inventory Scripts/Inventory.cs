using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public delegate void OnInventoryChanged();
    
    public OnInventoryChanged OnInventoryChangedCallback;
    
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public int inventorySize = 20;

    public bool AddItem(InventorySlot inventorySlot)
    {
        try
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].item.itemName == inventorySlot.item.itemName)
                {
                    InventorySlot newInventorySlot = inventorySlot;
                    newInventorySlot.amount += inventory[i].amount;
                    inventory[i] = newInventorySlot;
                    return true;
                }
            }

            if (inventory.Count >= inventorySize)
            {
                Debug.Log("Inventory is full");
                return false;
            }

            inventory.Add(inventorySlot);
            return true;
        }
        finally
        {
            if (OnInventoryChangedCallback != null)
            {
                OnInventoryChangedCallback();
            }
        }
        
    }

    public void RemoveItem(InventorySlot inventorySlot)
    {
        try
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].item.itemName == inventorySlot.item.itemName)
                {
                    if (inventorySlot.amount > inventory[i].amount)
                    {
                        return;
                    }
                    else if (inventorySlot.amount == inventory[i].amount)
                    {
                        inventory.RemoveAt(i);
                    }
                    else
                    {
                        InventorySlot newInventorySlot = inventorySlot;
                        newInventorySlot.amount -= inventory[i].amount;
                        inventory[i] = newInventorySlot;
                    }

                    return;
                }
            }

            Debug.Log("Item not in Inventory");
        }
        finally
        {
            if (OnInventoryChangedCallback != null)
            {
                OnInventoryChangedCallback();
            }
        }
        
    }

    public int CountItem(ItemSO item)
    {
        foreach (InventorySlot inventorySlot in inventory)
        {
            if (inventorySlot.item.itemName == item.itemName)
            {
                return inventorySlot.amount;
            }
        }
        return 0;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one Inventory singleton");
        }
    }
}
