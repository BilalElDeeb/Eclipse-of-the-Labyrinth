using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventorySlotsParent;
    List<InventorySlotUI> uiSlots = new List<InventorySlotUI>();

    void Start()
    {
        uiSlots = inventorySlotsParent.GetComponentsInChildren<InventorySlotUI>().ToList();

        Inventory.instance.OnInventoryChangedCallback += updateUI;
    }
    
    void updateUI()
    {
        List<InventorySlot> slots = Inventory.instance.inventory;
        for (int i = 0; i < uiSlots.Count; i++)
        {
            if (i < slots.Count)
            {
                uiSlots[i].SetItem(slots[i].item, slots[i].amount);
            }
            else
            {
                uiSlots[i].ClearItem();
            }
        }
    }
}
