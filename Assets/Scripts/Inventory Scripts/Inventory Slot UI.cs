using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemamount;
    public Button closeButton;
    public Button itemButton;
    public ItemSO item;
    public int amount;
    
    public void SetItem(ItemSO item, int amount)
    {
        itemIcon.enabled = true;
        itemIcon.sprite = item.itemImage;
        
        itemamount.text = amount.ToString();
        
        closeButton.interactable = true;
        itemButton.interactable = true;
        
        this.item = item;
        this.amount = amount;
    }

    public void ClearItem()
    {
        itemIcon.enabled = false;
        itemIcon.sprite = null;
        
        itemamount.text = "";
        
        closeButton.interactable = false;
        itemButton.interactable = false;
        this.item = null;
        this.amount = 0;
    }

    public void removeItem()
    {
        Inventory.instance.RemoveItem(new InventorySlot
        {
            item = this.item,
            amount = this.amount
        });
    }
}
